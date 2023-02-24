namespace NETCore.Services;

public class FakeEmailSenderService : IEmailSenderService
{
    private readonly IChatGPTService _chatGPTService;
    private readonly ILogger<FakeEmailSenderService> _logger;
    public FakeEmailSenderService(IChatGPTService chatGPTService, ILogger<FakeEmailSenderService> logger)
    {
        _chatGPTService = chatGPTService;
        _logger = logger;
    }
    public bool SendEmail(string to, string subject, string? body = null)
    {   
        _logger.LogInformation($"sending email to {to}, subject: {subject}");
        return true;
    }
}