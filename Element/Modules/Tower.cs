﻿using System;
using Element.ClientBase;
using Element.ClientBase.KeyBase;

namespace Element.Modules
{
    class Tower : Module
    {
        public Tower() : base("Tower", (char)0x07, "World") {
            Keymap.keyEvent += keyPress;
        }

        private Element keyPress(object sender, KeyEvent e)
        {
            if (e.vkey == vKeyCodes.KeyHeld)
            {
                if ((char)e.key == (char)0x02 && Game.heldItemCount > 0)
                {
                    if (Game.rotation.x < 80f && Game.isLookingAtBlock == 0)
                    {
                        Game.velocity = Base.Vec3(0, 0.5f);
                    }
                }
            }
        }
    }
}
