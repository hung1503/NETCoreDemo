namespace NETCore.Services;

public interface IChatGPTService
{
    string GetSuggestion(string message);
}