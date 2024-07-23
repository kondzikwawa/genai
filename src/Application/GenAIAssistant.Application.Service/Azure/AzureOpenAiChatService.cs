using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
namespace GenAIAssistant.Application.Service.Azure;

public class AzureOpenAiChatService
{
    private IChatCompletionService _chatCompletionService;
    private ChatHistory _history;
    private Kernel _kernel;

    public AzureOpenAiChatService() 
    {
        // Create a kernel with Azure OpenAI chat completion
        var builder = Kernel.CreateBuilder().AddAzureOpenAIChatCompletion("modelId", "endpoint", "apiKey");

        // Build the kernel
        _kernel = builder.Build();
        _chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();

        // Create a history store the conversation
        _history = new ChatHistory();
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
                kernel: _kernel);

            _history.AddMessage(chatMessageContent.Role, chatMessageContent.Content ?? string.Empty);
        }

        return chatMessageContent;
    }
}
