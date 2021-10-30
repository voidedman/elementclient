﻿namespace Element.Modules
{
    internal class Limiter : Module
    {
        public Limiter() : base("Limiter", (char)0x07)
        {
        }

        public override Element OnEnable()
        {
            Program.limiter = true;
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            Program.limiter = false;
            base.OnDisable();
        }
    }
}