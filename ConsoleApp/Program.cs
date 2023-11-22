var httpClient = new HttpClient();

var url = "http://localhost:5018/foo/";

for (int i = 1; i <= 20; i++)
{
	Console.WriteLine($"Try {i} of 20");

	var cts = new CancellationTokenSource();

	_ = httpClient.GetAsync(url, cts.Token);

	var task = httpClient.GetAsync(url);

	await Task.Delay(200);

	cts.Cancel();
	cts.Dispose();

	var result = await task;

	var responseContent = await result.Content.ReadAsStringAsync();

	Console.WriteLine($"Status: {result.StatusCode} | Response content: {responseContent}");

	if (string.IsNullOrEmpty(responseContent))
	{
		break;
	}

	await Task.Delay(2500); // Wait to the server cache expire
}
