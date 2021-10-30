#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class HiveAntibot : Module
    {
        public HiveAntibot() : base("HiveAntibot", (char)0x07, "Other", false)
        {
        }

        public override Element OnEnable()
        {
            Game.CustomDefines.antibot = true;
            Game.CustomDefines.antibotStates = new bool[] { false, true }; // hive parser
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            Game.CustomDefines.antibot = false;
            base.OnDisable();
        }
    }
}