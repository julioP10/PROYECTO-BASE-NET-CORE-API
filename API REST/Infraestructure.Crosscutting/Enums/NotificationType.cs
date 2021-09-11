namespace Infraestructure.Crosscutting.Enums
{
    public enum NotificationType
    {
        Start = 1,
        ProcessChange = 2,
        End = 3,
        Cancel = 4,
        Retry = 5,
        AskParameter = 6,
        ReceiveParameter = 7,
        Omit = 8,
        RequestConfirmation = 9,
        ReceiveConfirmation = 10,
        ProcessStart = 11,
        ProcessEnd = 12,
        ExecutionError = 13,
        ExecutionLog = 14,
        Reprocess = 15,
        ReprocessStart = 16,
        ReprocessEnd = 17,
        PauseResume = 18
    }
}
