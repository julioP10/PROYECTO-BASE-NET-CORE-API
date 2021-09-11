namespace Infraestructure.Crosscutting.Enums
{
    public enum ProcessChangeType
    {
        Processing = 1,
        Success = 2,
        Error = 3,
        Canceled = 4,
        Omited = 5,
        Paused = 6,
        Resumed = 7,
        RequestConfirmation = 8,
        AskParameter = 9,
        ShowingInformation = 10
    }
}