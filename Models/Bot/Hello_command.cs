using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AlkoBot.Models.Bot
{
    public class Hello_command : ICommand
    {
        public string Name => "Hello";

        public string Description => "Приветствует пользователя.";

        public async Task Execute(Message message, ITelegramBotClient botClient)
        {
            string username = message.From.Username;
            if (message.From.Username == null) username = "buddy";
            await botClient.SendTextMessageAsync(message.Chat.Id, $"Hello, <b>{username}</b>!", ParseMode.Html);
        }
    }
}
