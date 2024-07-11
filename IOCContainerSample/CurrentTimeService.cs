namespace IOCContainerSample
{
    public class CurrentTimeService : ITimeService
    {
        private DateTime now = DateTime.Now;

        public string ShowTime()
        {
            return $"Es ist jetzt so spaet: {now.Hour}:{now.Minute}:{now.Second}";
        }
    }
}
