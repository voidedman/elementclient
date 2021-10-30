#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Step : Module
    {
        public Step() : base("Step", (char)0x07, "Player")
        {
            addBypass(new BypassBox(new string[] { "Height: 1f", "Height: 2f" }));
        } // 0x07 = no keybind

        public override Element OnEnable()
        {
            base.OnEnable();

            switch (bypasses[0].curIndex)
            {
                case 0:
                    Game.stepHeight = 1f;
                    break;
                case 1:
                    Game.stepHeight = 2f;
                    break;
            }
        }

        public override Element OnDisable()
        {
            base.OnDisable();

            Game.stepHeight = .5f;
        }
    }
}