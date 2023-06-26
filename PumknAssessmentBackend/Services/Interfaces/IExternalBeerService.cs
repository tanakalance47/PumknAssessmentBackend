using PumknAssessmentBackend.Models;

namespace PumknAssessmentBackend.Services.Interfaces
{
	public interface IExternalBeerService
	{
		Task<BackendServiceResponse<List<Beer>>> CallExternalService(string url);
	}
}
