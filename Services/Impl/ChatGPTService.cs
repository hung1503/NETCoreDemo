namespace NETCore.Services;

public class ChatGPTService: IChatGPTService
{
    private readonly ILogger<ChatGPTService> _logger;
    public ChatGPTService(ILogger<ChatGPTService> logger)
    {
        _logger = logger;
    }
    public string GetSuggestion(string message)
    {
        _logger.LogInformation("Connecting to GPT service");
        return message;
    }
}