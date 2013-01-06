namespace StevenRobbins.KillCassini.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class ProcessHelpers
    {
        private static readonly string[] processNames = new[] { "WebDev.WebServer40", "WebDev.WebServer20" };

        public static IEnumerable<Process> GetCassiniProcesses()
        {
            return processNames.SelectMany(Process.GetProcessesByName);
        }

        public static bool KillProcess(Process process)
        {
            try
            {
                process.Kill();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}