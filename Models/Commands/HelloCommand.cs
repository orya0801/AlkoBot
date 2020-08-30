using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AlkoBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "!hello";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;
            else return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            await client.SendTextMessageAsync(chatId, "Welcome here! Wanna drink?", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
