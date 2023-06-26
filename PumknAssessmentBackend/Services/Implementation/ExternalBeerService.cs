using PumknAssessmentBackend.Helpers;
using PumknAssessmentBackend.Models;
using PumknAssessmentBackend.Services.Interfaces;
using System.Net;

namespace PumknAssessmentBackend.Services.Implementation
{
	public class ExternalBeerService : IExternalBeerService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ExternalBeerService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		/// <summary>
		/// Calls the external service.
		/// </summary>
		/// <param name="url">The URL.</param>
		/// <returns></returns>
		public async Task<BackendServiceResponse<List<Beer>>> CallExternalService(string url)
		{
			BackendServiceResponse<List<Beer>> response = new();

			try
			{	
				var httpClient = _httpClientFactory.CreateClient();
				var apiResponse = await httpClient.GetAsync(url);
				var data = await apiResponse.Content.ReadFromJsonAsync<List<Beer>>();

				response.Success = true;
				response.Data = data;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = ex.Message;
				response.StatusCode = HttpStatusCode.InternalServerError;

				//Log Error Here
			}

			return response;
		}
	}
}