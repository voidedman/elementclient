﻿#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;

#endregion

namespace Element.Modules
{
    internal class Masturbator : Module
    {
        private static int _flicker;

        private static Random ran = new Random(); // dont wanna waste resources on random too much dont we lol

        public Masturbator() : base("Masturbator", (char)0x07, "World") // derp
        {
        } // 0x07 = no keybind

        public override Element OnTick()
        {
            if (Game.isNull) return;
            _flicker++;

            Game.bodyRots = new Vector2(ran.Next(-180, 180), ran.Next(-180, 180));

            if (_flicker == 16)
            {
                _flicker = 0;
                Game.swing();
            }
        }
    }
}