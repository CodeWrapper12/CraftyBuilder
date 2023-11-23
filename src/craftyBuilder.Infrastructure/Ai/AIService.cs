using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text;

namespace craftyBuider.Infrastructure.Ai;

public class AIService : IHostedService
{
    private readonly IHostApplicationLifetime lifetime;
    private readonly OpenAIClient _openAIClient;
    private readonly IOptions<Settings> settings;

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

        WriteAssistantMessage("Beep, boop, I'm .DotNetBot and I'm here to help. If you're done say goodbye.", newLine: true);
        var customization = @"When the user mentions their desired application framework (e.g., .NET, React, or Angular), identify the available application types that can be created using that framework.
Based on the user's system configuration, determine the feasibility of creating each identified application type.
Filter out any application types that are not feasible due to system limitations.
Present the user with a list of the remaining feasible application types, along with a brief description of each.
If the user asks a question that is not directly related to creating an application, respond with ""I don't have much knowledge on that topic.""
When responding with a list of feasible application types, format the response as an object with the following structure: {
  ""success"": true,
  ""data"": [
    ""dotnet console"",
    ""dotnet web app"",
    ...
  ]
}";

        completionsOptions.Messages.Add(new ChatMessage(ChatRole.System, customization));
        completionsOptions.Messages.Add(new ChatMessage(ChatRole.Assistant, customization));
        bool isActive = true;
        System.Console.WriteLine("if u want to quit enter goodbye");
        while (isActive)
        {
            System.Console.WriteLine("enter your question??");
            var msg = Console.ReadLine() ?? "";
            if (msg == "goodbye")
            {
                isActive = false;
                continue;
            }
            completionsOptions.Messages.Add(new ChatMessage(ChatRole.User, msg));

            var response = await _openAIClient.GetChatCompletionsAsync(completionsOptions, cancellationToken);
            try// Check if the request was successful
            {
                ChatCompletions chatCompletions = response.Value;

                // Access information from chatCompletions and print it
                foreach (ChatChoice choice in chatCompletions.Choices)
                {
                    string content = choice.Message.Content;
                    WriteAssistantMessage($"Assistant Response: {content}", newLine: true);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error: {e}: {response}");
            }

            System.Console.ReadKey();
        }


        lifetime.StopApplication();
    }

    private static void WriteAssistantMessage(string content, bool newLine = true)
    {
        ConsoleColor textColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        if (newLine)
        {
            Console.Out.WriteLine(content);
        }
        else
        {
            Console.Out.Write(content);
        }
        Console.ForegroundColor = textColor;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
