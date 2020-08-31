using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace AlkoBot.Models.Bot
{
    /// <summary>
    /// Статический класс, содержащий команды бота
    /// </summary>
    public static class Commands
    {
        /// <summary>
        /// Приветствует пользователя.
        /// </summary>
        /// <returns></returns>
        public static Task Command_hello()
        {
            return null;
        }

        /// <summary>
        /// Выводит доступные комманды.
        /// </summary>
        /// <returns></returns>
        public static Task Command_commands()
        {
            Type type = Type.GetType("Models.Bot.Commands");
            string commands = "";
            string output = "";
            string command_name;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"AlkoBot.Xml");
            XmlNodeList nodeList;
            foreach (XmlNode member in doc.DocumentElement.SelectNodes("members"))
            {
                command_name = member.Name.Split('.').Last();
            }

            return null;
        }
    }
}
