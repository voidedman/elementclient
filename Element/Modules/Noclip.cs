#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class Noclip : Module
    {
        public Noclip() : base("Noclip", (char)0x07, "Exploits")
        {
        } // Not defined

        public override Element OnTick()
        {
            var pos = Game.position;
            var pos2 = Game.position;

            pos2.x += 0.6f;
            pos2.y -= 1.8f;
            pos2.z += 0.6f;

            Game.teleport(new AABB(pos, pos2));
        }

        public override Element OnDisable()
        {
            base.OnDisable();
            Game.teleport(Game.position);
        }
    }
}