namespace Element.Modules
{
    internal class Unlimiter : Module
    {
        public Unlimiter() : base("Unlimiter", (char)0x07)
        {
        }

        public override Element OnEnable()
        {
            Program.unlimiter = true;
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            Program.unlimiter = false;
            base.OnDisable();
        }
    }
}