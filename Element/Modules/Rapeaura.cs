#region

using Element.ClientBase;
using Element.ClientBase.KeyBase;

#endregion

namespace Element.Modules
{
    internal class Rapeaura : Module
    {
        public Rapeaura() : base("Rapeaura", (char)0x07, "Combat")
        {
        } // Not defined

        public override Element OnTick()
        {
            if (Game.isNull) return;

            var plr = Game.getClosestPlayer();
            if (Game.position.Distance(plr.position) < 6f)
                Game.SexActor(plr);

            if (Game.isLookingAtEntity && MCM.isMinecraftFocused())
                Mouse.MouseEvent(Mouse.MouseEventFlags.MOUSEEVENTF_LEFTDOWN);
        }
    }
}