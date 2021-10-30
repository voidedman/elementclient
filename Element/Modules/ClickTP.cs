#region

using Element.ClientBase;
using Element.ClientBase.KeyBase;

#endregion

namespace Element.Modules
{
    internal class ClickTP : Module
    {
        public ClickTP() : base("ClickTP", (char)0x07, "Exploits")
        {
            Keymap.keyEvent += KeyPress;
        }

        private Element KeyPress(object sender, KeyEvent e)
        {
            if (e.vkey != VKeyCodes.KeyDown) return;
            if (!enabled) return;
            if (e.key.ToString() != "MButton") return;
            var ivec = Game.SelectedBlock;
            var newPos = Base.Vec3(ivec.x, ivec.y + 1, ivec.z);
            Game.position = newPos;
        }
    }
}