using System.Collections.Generic;
using System.Linq;

namespace AlkoBot.Models.Bot
{
    public static class Commands
    {
        public static List<ICommand> CommandsList { get; set; }

        static Commands()
        {
            CommandsList = new List<ICommand>();
            CommandsList.Add(new Start_command());
            CommandsList.Add(new Help_command());
            CommandsList.Add(new Cocktails_command());
        }

        public static ICommand GetCommand(string name)
        {
            var command = CommandsList.First(x => x.Name == name);
            return command;
        }
    }
}
