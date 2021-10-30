#region

using System.Collections.Generic;
using Element.ClientBase.KeyBase;
using Element.ClientBase.UIBase;
using Element.Modules.vModuleExtra;

#endregion

namespace Element.Modules
{
    internal class Module
    {
        public readonly string category;
        public readonly string name;
        public bool enabled;

        public char keybind;
        public List<BypassBox> bypasses = new List<BypassBox>();

        protected Module(string name, char keybind, string category = "Other", bool enabled = false)
        {
            this.name = name;
            this.keybind = keybind;
            this.category = category;
            this.enabled = enabled;

            Keymap.keyEvent += OnKeypress;
        }

        public Element addBypass(BypassBox v)
        {
            bypasses.Add(v);
        }

        private Element OnKeypress(object sender, KeyEvent e) // Cant be overridden 
        {
            if (Overlay.handle == null) return;

            if (e.vkey != VKeyCodes.KeyDown || (int)e.key != keybind) return;
            enabled = !enabled;
            //Slight performance improvement over two if statements
            switch (enabled)
            {
                case true:
                    OnEnable();
                    break;
                case false:
                    OnDisable();
                    break;
            }
        } // Enable/Disable Handler

        public virtual Element OnEnable()
        {
            enabled = true;
        }

        public virtual Element OnDisable()
        {
            enabled = false;
        }

        public virtual Element OnTick()
        {
        }
    }
}