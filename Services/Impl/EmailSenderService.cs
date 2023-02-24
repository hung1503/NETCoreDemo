namespace NETCore.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly IChatGPTService _chatGPTService;
    
    public EmailSenderService(IChatGPTService chatGPTService)
    {
        _chatGPTService = chatGPTService;
    }
    public bool SendEmail(string to, string subject, string? body = null)
    {
        var emailBody = body;
        if(body == null)
        {
            emailBody = _chatGPTService.GetSuggestion(subject);
        }
        return true;
    }
}