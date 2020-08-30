using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace AlkoBot.Models.Commands
{
    //Абстрактный класс, являющийся заготовкой для прочих команд
    public abstract class Command
    {
        //Имя команды
        public abstract string Name { get; }

        //Функция-заготовка для выполнения команды
        public abstract Task Execute(Message message, TelegramBotClient client);

        //Функция-заготовка для определения вызова команды
        public abstract bool Contains(Message message);
    }
}
