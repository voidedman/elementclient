#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class TPAura : Module
    {
        private int _flicker;

        public TPAura() : base("TPAura", (char)0x07, "Exploits")
        {
        } // Not defined

        public override Element OnTick()
        {
            if (Game.isNull) return;
            _flicker++;

            if (_flicker != 4) return;
            _flicker = 0;
            if (Game.isNull) return;
            _flicker++;

            if (_flicker != 300) return;
            _flicker = 0;
            Game.onGround = false;
        }
    }
}