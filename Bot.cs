using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;

namespace BotDiscord
{
    public class BotScript
    {
        
        DiscordSocketClient client;
        CommandService command;
        IServiceProvider service;
        static void Main(string[] args) => new BotScript().RunBotAsync().GetAwaiter().GetResult();

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            { WebSocketProvider = WS4NetProvider.Instance });
            command = new CommandService();
            
            
            service = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(command)
                .BuildServiceProvider();

            client.Log += Log;

            client.MessageReceived += MessageReceived;           
            await command.AddModulesAsync(Assembly.GetEntryAssembly(), service);
            
            string token = "Токен вашего бота";
            await client.LoginAsync(Discord.TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            var _message = message as SocketUserMessage;
            if (_message is null || message.Author.IsBot) return;
            int argPos = 0;
            if (_message.HasStringPrefix("!", ref argPos) || _message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                var txt = new SocketCommandContext(client, _message);
                              
                var reult = await command.ExecuteAsync(txt, argPos, service);
                
                if (!reult.IsSuccess)
                    Console.WriteLine(reult.ErrorReason);
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());

            return Task.CompletedTask;
        }
    }

}
    
      
        



















      
