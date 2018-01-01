using System;
using Abp.Dependency;

namespace Don2018.PhonebookSpa.Timing
{
    public class AppTimes : ISingletonDependency
    {
        /// <summary>
        /// Gets the startup time of the application.
        /// </summary>
        public DateTime StartupTime { get; set; }
    }
}
