using Microsoft.AspNetCore.Mvc;
using PersonApp.Domain.POCO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PersonApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BoredApiController : ControllerBase
	{
		static readonly HttpClientHandler clientHandler = new HttpClientHandler();
		static readonly HttpClient client = new HttpClient(clientHandler);
		static readonly string path = "https://www.boredapi.com/api/activity";

		public Task RunAsync()
		{
			client.BaseAddress = new Uri("http://localhost:44344/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			return Task.CompletedTask;
		}

		[HttpGet]
		public async Task<ActivityModel> GetActivityAsync()
		{
			clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
			ActivityModel activityModel = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				activityModel = await response.Content.ReadAsAsync<ActivityModel>();
			}
			return activityModel;
		}
	}
}
