#region

using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.ClientBase.VersionBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class HighJump : Module
    {
        public HighJump() : base("HighJump", (char)0x07, "Player")
        {
            //addBypass(new BypassBox(new string[] { "Default", "High", "Super Low", "Low" }));
        } // 0x07 = no keybind

        public override Element OnTick()
        {
            if (Game.isNull) return;

            if (Keymap.GetAsyncKeyState(Keys.Space) && Game.onGround == true)
            {
                MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, 0.8f);
            }
        }
    }
}