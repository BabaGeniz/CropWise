using CropWise.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

public class AIProcessorService:IAIProcessorService
{


    public AIProcessorService()
    {

    }
    public static async Task<string> ConvertImageUrlToBase64(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            byte[] imageBytes = await client.GetByteArrayAsync(url);
            return Convert.ToBase64String(imageBytes);
        }
    }
    public async Task<string> CallGeminiAIAsync(string imageUrl, string googleApiKey)
    {

        var base64Image = await ConvertImageUrlToBase64(imageUrl);

        var aiRequest = new AIRequest
        {
            Contents = new List<Content>
            {
                new Content
                {
                    Parts = new List<Part>
                    {
                        new Part { Text = "I would like the response in three sections divided by semicolons." +
                                          " First, On a scale of 1-5 how healthy is the crop in image in one character. " +
                                          " Second, give less than 3 sentences explaining why, if the crop is suffering any disease please indicate." +
                                          " Third, give a list of the top 3 recommendations divided by commas, when giving recommendations like fungicide," +
                                          " please be specific and give types/chemicals also, if the rating is less than 3 do not give less than 3 recommendations."
                                 },
                        new Part { InLineData = new InLineData
                                            {
                                                mimeType = "image/jpeg", 
                                                data = base64Image 
                                            }
                                  }
                    }
                }
            }
        };

        // Serialize the object to JSON
        string jsonPayload = JsonConvert.SerializeObject(aiRequest);

        // Create the request content
        var requestContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // Set the URL for Gemini's generateContent endpoint
        string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={googleApiKey}";

        // Send the POST request to the Gemini API
        var _httpClient = new HttpClient();
        var response = await _httpClient.PostAsync(url, requestContent);

        // If the request was successful, read and return the content
        if (response.IsSuccessStatusCode)
        {
            string responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;  
        }
        else
        {
            // Handle errors
            string errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error calling Gemini API: {errorResponse}");
        }
    }
}

