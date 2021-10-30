#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class CreativeFly : Module
    {
        public CreativeFly() : base("CreativeFly", (char)0x07, "Flies")
        {
            addBypass(new BypassBox(new string[] { "IsFlying: True", "IsFlying: False" }));
        } // Not defined

        public override Element OnTick()
        {
            Game.isFlying = (bypasses[0].curIndex == 0);
        }

        public override Element OnDisable()
        {
            base.OnDisable();

            Game.isFlying = false;
        }
    }
}