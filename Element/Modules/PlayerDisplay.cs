#region

using System.Windows.Forms;
using Element.ClientBase.UIBase;

#endregion

namespace Element.Modules
{
    internal class PlayerDisplay : Module
    {
        public PlayerDisplay() : base("PlayerDisplay", (char)0x07, "Visual")
        {
        } // Not defined

        public override Element OnEnable()
        {
            base.OnEnable();
            foreach (Control ct in Overlay.handle.Controls)
                if (ct.Name == "panel1")
                    ct.Visible = true;
        }

        public override Element OnDisable()
        {
            base.OnDisable();
            foreach (Control ct in Overlay.handle.Controls)
                if (ct.Name == "panel1")
                    ct.Visible = false;
        }
    }
}