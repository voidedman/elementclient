#region

using System.Linq;
using System.Threading;
using Microsoft.VisualBasic;
using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class PlayerTP : Module
    {
        public PlayerTP() : base("PlayerTP", (char)0x07, "Exploits")
        {
        } // Not defined

        public override Element OnEnable()
        {
            new Thread(() =>
            {
                var username = Interaction.InputBox("Please enter player username", "Element (PlayerTP)").ToLower();

                foreach (var entity in Game.getPlayers().Where(entity => entity.username.ToLower().Contains(username)))
                {
                    Game.position = entity.position;
                    break;
                }
            }).Start();
        }
    }
}