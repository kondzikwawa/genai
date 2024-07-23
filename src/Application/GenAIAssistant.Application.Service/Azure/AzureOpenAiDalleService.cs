using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.TextToImage;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAIAssistant.Application.Service.Azure
{
    internal class AzureOpenAiDalleService
    {
#pragma warning disable SKEXP0001, SKEXP0010, SKEXP0050, SKEXP0020

        //public async Task AzureOpenAIDallEAsync()
        //{
        //    Console.WriteLine("========Azure OpenAI DALL-E 3 Text To Image ========");

        //    var builder = Kernel.CreateBuilder()
        //        .AddAzureOpenAITextToImage( // Add your text to image service
        //            deploymentName: TestConfiguration.AzureOpenAI.ImageDeploymentName,
        //            endpoint: TestConfiguration.AzureOpenAI.ImageEndpoint,
        //            apiKey: TestConfiguration.AzureOpenAI.ImageApiKey,
        //            modelId: TestConfiguration.AzureOpenAI.ImageModelId,
        //            apiVersion: "2024-02-15-preview") //DALL-E 3 is only supported in this version
        //        .AddAzureOpenAIChatCompletion( // Add your chat completion service
        //            deploymentName: TestConfiguration.AzureOpenAI.ChatDeploymentName,
        //            endpoint: TestConfiguration.AzureOpenAI.Endpoint,
        //            apiKey: TestConfiguration.AzureOpenAI.ApiKey);

        //    builder.Services.ConfigureHttpClientDefaults(c =>
        //    {
        //        // Use a standard resiliency policy, augmented to retry 5 times
        //        c.AddStandardResilienceHandler().Configure(o =>
        //        {
        //            o.Retry.MaxRetryAttempts = 5;
        //            o.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(60);
        //        });
        //    });

        //    var kernel = builder.Build();

        //    ITextToImageService dallE = kernel.GetRequiredService<ITextToImageService>();
        //    var imageDescription = "A cute baby sea otter";
        //    var image = await dallE.GenerateImageAsync(imageDescription, 1024, 1024);

        //    Console.WriteLine(imageDescription);
        //    Console.WriteLine("Image URL: " + image);

        //    /* Output:

        //    A cute baby sea otter
        //    Image URL: https://dalleproduse.blob.core.windows.net/private/images/....

        //    */

        //    Console.WriteLine("======== Chat with images ========");

        //    var chatGPT = kernel.GetRequiredService<IChatCompletionService>();
        //    var chatHistory = new ChatHistory(
        //        "You're chatting with a user. Instead of replying directly to the user" +
        //        " provide the description of an image that expresses what you want to say." +
        //        " The user won't see your message, they will see only the image. The system " +
        //        " generates an image using your description, so it's important you describe the image with details.");

        //    var msg = "Hi, I'm from Tokyo, where are you from?";
        //    chatHistory.AddUserMessage(msg);
        //    Console.WriteLine("User: " + msg);

        //    var reply = await chatGPT.GetChatMessageContentAsync(chatHistory);
        //    chatHistory.Add(reply);
        //    image = await dallE.GenerateImageAsync(reply.Content!, 1024, 1024);
        //    Console.WriteLine("Bot: " + image);
        //    Console.WriteLine("Img description: " + reply);

        //    msg = "Oh, wow. Not sure where that is, could you provide more details?";
        //    chatHistory.AddUserMessage(msg);
        //    Console.WriteLine("User: " + msg);

        //    reply = await chatGPT.GetChatMessageContentAsync(chatHistory);
        //    chatHistory.Add(reply);
        //    image = await dallE.GenerateImageAsync(reply.Content!, 1024, 1024);
        //    Console.WriteLine("Bot: " + image);
        //    Console.WriteLine("Img description: " + reply);

        //    /* Output:

        //    User: Hi, I'm from Tokyo, where are you from?
        //    Bot: https://dalleproduse.blob.core.windows.net/private/images/......
        //    Img description: [An image of a globe with a pin dropped on a location in the middle of the ocean]

        //    User: Oh, wow. Not sure where that is, could you provide more details?
        //    Bot: https://dalleproduse.blob.core.windows.net/private/images/......
        //    Img description: [An image of a map zooming in on the pin location, revealing a small island with a palm tree on it]

        //    */
        //}

    }
}
