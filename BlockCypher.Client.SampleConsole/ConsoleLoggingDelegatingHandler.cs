namespace BlockCypher.Client.SampleConsole;

public class ConsoleLoggingDelegatingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var requestBody = string.Empty;

        var response = await base.SendAsync(request, cancellationToken);

        Console.WriteLine($"{request.Method} {request.RequestUri}");
        if (!string.IsNullOrWhiteSpace(requestBody))
        {
            Console.WriteLine(requestBody);
        }
        Console.WriteLine($"{(int)response.StatusCode} {response.ReasonPhrase}");
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        Console.WriteLine(responseBody);

        return response;
    }
}