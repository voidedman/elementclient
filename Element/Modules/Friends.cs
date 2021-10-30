#region

using System;
using System.Threading;
using Microsoft.VisualBasic;
using Element.ClientBase;

#endregion

namespace Element.Modules
{
    internal class Friends : Module
    {
        public Friends() : base("Friends", (char)0x07)
        {
        } // Not defined

        public override Element OnEnable()
        {
            new Thread(() =>
            {
                var ElementAction = Interaction.InputBox("Please enter action (remove/add/list)", "Element (Friends)")
                    .ToLower();

                if (ElementAction == "list")
                {
                    foreach (var str in Game.CustomDefines.friends)
                        Console.WriteLine(str);
                    return;
                }

                var username = Interaction.InputBox("Please enter player username", "Element (Friends)").ToLower();

                if (ElementAction != "remove")
                {
                    if (ElementAction != "add") return;
                    Game.CustomDefines.friends.Add(username);
                    return;
                }

                for (var index = 0; index < Game.CustomDefines.friends.Count; index++)
                {
                    var str = Game.CustomDefines.friends[index];
                    if (username == str)
                        Game.CustomDefines.friends.Remove(str);
                }
            }).Start();
        }
    }
}