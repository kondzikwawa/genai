using Azure.AI.OpenAI;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace GenAIAssistant.Application.Service.Azure;

public class AzureOpenAiChatWithInternalDocuments
{
    private IChatCompletionService _chatCompletionService;
    private ChatHistory _history;
    private Kernel _kernel;
    private OpenAIPromptExecutionSettings _promptExecutionSettings;

    public AzureOpenAiChatWithInternalDocuments() 
    {
        // Create a kernel with Azure OpenAI chat completion
        var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion("modelId", "endpoint", "apiKey");

        // Build the kernel
        _kernel = builder.Build();
        _chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

        // Create a history store the conversation
        _history = new ChatHistory();

        var azureSearchExtensionConfiguration = new AzureSearchChatExtensionConfiguration
        {
            SearchEndpoint = new Uri("some endpoint"),
            Authentication = new OnYourDataApiKeyAuthenticationOptions(Environment.GetEnvironmentVariable("AZURE_AI_SEARCH_API_KEY")),
            IndexName = Environment.GetEnvironmentVariable("AZURE_AI_SEARCH_INDEX")
        };

        var chatExtensionsOptions = GetAzureChatExtensionsOptions();
#pragma warning disable SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            _promptExecutionSettings = new OpenAIPromptExecutionSettings { AzureChatExtensionsOptions = chatExtensionsOptions };
#pragma warning restore SKEXP0010 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

    public async Task<ChatMessageContent?> Chat(string input)
    {
        ChatMessageContent? chatMessageContent = null;

        if (!string.IsNullOrWhiteSpace(input))
        {
            _history.AddUserMessage(input);

            // Get the response from the AI
            chatMessageContent = await _chatCompletionService.GetChatMessageContentAsync(
            _history,
                kernel: _kernel, executionSettings: _promptExecutionSettings);

            _history.AddMessage(chatMessageContent.Role, chatMessageContent.Content ?? string.Empty);
        }

        return chatMessageContent;
    }

    private static AzureChatExtensionsOptions GetAzureChatExtensionsOptions()
    {
        var azureSearchExtensionConfiguration = new AzureSearchChatExtensionConfiguration
        {
            SearchEndpoint = new Uri("TestConfiguration.AzureAISearch.Endpoint"),
            Authentication = new OnYourDataApiKeyAuthenticationOptions("TestConfiguration.AzureAISearch.ApiKey"),
            IndexName = "TestConfiguration.AzureAISearch.IndexName"
        };

        return new AzureChatExtensionsOptions
        {
            Extensions = { azureSearchExtensionConfiguration }
        };
    }

}
