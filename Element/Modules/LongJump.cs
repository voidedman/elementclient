using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.ClientBase.VersionBase;
using Element.Modules.vModuleExtra;

namespace Element.Modules
{
    internal class LongJump : Module
    {

        public LongJump() : base("LongJump", (char)0x07, "Player")
        {
            addBypass(new BypassBox(new string[] { "Hive", "Large", "Small" }));
        } // Not defined+-/9*9
        public override Element OnEnable()
        {
            switch (bypasses[0].curIndex)
            {
                case 0:
                    MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, 0.5f);
                    break;
                case 1:
                    MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, 0.7f);
                    break;
                case 2:
                    MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, 0.3f);
                    break;
            }
            base.OnEnable();
        }
        public override Element OnTick()
        {
            Vector3 newVel = Game.velocity;

            if (newVel.y > 0)
            {
                if (Game.onGround == false)
                {
                    newVel.x *= 1.1f;
                    newVel.y *= 1.06f;
                    newVel.z *= 1.1f;
                }
            }

            Game.velocity = newVel;
        }
    }
}
