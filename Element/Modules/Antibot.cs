#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class Antibot : Module
    {
        public Antibot() : base("Antibot", (char)0x07, "Other", true)
        {
        }

        public override Element OnEnable()
        {
            Game.CustomDefines.antibot = true;
            Game.CustomDefines.antibotStates = new bool[] { true, false }; // default parser fixed
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            Game.CustomDefines.antibot = false;
            base.OnDisable();
        }
    }
}
