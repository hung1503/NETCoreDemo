
namespace NETCore.Services;

public interface IEmailSenderService
{
    bool SendEmail(string to, string subject, string? body);
}