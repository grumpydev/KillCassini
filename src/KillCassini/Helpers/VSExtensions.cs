namespace StevenRobbins.KillCassini.Helpers
{
    using Microsoft.VisualStudio.Shell.Interop;

    public static class VsExtensions
    {
        private const string Prefix = "[KillCassini] ";

        public static void WriteLine(this IVsOutputWindowPane pane, string formatString, params object[] parameters)
        {
            pane.Write(formatString + "\n", parameters);
        }
 
        public static void Write(this IVsOutputWindowPane pane, string formatString, params object[] parameters)
        {
            pane.OutputString(string.Format(Prefix + formatString, parameters));
        }
    }
}