﻿#region

using System;
using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Reach : Module
    {
        public Reach() : base("Reach", (char)0x07, "Combat")
        {
            addBypass(new BypassBox(new string[] { "Distance: 4", "Distance: 5", "Distance: 6", "Distance: 7" }));
        } // Not defined

        public override Element OnEnable()
        {
            switch (bypasses[0].curIndex)
            {
                case 0:
                    MCM.writeBaseFloat(0x365D848, 4);
                    break;
                case 1:
                    MCM.writeBaseFloat(0x365D848, 5);
                    break;
                case 2:
                    MCM.writeBaseFloat(0x365D848, 6);
                    break;
                case 3:
                    MCM.writeBaseFloat(0x365D848, 7);
                    break;
            }

            /*
            
            3 - 00 00 40 40
            4 - 00 00 80 40
            5 - 00 00 A0 40
            6 - 00 00 C0 40
            7 - 00 00 E0 40

            */

            base.OnEnable();
        }

        public override Element OnDisable()
        {
            MCM.writeBaseFloat(0x365D848, 3);
            base.OnDisable();
        }
    }
}