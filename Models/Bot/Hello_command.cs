using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AlkoBot.Models.Bot
{
    public class Hello_command : ICommand
    {
        public string Name => "hello";

        public string Description => "Приветствует пользователя.";

        public async Task Execute(Message message, ITelegramBotClient botClient)
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Hello!", ParseMode.MarkdownV2);
        }
    }
}
