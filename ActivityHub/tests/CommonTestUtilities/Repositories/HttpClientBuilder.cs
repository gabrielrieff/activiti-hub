using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;

namespace CommonTestUtilities.Repositories;
public class HttpClientBuilder
{
    public static HttpClient Build()
    {
        var mockHandler = new Mock<HttpMessageHandler>();

        // Mock the POST request to GitHub OAuth
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post &&
                    req.RequestUri!.ToString() == "https://github.com/login/oauth/access_token"),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    access_token = "mocked_access_token"
                }))
            });

        // Mock the GET request to GitHub user API
        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.ToString() == "https://api.github.com/user"),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(new
                {
                    Id = 12345,
                    Name = "Mocked User",
                    Email = "mockeduser@example.com",
                    avatar_url = "https://example.com/avatar.png"
                }))
            });

        return new HttpClient(mockHandler.Object)
        {
            BaseAddress = new Uri("https://github.com")
        };
    }

    public static HttpClient BuildError()
    {
        var mockHandler = new Mock<HttpMessageHandler>();

        mockHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("Bad Request")
            });

        return new HttpClient(mockHandler.Object);
    }
}
