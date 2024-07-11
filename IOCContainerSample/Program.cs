using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceContainer = RegisterTypes();

            var serviceProvider = serviceContainer.BuildServiceProvider();
            var timeService = serviceProvider.GetRequiredService<ITimeService>();

            var currentTime = timeService.ShowTime();
            Console.WriteLine(currentTime);
        }

        // Einmal beim Startup der Anwendung werden alle verfuegbaren Dienste registriert.
        private static ServiceCollection RegisterTypes()
        {
            var serviceContainer = new ServiceCollection();

            // Wir registrieren die konkrete Implementierung des Service gegen das Interface ITimeService.
            serviceContainer.AddScoped<ITimeService, CurrentTimeService>();

            // Hier wird die vorherige Registrierung mit einer anderen Implementierung ersetzt.
            serviceContainer.AddScoped<ITimeService, UniversalTimeService>();

            return serviceContainer;
        }
    }
}
