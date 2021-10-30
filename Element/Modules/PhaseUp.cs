#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class PhaseUp : Module
    {
        public PhaseUp() : base("PhaseUp", (char)0x07, "Flies")
        {
            addBypass(new BypassBox(new string[] { "Default", "Fast", "Super Fast" }));
        } // Not defined

        public override Element OnTick()
        {
            Game.velocity = Base.Vec3();

            var newPos = Game.position;
            if (bypasses[0].curIndex == 0)
                newPos.y += 0.01f;
            if (bypasses[0].curIndex == 1)
                newPos.y += 0.01f;
            if (bypasses[0].curIndex == 2)
                newPos.y += 0.1f;
            Game.position = newPos;
        }
    }
}