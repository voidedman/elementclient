#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class FlickerExample : Module
    {
        private int _flicker;

        public FlickerExample() : base("FlickerExample", (char)0x07)
        {
        } // 0x07 = no keybind

        public override Element OnTick()
        {
            if (Game.isNull) return;
            _flicker++;

            if (_flicker != 300) return;
            _flicker = 0;

        }
    }
}