#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class AirStuck : Module
    {
        public AirStuck() : base("AirStuck", (char)0x07, "Player")
        {
        } // 0x07 = no keybind

        public override Element OnTick()
        {
            if (!Game.isNull) Game.velocity = Base.Vec3();
        }
    }
}