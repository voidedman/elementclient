#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class RapidPlace : Module
    {
        public RapidPlace() : base("RapidPlace", (char)0x07, "Player")
        {
        }

        public override Element OnTick()
        {
            if (Game.isNull) return;

            Game.Placing = 0;
        }
    }
}