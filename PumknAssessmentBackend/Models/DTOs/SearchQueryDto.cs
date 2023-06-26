using Newtonsoft.Json;

namespace PumknAssessmentBackend.Models.DTOs
{
	public record SearchQueryDto([JsonProperty("Query")] string Query);
}
