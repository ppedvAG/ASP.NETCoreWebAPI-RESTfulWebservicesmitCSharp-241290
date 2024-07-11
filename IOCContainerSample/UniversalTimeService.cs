namespace IOCContainerSample
{
    public class UniversalTimeService : ITimeService
    {
        public string ShowTime()
        {
            var time = DateTime.Now.ToUniversalTime();
            return "Universal Time: " + time;
        }
    }
}
