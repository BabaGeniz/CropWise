using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CropWise.Models; 

[ApiController]
[Route("[controller]")]

public class AIController : ControllerBase
{
    private readonly IAIProcessorService _aiProcessorService;

    public AIController(IAIProcessorService aiProcessorService)
    {
        _aiProcessorService = aiProcessorService;
    }

    [HttpPost]
    [Route("AIImageAnalysis")]
    public async Task<IActionResult> AIImageAnalysis([FromQuery] string imageUrl)
    {
       
        var result = await _aiProcessorService.CallGeminiAIAsync(imageUrl, "AIzaSyAMX_WscB3TyIy-05HTWq-9E6hB6L7bGbA");

        // Parse the analysis result (stringified JSON)
        var parsedResult = JsonConvert.DeserializeObject<dynamic>(result);

        // Extract the text from the parsed result (adjust based on the exact structure)
        var analysisText = parsedResult.candidates[0].content.parts[0].text.Value;

        // AI response is formatted as: "Health Rating: X; Analysis: Y; Recommendation: Z"
        var sections = analysisText.Split(';');

        // Ensure we have all three sections
        string healthRating = sections.Length > 0 ? sections[0].Trim() : "No health rating available.";
        string analysis = sections.Length > 1 ? sections[1].Trim() : "No analysis available.";
        string recommendation = sections.Length > 2 ? sections[2].Trim() : "No recommendation available.";


        return Ok(new
        {
            HealthRating = healthRating,
            Analysis = analysis,
            Recommendation = recommendation
        });
    }
}

