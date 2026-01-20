namespace Web.Services
{
    public class NotificationService
    {
        public int RequestCount { get; private set; } = 0;

        
        public event Action OnChange;

        public void AddRequest()
        {
            RequestCount++;
            NotifyStateChanged();
        }

        public void ClearRequests()
        {
            RequestCount = 0;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
