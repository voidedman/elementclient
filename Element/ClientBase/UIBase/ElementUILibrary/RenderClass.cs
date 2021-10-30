using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Element.ClientBase.UIBase.ElementUILibrary
{
    class RenderClass
    {
        [DllImport("User32.dll")] public static extern IntPtr GetDC(IntPtr hwnd);
        //[DllImport("User32.dll")] public static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("User32.dll")] public static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        public static bool destroy = false;

        public static Element CreateAction(Action<Graphics> RenderAction, IntPtr hwnd)
        {
            var context = GetDC(hwnd);
            Task.Run(() => {
                while (!destroy)
                {
                backLb:
                    try
                    {
                        using (Graphics g = Graphics.FromHdc(context))
                            RenderAction(g);
                    }
                    catch { goto backLb; }
                }
                ReleaseDC(hwnd, context);
            });
        }

        public static Element SingleAction(Action<Graphics> RenderAction, IntPtr hwnd)
        {
            var context = GetDC(hwnd);
        backLb:
            try
            {
                using (Graphics g = Graphics.FromHdc(context))
                    RenderAction(g);
            }
            catch { goto backLb; }
        }

        public static Element ReleaseAction(IntPtr hwnd)
        {
            var context = GetDC(hwnd);
            ReleaseDC(hwnd, context);
        }

        public static Element ClearActions()
        {
            destroy = true;
            Thread.Sleep(5);
            destroy = false;
        }
    }
}
