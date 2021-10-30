#region

using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Element.ClientBase;
using Element.ClientBase.UIBase;

#endregion

namespace Element.Modules
{
    internal class Teleport : Module
    {
        public Teleport() : base("Teleport", (char)0x07, "World")
        {
        } // Not defined

        public override Element OnEnable()
        {
            try
            {
                Overlay.handle.Invoke((MethodInvoker)delegate
                {

                    Overlay.handle.SuspendLayout();

                    foreach (Control ct in Overlay.handle.Controls)
                        if (Overlay.handle != null && (string)ct.Tag == "TeleportUI")
                            ct.Visible = true;

                    Overlay.handle.ResumeLayout();
                });
            }
            catch
            {
            }
        }

        public override Element OnDisable()
        {
            try
            {
                Overlay.handle.Invoke((MethodInvoker)delegate
                {

                    Overlay.handle.SuspendLayout();

                    foreach (Control ct in Overlay.handle.Controls)
                        if (Overlay.handle != null && (string)ct.Tag == "TeleportUI")
                            ct.Visible = false;

                    Overlay.handle.ResumeLayout();
                });
            }
            catch
            {
            }
        }
    }
}