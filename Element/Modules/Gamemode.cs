#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Gamemode : Module
    {
        public Gamemode() : base("Gamemode", (char)0x07, "Exploits")
        {
            addBypass(new BypassBox(new string[] { "Survival", "Creative", "Adventure" }));
        } // 0x07 = no keybind

        public override Element OnEnable()
        {
            base.OnEnable();
            Game.gamemode = bypasses[0].curIndex;
        }

        public override Element OnDisable()
        {
            base.OnDisable();
            Game.gamemode = 0;
        }
    }
}