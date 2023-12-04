using Azure;
using Azure.AI.OpenAI;
using craftyBuilder.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text;

namespace craftyBuider.Infrastructure.Ai;

public class AIService : IHostedService, IAiService
{
    private readonly IHostApplicationLifetime lifetime;
    private readonly OpenAIClient _openAIClient;
    private readonly IOptions<Settings> settings;

    private string message = "";
    private string responsefromAi = "";
    private bool isInternalCommunication = false;

    public AIService(IHostApplicationLifetime lifetime, OpenAIClient openAIClient, IOptions<Settings> settings)
    {
        this.lifetime = lifetime;
        this._openAIClient = openAIClient;
        this.settings = settings;
    }



    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Settings s = settings.Value;

        ChatCompletionsOptions completionsOptions = new()
        {
            MaxTokens = s.MaxTokens,
            Temperature = s.Temperature,
            FrequencyPenalty = s.FrequencyPenalty,
            PresencePenalty = s.PresencePenalty,
            DeploymentName = "gpt-35-turbo"
        };

        var customization = "Please limit your responses to only the information I request. Do not provide any additional information or engage in any unnecessary conversation";

        // completionsOptions.Messages.Add(new ChatMessage(ChatRole.System, customization));
        // completionsOptions.Messages.Add(new ChatMessage(ChatRole.Assistant, customization));

        completionsOptions.Messages.Add(new ChatMessage(ChatRole.User, message));

        var response = await _openAIClient.GetChatCompletionsAsync(completionsOptions, cancellationToken);

        try
        {
            ChatCompletions chatCompletions = response.Value;

            foreach (ChatChoice choice in chatCompletions.Choices)
            {
                string content = choice.Message.Content;
                if (!isInternalCommunication)
                {
                    System.Console.WriteLine($"{content}");
                    Console.ReadKey();
                }
                responsefromAi = content;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"Error: {e}: {response}");
        }
        lifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public async Task<string> SendMessageAsync(string m, bool isInternalCommunication)
    {
        message = m;
        this.isInternalCommunication = isInternalCommunication;
        CancellationToken ct = CancellationToken.None;
        await StartAsync(ct);
        return responsefromAi;
    }

}
