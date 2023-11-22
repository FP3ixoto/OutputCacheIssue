var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOutputCache();

var app = builder.Build();

app.UseOutputCache();

app.MapGet("/foo", async () =>
{
	await Task.Delay(500);
	return new { Foo = Random.Shared.Next(-220, 551) };
})
.CacheOutput(policy: policy => policy.Expire(TimeSpan.FromSeconds(2)));

app.Run();
