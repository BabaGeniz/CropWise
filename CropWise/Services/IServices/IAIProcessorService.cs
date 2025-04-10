using CropWise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IAIProcessorService
{
    Task<string> CallGeminiAIAsync(string imageUrl, string googleApiKey);
}

