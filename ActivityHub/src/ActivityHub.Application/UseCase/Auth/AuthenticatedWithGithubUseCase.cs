using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ActivityHub.Communication.Request.Authenticated;
using ActivityHub.Communication.Response.Authenticated;
using ActivityHub.Domain.Entities;
using ActivityHub.Domain.Repositories;
using ActivityHub.Domain.Repositories.AccountProviders;
using ActivityHub.Domain.Repositories.Users;
using ActivityHub.Domain.Security.Tokens;

namespace ActivityHub.Application.UseCase.Auth
{
    public class AuthenticatedWithGithubUseCase : IAuthenticatedWithGithubUseCase
    {
        private const string ClientId = "Ov23liU56GOHLIyLifnt";
        private const string ClientSecret = "0ccc546138ea70e2041d0fba67d574ecbbcafaf9";
        private const string RedirectUri = "http://localhost:300/api/auth/callback";

        private readonly HttpClient _httpClient;
        private readonly IUserWhiteOnlyRepository _userWhiteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IAccountProvidersReadOnlyRepository _accountProvidersReadOnlyRepository;
        private readonly IAccountProviderWhiteOnlyRepository _accountProvidersWhiteOnlyRepository;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticatedWithGithubUseCase(
            HttpClient httpClient,
            IUserWhiteOnlyRepository userWhiteOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IAccountProvidersReadOnlyRepository accountProvidersReadOnlyRepository,
            IAccountProviderWhiteOnlyRepository accountProvidersWhiteOnlyRepository,
            IAccessTokenGenerator accessTokenGenerator,
            IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _userWhiteOnlyRepository = userWhiteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _accountProvidersReadOnlyRepository = accountProvidersReadOnlyRepository;
            _accountProvidersWhiteOnlyRepository = accountProvidersWhiteOnlyRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestAuthenticatedWithGithub body)
        {
            var githubAuthUrl = "https://github.com/login/oauth/access_token";

            var requestData = new
            {
                client_id = ClientId,
                client_secret = ClientSecret,
                code = body.Code,
                redirect_uri = RedirectUri
            };

            string jsonContent = JsonSerializer.Serialize(requestData);

            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await _httpClient.PostAsync(githubAuthUrl, content);

            string githubAccessTokenResponse = await response.Content.ReadAsStringAsync();

            var GithubAccessToken = Deserialize<ResponseAuthenticatedWithGithub>(githubAccessTokenResponse);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GithubAccessToken!.access_token);
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ActivityHub");

            var gethubUserResponse = await _httpClient.GetAsync("https://api.github.com/user");

            string githubUserData = await gethubUserResponse.Content.ReadAsStringAsync();

            var UserDataGithub = Deserialize<ResponseAuthenticatedUserDataGithub>(githubUserData);

            var user = await AlreadyUser(UserDataGithub);

            alreadyExistsAccountProvider(user, UserDataGithub);

            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson()
            {
                token = _accessTokenGenerator.Generate(user)
            };
        }

        private T Deserialize<T>(string data)
        {
            try
            {
                var dataJson = JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return dataJson!;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to deserialize the response. Ensure the response is in the expected format.", ex);
            }
        }

        private async Task<User> AlreadyUser(ResponseAuthenticatedUserDataGithub userGitHub)
        {
            var user = await _userReadOnlyRepository.GetUserByEmail(userGitHub.Email);

            if (user is null)
            {
                User newUser = new User
                {
                    Name = userGitHub.Name,
                    Email = userGitHub.Email,
                    avatarUrl = userGitHub.avatar_url,
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                };

                await _userWhiteOnlyRepository.Add(newUser);

                return newUser;
            }
            
            return user;
        }
        
        private async void alreadyExistsAccountProvider(User user, ResponseAuthenticatedUserDataGithub userGitHub)
        {
            var accountProvider = await _accountProvidersReadOnlyRepository.GetAccountProviderByUserId(user.Id);

            if (accountProvider is null)
            {
                AccountProvider provider = new AccountProvider
                {
                    providerAccountId = userGitHub.Id.ToString(),
                    UserId = user.Id,
                    provider = Domain.Enums.AccountProviderEnum.GITHUB,
                };

                await _accountProvidersWhiteOnlyRepository.Add(provider);
            }
        }
    }
}


