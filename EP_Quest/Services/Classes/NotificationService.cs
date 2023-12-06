namespace EP_Quest.Services.Classes
{
    public enum NotificationName
    {
        PageLoaded
    }
    public class NotificationService
    {
        public delegate void NotificationHandler(NotificationName notificationName);
        public event NotificationHandler? Notify;

        public void SubscribeNotification(NotificationHandler handler)
        {
            Notify += handler;
        }
        public void ReleaseNotification(NotificationName notificationName)
        {
            Notify?.Invoke(notificationName);

            if (Notify != null)
            {
                foreach (Delegate handler in Notify.GetInvocationList())
                {
                    Notify -= (NotificationHandler)handler;
                }
            }
        }
    }
}
