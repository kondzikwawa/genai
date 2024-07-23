using Azure.AI.OpenAI;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Memory;
using System;

namespace GenAIAssistant.Application.Service.Azure;

public class AzureOpenAiChatWithMemory
{

#pragma warning disable SKEXP0001, SKEXP0010, SKEXP0050, SKEXP0020

    private IChatCompletionService _chatCompletionService;
    private ChatHistory _history;
    private Kernel _kernel;
    private OpenAIPromptExecutionSettings _promptExecutionSettings;
    private ISemanticTextMemory _memory;

    public AzureOpenAiChatWithMemory() 
    {
        // Create a kernel with Azure OpenAI chat completion
        var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion("modelId", "endpoint", "apiKey");

        // Build the kernel
        _kernel = builder.Build();
        _chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();


        var memoryBuilder = new MemoryBuilder();

        memoryBuilder.WithAzureOpenAITextEmbeddingGeneration(
            "text-embedding-ada-002",
            "azureEndpoint",
            "apiKey",
            "model-id");


        memoryBuilder.WithMemoryStore(new VolatileMemoryStore());

        _memory = memoryBuilder.Build();
    }

    public async Task<string> Chat(string input)
    {
        string result = string.Empty;
        const string MemoryCollectionName = "aboutMe";

        await _memory.SaveInformationAsync(MemoryCollectionName, id: "info1", text: "My name is Andrea");
        await _memory.SaveInformationAsync(MemoryCollectionName, id: "info2", text: "I currently work as a tourist operator");
        await _memory.SaveInformationAsync(MemoryCollectionName, id: "info3", text: "I currently live in Seattle and have been living there since 2005");
        await _memory.SaveInformationAsync(MemoryCollectionName, id: "info4", text: "I visited France and Italy five times since 2015");
        await _memory.SaveInformationAsync(MemoryCollectionName, id: "info5", text: "My family is from New York");

        var response = _memory.SearchAsync(MemoryCollectionName, input, 1, 0.7);

        await foreach(var item in response)
        {
            result += item?.Metadata.Text;
        }

        return result;
    }
}
