#region

using Element.ClientBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class StreamMode : Module
    {
        public StreamMode() : base("StreamMode", (char)0x07, "World")
        {
            storedusr = Game.username;
        } // 0x07 = no keybind

        string storedusr = "null";

        public override Element OnEnable()
        {
            base.OnEnable();
            storedusr = Game.username;
            Game.username = "ElementExploiter";
        }

        public override Element OnDisable()
        {
            base.OnDisable();
            Game.username = storedusr;
        }
    }
}