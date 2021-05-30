using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace BotDiscord.Commands
{
    public class СommandBot : ModuleBase<SocketCommandContext>
    {


        [Command("ping")]

        public async Task Ping()
        {
            await ReplyAsync("ping");
        }

    }
}


        
