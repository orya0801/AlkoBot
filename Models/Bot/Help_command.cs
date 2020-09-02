using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AlkoBot.Models.Bot
{
    public class Help_command : ICommand
    {
        public string Name => "Help";

        public Task Execute(Message message, ITelegramBotClient botClient)
        {
            string text = "<u><b>Коктейли</b></u>\n" +
                "По нажатию на <b>данную кнопку</b> выводится <b>меню</b> алкогольных напитков.\n" +
                "Выбери <b>свой любимый напиток</b> нажатием на <b>кнопку</b>.\n" +
                "Я покажу тебе <b>рецепт коктейля</b> на основе выбранного напитка.\n" +
                "Приготовь, попробуй его и <b>обязательно скажи мне</b> понравился ли тебе этот <i>коктейль</i>!\n" +
                "(нажми на <b>лайк</b> или <b>дизлайк</b>)\n\n" +
                "<u><b>Удиви меня!</b></u>\n" +
                "<b>Жми</b> скорее на <b>эту кнопку</b>, если ты достаточно <b><i>смелый</i></b>!\n" +
                "<b>Специально для тебя</b> я выберу <b>рецепт случайного коктейля</b> из моей поваренной книги!\n\n" +
                "<u><b>Популярное</b></u>\n" +
                "Желаешь оставаться в <b>алкогольном <i>тренде</i></b>?\n" +
                "<b>Жми</b> на эту <b>кнопку</b>!\n\n" +
                "<u><b>Предложить</b></u>\n" +
                "Твоя бабуля рассказала тебе семейный рецепт коктейля на медовухе?\n" +
                "<b>Поделись</b> этим рецептом со <b>мной</b>!";
            botClient.SendTextMessageAsync(message.Chat.Id, text, ParseMode.Html);
            return Task.CompletedTask;
        }
    }
}
