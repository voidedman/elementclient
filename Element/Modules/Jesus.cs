#region

using Element.ClientBase;
using Element.ClientBase.VersionBase;

#endregion

namespace Element.Modules
{
    internal class Jesus : Module
    {
        public Jesus() : base("Jesus", (char)0x07, "Player")
        {
        } // Not defined

        public override Element OnTick()
        {
            if (Game.isNull) return;

            if (Game.isInWater || Game.isInLava)
            {
                MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, 0.01f);
                Game.onGround = true;
            }
        }
    }
}