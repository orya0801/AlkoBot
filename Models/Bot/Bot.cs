using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace AlkoBot.Models.Bot
{
    public static class Bot
    {
        private static ITelegramBotClient botClient;
        private static readonly DatabaseContext db;

        static Bot()
        {
            db = new DatabaseContext();
        }
        public static async Task Main()
        {
            botClient = new TelegramBotClient(AppSettings.Token);

            var me = await botClient.GetMeAsync();
            Console.Title = me.Username;

            botClient.StartReceiving();

            Console.WriteLine($"Waiting for messages from @{me.Username}");
            botClient.OnMessage += BotOnMessage;
            botClient.OnMessageEdited += BotOnMessage;

            Console.ReadLine();

            botClient.StopReceiving();
        }

        private static async void BotOnMessage(object sender, MessageEventArgs e)
        {
            Message message = e.Message;
            Console.WriteLine($"Message Received.\nMessage type: {message.Type}\n");

            if (message.Type == MessageType.Text)
            {
                var action = (message.Text) switch
                {
                    "/start" => Commands.GetCommand("Start"),
                    "Коктейли" => Commands.GetCommand("Cocktails"),
                    "Удиви меня!" => Commands.GetCommand("Help"),
                    "Популярное" => Commands.GetCommand("Help"),
                    "Предложить" => Commands.GetCommand("Help"),
                    "Помощь" => Commands.GetCommand("Help"),
                    _ => Commands.GetCommand("Help")
                };

                await action.Execute(message, botClient);

                if (db.PreviousActions.Find("UserId") == null)
                {
                    PreviousAction prevAction = new PreviousAction
                    {
                        UserId = message.From.Id,
                        PrevAction = action.Name
                    };
                    db.PreviousActions.Add(prevAction);
                }
                else
                {
                    PreviousAction prevAction = db.PreviousActions.Find("UserId");
                    prevAction.PrevAction = action.Name;
                    db.PreviousActions.Update(prevAction);
                }
                db.SaveChanges();
            }
        }
    }
}
