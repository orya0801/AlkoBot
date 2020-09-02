using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace AlkoBot.Models.Bot
{
    public class Cocktails_command : ICommand
    {
        public string Name => "Cocktails";

        public Task Execute(Message message, ITelegramBotClient botClient)
        {
            var buttons = new[]
            {
                new[]
                {
                    new KeyboardButton("Пиво"),
                    new KeyboardButton("Ликер"),
                    new KeyboardButton("Джин")
                },
                new[]
                {
                    new KeyboardButton("Ром"),
                    new KeyboardButton("Саке"),
                    new KeyboardButton("Текила")
                },
                new[]
                {
                    new KeyboardButton("Водка"),
                    new KeyboardButton("Вино"),
                    new KeyboardButton("Виски")
                },
                new[]
                {
                    new KeyboardButton("Бренди"),
                    new KeyboardButton("Абсент"),
                    new KeyboardButton("Другое")
                },
                new[] {new KeyboardButton("Назад") }
            };

            var keyboard = new ReplyKeyboardMarkup(buttons, resizeKeyboard: true, oneTimeKeyboard: true);

            string text = "Выбери основу коктейля";
            botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: keyboard);
            return Task.CompletedTask;
        }
    }
}
