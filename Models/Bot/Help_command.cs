using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AlkoBot.Models.Bot
{
    public class Help_command : ICommand
    {
        public string Name => "Help";

        public string Description => "Выводит памятку, описывающую основной функционал бота.";

        public async Task Execute(Message message, ITelegramBotClient botClient)
        {
            List<ICommand> commands = new List<ICommand>
            {
                new Hello_command(),
                new Help_command()
            };
            string text = "Тыкаешь кнопочки, пишешь текстик, пьешь коктейли.\n" +
                          "\n" +
                          "Текстовые команды:\n";
            foreach (ICommand c in commands)
                text += $"{c.Name} - {c.Description}\n";
            await botClient.SendTextMessageAsync(message.Chat.Id, text, ParseMode.MarkdownV2);
        }
    }
}
