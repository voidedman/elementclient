#region

using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Zoom : Module
    {
        public Zoom() : base("Zoom", 'C', "Visual")
        {
            addBypass(new BypassBox(new string[] { "Minus 0.8", "Minus 1" }));
            Keymap.keyEvent += KeyvE;
        } // Not defined

        private Element KeyvE(object sender, KeyEvent e)
        {
            if (e.vkey != VKeyCodes.KeyUp) return;
            if ((char)(int)e.key == keybind) OnDisable(); // Disable module when keybind has been let go
        }

        public override Element OnEnable()
        {
            if (bypasses[0].curIndex == 0)
                Game.setFieldOfView(0.2f);
            if (bypasses[0].curIndex == 1)
                Game.setFieldOfView(0f);

            base.OnEnable();
        }

        public override Element OnDisable()
        {
            Game.resetFieldOfView();

            base.OnDisable();
        }
    }
}