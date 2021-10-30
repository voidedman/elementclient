#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class Hitbox : Module
    {
        public Hitbox() : base("Hitbox", (char)0x07, "Combat")
        {
        } // 0x07 = no keybind

        public override Element OnTick()
        {
            if (Game.isNull) return;
            foreach (var entity in Game.getPlayers()) entity.hitbox = Base.Vec2(7, 7);
        }

        public override Element OnDisable()
        {
            base.OnDisable();

            foreach (var entity in Game.getPlayers()) entity.hitbox = Base.Vec2(0.6f, 1.8f);
        }
    }
}