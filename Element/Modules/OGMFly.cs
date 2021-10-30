﻿#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.ClientBase.VersionBase;

#endregion

namespace Element.Modules
{
    internal class OGMFly : Module
    {
        public OGMFly() : base("OGMFly", (char)0x07, "Flies")
        {
        } // Not defined

        public override Element OnEnable()
        {
            base.OnEnable();

           
        }

        public override Element OnTick() // hopefully some people remember this fly
        {
            if (Game.isNull) return;

            var speedMod = 0.7f;
            var calcYaw = (Game.bodyRots.y + 90f) * ((float)Math.PI / 180f);

            var newVel = Base.Vec3();

            newVel.x = (float)Math.Cos(calcYaw) * speedMod;
            newVel.y = 0.075f * speedMod;
            if (Keymap.GetAsyncKeyState(Keys.LShiftKey) || Keymap.GetAsyncKeyState(Keys.RShiftKey))
                newVel.y = -(0.05f * speedMod);
            newVel.z = (float)Math.Sin(calcYaw) * speedMod;

            Game.velocity = newVel;
        }

        public override Element OnDisable()
        {
            base.OnDisable();

            Game.velocity = Base.Vec3();
        }
    }
}