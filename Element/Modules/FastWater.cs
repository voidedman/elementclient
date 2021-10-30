#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class FastWater : Module
    {
        public FastWater() : base("FastWater", (char)0x07, "Player")
        {
        } // Not defined

        public override Element OnTick()
        {
            if(Game.isInWater || Game.isInLava)
            {
                var newVel = Game.velocity;

                var cy = (Game.bodyRots.y + 89.9f) * ((float)Math.PI / 180F);

                newVel.z = (float)Math.Sin(cy) * 2f;
                newVel.y = 0.01f;
                newVel.x = (float)Math.Cos(cy) * 2f;

                Game.velocity = newVel;
            }
        }
    }
}