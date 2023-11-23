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

        bool goodbye = false;
        ChatCompletionsOptions completionsOptions = new()
        {
            MaxTokens = s.MaxTokens,
            Temperature = s.Temperature,
            FrequencyPenalty = s.FrequencyPenalty,
            PresencePenalty = s.PresencePenalty,
            // Messages =
            // {
            //     new(ChatRole.System, s.SystemPrompt)
            // }
            DeploymentName = "gpt-35-turbo"

        };

        WriteAssistantMessage("Beep, boop, I'm .DotNetBot and I'm here to help. If you're done say goodbye.", newLine: true);

        string proxyUrl = "https://aoai.hacktogether.net";
        string key = "f118ca66-2ad3-443a-ad27-cf6ee37bcdba";

        // the full url is appended by /v1/api
        Uri _ = new
        (proxyUrl + "/v1/api");

        // the full key is appended by "/YOUR-GITHUB-ALIAS"
        AzureKeyCredential token = new(key + "/YOUR-GITHUB-ALIAS");

        // instantiate the client with the "full" values for the url and key/token
        // OpenAIClient openAIClient = new(_, token);

        // ChatCompletionsOptions completionsOptions = new()
        // {
        //     MaxTokens = 2048,
        //     Temperature = 0.7f,
        //     NucleusSamplingFactor = 0.95f,
        //     DeploymentName = "gpt-35-turbo"
        // };
        System.Console.WriteLine("if u want ur chatbot,customization please enter details here:");
        var customization = Console.ReadLine() ?? "you are a helpful bot to appropriate  answers to others, and your name is ByteBot";

        completionsOptions.Messages.Add(new ChatMessage(ChatRole.System, customization));
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
