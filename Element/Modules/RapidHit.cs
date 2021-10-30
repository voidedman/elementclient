#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class RapidHit : Module
    {
        public RapidHit() : base("RapidHit", (char)0x07, "Combat")
        {
        }

        public override Element OnTick()
        {
            if (Game.isNull) return;

            Game.Hitting = 0;
        }
    }
}