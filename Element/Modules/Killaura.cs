#region

using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Killaura : Module
    {
        public Killaura() : base("Killaura", (char)0x07, "Combat")
        {
            addBypass(new BypassBox(new string[] { "Mobaura: False", "Mobaura: True" }));
        }

        public override Element OnTick()
        {
            var list = Game.getPlayers();
            if (bypasses[0].curIndex == 1)
                list = Game.getEntites();
            foreach (var ent in list)
                if (Game.position.Distance(ent.position) < 6f)
                    ent.hitbox = Base.Vec2(7f, 7f);
                else ent.hitbox = Base.Vec2(0.6f, 1.8f);

            if (Game.isLookingAtEntity && MCM.isMinecraftFocused())
                Mouse.MouseEvent(Mouse.MouseEventFlags.MOUSEEVENTF_LEFTDOWN);
        }
    }
}