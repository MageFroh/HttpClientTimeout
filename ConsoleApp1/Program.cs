var httpClientHandler = new HttpClientHandler();
httpClientHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;

using var client = new HttpClient(httpClientHandler);

var requestBody = new Dictionary<string, string>
{
    { "value", new string('c', 30_000_000) }
};

var content = new FormUrlEncodedContent(requestBody);

var result = await client.PostAsync("https://localhost:7243/Endpoint", content);

// Expected:
// BadRequest
// {"type":"https://tools.ietf.org/html/rfc7231#section-6.5.1","title":"One or more validation errors occurred.","status":400,"traceId":"00-eaecec73d4e64df8784aacfcdb405a74-ab12efe65e517633-00","errors":{"":["Failed to read the request form. Request body too large. The max request body size is 30000000 bytes."]}}

Console.WriteLine($"Status code: {result.StatusCode}");
Console.WriteLine(await result.Content.ReadAsStringAsync());
