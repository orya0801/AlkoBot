using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using AlkoBot.Models.Commands;
using Telegram.Bot.Types;

namespace AlkoBot.Models.Bot
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
                return botClient;

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());

            botClient = new TelegramBotClient(AppSettings.Token);

            Update[] updates = await botClient.GetUpdatesAsync();
        }
    }
}
