using System.Windows.Forms;

namespace Element.Modules
{
    internal class Eject : Module
    {
        public Eject() : base("Eject", (char)0x07)
        {
        } // Not defined

        public override Element OnEnable()
        {
            Program.quit = true;
            Application.Exit(); // ?
        }
    }
}