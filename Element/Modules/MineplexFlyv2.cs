#region

using System;
using System.Windows.Forms;
using Element.ClientBase;
using Element.ClientBase.KeyBase;
using Element.ClientBase.UIBase;
using Element.ClientBase.VersionBase;

#endregion

namespace Element.Modules
{
    internal class MineplexFlyv2 : Module
    {
        public MineplexFlyv2() : base("BhopFlight", (char)0x07, "Flies")
        {
        } // Not defined

        public override Element OnEnable()
        {
            foreach (Module mod in Program.Modules)
                if (mod.name == "MineplexFly" || mod.name == "Bhop")
                    mod.OnEnable();
            base.OnEnable();
        }

        public override Element OnDisable()
        {
            foreach (Module mod in Program.Modules)
                if (mod.name == "MineplexFly" || mod.name == "Bhop")
                    mod.OnDisable();
            base.OnDisable();
        }
    }
}