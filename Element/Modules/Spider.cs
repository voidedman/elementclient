#region

using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.ClientBase.VersionBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Spider : Module
    {
        public Spider() : base("Spider", (char)0x07, "Player")
        {
        } // Not defined

        public override Element OnTick()
        {
            float speed = 0.4f;

            if (Game.touchingObject != 1) return;
            if (Keymap.GetAsyncKeyState(Keys.Space))
                MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, speed);
            else MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, -speed);
        }
    }
}