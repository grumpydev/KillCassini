namespace StevenRobbins.KillCassini.Helpers
{
    using System;
    using System.Runtime.InteropServices;

    using Microsoft.VisualStudio.OLE.Interop;

    public static class TrayHelpers
    {
// ReSharper disable InconsistentNaming
        private const UInt32 WM_MOUSEMOVE = 0x0200;
// ReSharper restore InconsistentNaming

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        private static IntPtr FindWindowEx(string lpszClass)
        {
            return FindWindowEx(IntPtr.Zero, IntPtr.Zero, lpszClass, string.Empty);
        }

        private static IntPtr FindWindowEx(IntPtr parent, string lpszClass)
        {
            return FindWindowEx(parent, IntPtr.Zero, lpszClass, string.Empty);
        }

        public static void RefreshTray()
        {
            // Native code ickyness so paranoid try catch :-)
            try
            {
                RECT r;

                var notificationArea = GetNotificationArea();

                GetClientRect(notificationArea, out r);

                for (var x = 0; x < r.right; x += 5)
                {
                    for (var y = 0; y < r.bottom; y += 5)
                    {
                        SendMessage(notificationArea, WM_MOUSEMOVE, IntPtr.Zero, new IntPtr((y << 16) + x));
                    }
                }
            }
// ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
// ReSharper restore EmptyGeneralCatchClause
            {
            }
        }

        private static IntPtr GetNotificationArea()
        {
            var shellTrayWnd = FindWindowEx("Shell_TrayWnd");

            var trayNotifyWnd = FindWindowEx(shellTrayWnd, "TrayNotifyWnd");

            var sysPager = FindWindowEx(trayNotifyWnd, "SysPager");

            return FindWindowEx(
                        sysPager,
                        IntPtr.Zero,
                        "ToolbarWindow32",
                        Resources.NotificationAreaTitle);
        }
    }
}