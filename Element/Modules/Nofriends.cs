#region

using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class Nofriends : Module
    {
        public Nofriends() : base("Nofriends", (char)0x07)
        {
        }

        public override Element OnEnable()
        {
            Game.CustomDefines.nofriends = true;
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            Game.CustomDefines.nofriends = false;
            base.OnDisable();
        }
    }
}