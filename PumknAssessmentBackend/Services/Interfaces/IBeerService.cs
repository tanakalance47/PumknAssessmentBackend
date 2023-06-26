using PumknAssessmentBackend.Models;

namespace PumknAssessmentBackend.Services.Interfaces
{
	public interface IBeerService
	{
		Task<BackendServiceResponse<List<Beer>>> GetAllBeers();
		Task<BackendServiceResponse<Beer>> GetBeerById(int id);
		Task<BackendServiceResponse<Beer>> GetRandomBeer();
		Task<BackendServiceResponse<List<Beer>>> SearchBeer(string name);
	}
}
