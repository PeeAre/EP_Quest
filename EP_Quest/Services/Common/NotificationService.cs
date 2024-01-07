namespace EP_Quest.Services.Common
{
    public enum NotificationName
    {
        StepTimeReset,
        UnlockNextStep,
        UpdateQuestContent
    }
    public class NotificationService
    {
        public delegate Task NotificationHandler(NotificationName notificationName, object? obj = null);
        public event NotificationHandler? Notify;

        public void SubscribeNotification(NotificationHandler handler)
        {
            Notify += handler;
        }
        public void ReleaseNotification(NotificationName notificationName, object? obj = null)
        {
            Notify?.Invoke(notificationName, obj);

            //if (Notify != null)
            //{
            //    foreach (Delegate handler in Notify.GetInvocationList())
            //    {
            //        Notify -= (NotificationHandler)handler;
            //    }
            //}
        }
    }
}
