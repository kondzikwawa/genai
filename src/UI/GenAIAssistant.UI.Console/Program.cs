// See https://aka.ms/new-console-template for more information
using GenAIAssistant.Application.Service.Azure;

Console.WriteLine("Hello, World!");

AzureOpenAiChatService azureOpenAiChatService = new AzureOpenAiChatService();

var result = await azureOpenAiChatService.Chat("who is the prime minister in PL?");
