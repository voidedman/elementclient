#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.ClientBase.VersionBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class MineplexStep : Module
    {
        public MineplexStep() : base("MineplexStep", (char)0x07, "Player")
        {
            addBypass(new BypassBox(new string[] { "Default", "Fast", "Super Slow", "Slow" }));
        } // Not defined

        public override Element OnTick()
        {
            float speed = 0.4f;

            if (Game.walkingIntoBlock != 1) return;

            switch (bypasses[0].curIndex)
            {
                case 0:
                    speed = 0.4f;
                    break;
                case 1:
                    speed = 0.6f;
                    break;
                case 2:
                    speed = 0.1f;
                    break;
                case 3:
                    speed = 0.2f;
                    break;
            }

            MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, speed);
        }
    }
}