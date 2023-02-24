namespace NETCore.Services;

public interface ICounterService
{
    int CurrentValue { get; }
    void Increase();
}