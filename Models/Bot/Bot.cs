﻿using System;
using System.Linq;
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

        public static async Task Main()
        {
            botClient = new TelegramBotClient(AppSettings.Token);

            var me = await botClient.GetMeAsync();
            Console.Title = me.Username;

            botClient.StartReceiving();

            Console.WriteLine($"Waiting for messages from @{me.Username}");
            botClient.OnMessage += BotOnMessage;
            botClient.OnMessageEdited += BotOnMessage;
            botClient.OnCallbackQuery += BotOnCallbackQuery;
            botClient.OnInlineQuery += BotOnInlineQuery;
            botClient.OnInlineResultChosen += BotOnInlineResultChosen;

            Console.ReadLine();

            botClient.StopReceiving();
        }

        private static async void BotOnMessage(object sender, MessageEventArgs e)
        {
            Message message = e.Message;
            Console.WriteLine($"Message Received.\nMessage type: {message.Type}\n");
            if (message.Type == MessageType.Text)
            {
                message.Text = message.Text.ToLower();
                var action = (message.Text.Split(' ').First()) switch
                {
                    "hello" => new Hello_command().Execute(message, botClient),
                    "help" => new Help_command().Execute(message, botClient),
                    _ => new Help_command().Execute(message, botClient)
                };

                await action;
            }
        }

        private static void BotOnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BotOnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void BotOnInlineResultChosen(object sender, ChosenInlineResultEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
