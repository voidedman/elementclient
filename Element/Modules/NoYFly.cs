﻿#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;

#endregion

namespace Element.Modules
{
    internal class NoYFly : Module
    {
        public NoYFly() : base("NoYFly", (char)0x07, "Flies")
        {
        } // Not defined

        public override Element OnTick()
        {
            Game.onGround = true;

            Game.velocity = Base.Vec3();

            var newVel = Base.Vec3();

            var cy = (Game.bodyRots.y + 89.9f) * ((float)Math.PI / 180F);

            if (Keymap.GetAsyncKeyState((char)Keys.W))
                newVel.z = (float)Math.Sin(cy) * (8 / 9f); //Working Fly With No Height 


            if (Keymap.GetAsyncKeyState((char)Keys.W))
                newVel.x = (float)Math.Cos(cy) * (8 / 9f);
            Game.velocity = newVel;
        }
    }
}