#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;

#endregion

namespace Element.Modules
{
    internal class FixHitbox : Module
    {
        public FixHitbox() : base("FixHitbox", (char)0x07, "Others")
        {
        } // 0x07 = no keybind

        public override Element OnEnable()
        {
            base.OnEnable();

            Game.teleport(Game.position);
        }
    }
}