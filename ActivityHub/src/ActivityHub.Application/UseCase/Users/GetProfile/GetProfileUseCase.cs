using ActivityHub.Communication.Response.Users;
using ActivityHub.Domain.Services.LoggedUser;

namespace ActivityHub.Application.UseCase.Users.GetProfile
{
    public class GetProfileUseCase : IGetProfileUseCase
    {
        private readonly ILoggedUser _loggedUser;
        public GetProfileUseCase(ILoggedUser loggedUser)
        {
            _loggedUser = loggedUser;
        }
        public async Task<ResponseUserProfileJson> Execute()
        {
            var user = await _loggedUser.Get();

            return new ResponseUserProfileJson
            {
                Name = user.Name,
                Email = user.Email,
                Avatar_url = user.avatarUrl,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
