#region

using Element.ClientBase;
using Element.ClientBase.VersionBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Glide : Module
    {
        public Glide() : base("Glide", (char)0x07, "Player")
        {
            addBypass(new BypassBox(new string[] { "Element", "Horion", "None" }));
        } // Not defined

        public override Element OnTick()
        {
            if (Game.isNull) return;

            if (bypasses[0].curIndex == 0)
                MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, -0.01f);
            if (bypasses[0].curIndex == 1)
                MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, -0.1f);
            if (bypasses[0].curIndex == 2)
                MCM.writeFloat(Game.localPlayer + VersionClass.GetData("velocity") + 4, 0f);
        }
    }
}