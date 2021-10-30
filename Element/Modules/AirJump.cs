#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class AirJump : Module
    {
        public AirJump() : base("AirJump", (char)0x07, "World")
        {
            addBypass(new BypassBox(new string[] { "onGround: True", "onGround: False" }));
        }

        public override Element OnTick()
        {
            if (!Game.isNull)
                Game.onGround = (bypasses[0].curIndex != 0);
        }
    }
}