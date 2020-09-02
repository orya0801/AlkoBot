using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AlkoBot.Models.Bot
{
    public class Start_command : ICommand
    {
        public string Name => "Start";

        public Task Execute(Message message, ITelegramBotClient botClient)
        {
            var buttons = new[]
            {
                new KeyboardButton("Коктейли"),
                new KeyboardButton("Удиви меня!"),
                new KeyboardButton("Популярное"),
                new KeyboardButton("Предложить"),
                new KeyboardButton("Помощь")
            };

            var keyboard = new ReplyKeyboardMarkup(buttons, resizeKeyboard: true, oneTimeKeyboard: true);

            string text = "Привет! Я АлкоБот - твой личный бармен! " +
                "Только готовить коктейли я не умею - у меня лапки (^˵◕ω◕˵^)";
            botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: keyboard);
            return Task.CompletedTask;
        }
    }
}
