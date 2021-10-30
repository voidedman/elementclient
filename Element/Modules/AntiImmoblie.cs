#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class AntiImmoblie : Module
    {
        public AntiImmoblie() : base("AntiImmoblie", (char)0x07, "Exploits")
        {
        } // Not defined

        public override Element OnEnable()
        {
            MCM.writeBaseBytes(0x11EB1F0, MCM.ceByte2Bytes("90 90")); // nop anti immobile address
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            MCM.writeBaseBytes(0x11EB1F0, MCM.ceByte2Bytes("75 16")); // restore anti immobile address
            base.OnDisable();
        }
    }
}