#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class NoSwing : Module
    {
        public NoSwing() : base("NoSwing", (char)0x07, "Visual")
        {
        } // Not defined

        public override Element OnTick()
        {
            if (Game.isNull) return;

            Game.swingAn = 0;
        }
    }
}