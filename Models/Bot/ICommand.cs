using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AlkoBot.Models.Bot
{
    public interface ICommand
    {
        public string Name { get; }

        public Task Execute(Message message, ITelegramBotClient botClient);
    }
}
