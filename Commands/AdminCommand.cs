using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using Discord.Audio;
using System.Security.Policy;
using Discord.Rest;
using DSharpPlus.CommandsNext.Attributes;
using System.Runtime.Remoting.Channels;

namespace BotDiscord.Commands
{
    public class AdminCommand : ModuleBase<SocketCommandContext>
    {


        [Discord.Commands.Command("Ban")]

        [RequireRoles(RoleCheckMode.Any, "Moder")]

        public async Task Banasync(IGuildUser user = null, [Remainder] string reason = null)
        {

            if (user == null)
            {
                await ReplyAsync("Ввведите игрока");
                return;
            }
            if (reason == null)
            {
                await ReplyAsync("Причина бана не указана");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(r => r.Name == "Moder"))
                {
                    await Context.Guild.AddBanAsync(user.Id, 1, reason);
                    await ReplyAsync("Пользователь " + Context.Message.Author.Mention + " забанил" + $"<@{user.Id}> " + " Причина: " + reason);
                }
                else
                    await ReplyAsync("У вас нет прав для этой команды");
            }

        }


        [Discord.Commands.Command("Kick")]

        [RequireRoles(RoleCheckMode.Any, "Moder")]

        public async Task Kick(IGuildUser user, [Remainder] string reason = null)
        {

            if (reason == null)
            {
                await ReplyAsync("Причина кика не указана");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(r => r.Name == "Moder"))
                {
                    await user.KickAsync(reason);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " кикнул " + $"<@{user.Id}> " + " Причина: " + reason);
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }

        }

        [Discord.Commands.Command("Unban")]

        public async Task Unbanasync(ulong id)
        {
            await Context.Guild.RemoveBanAsync(id);
            await ReplyAsync("Пользователь: " + Context.Message.Author.Mention + " разбанил " + $"<@{id}>");

        }

        [Discord.Commands.Command("Mutevoice")]

        [RequireRoles(RoleCheckMode.Any, "Moder")]

        public async Task MuteVoice(IGuildUser user = null, [Remainder] string reason = null)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MuteVoice");
            var userMute = user as IGuildUser;

            if (user == null)
            {
                await ReplyAsync("Введите имя пользователя");
                return;
            }
            if (reason == null)
            {
                await ReplyAsync("Введите причину мута войса");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(x => x.Name == "Moder"))
                {

                    await userMute.AddRoleAsync(role);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " выдал мут войса" + $"<@{user.Id}> " + " Причина: " + reason);
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }
        }


        [Discord.Commands.Command("Mutechat")]


        [RequireRoles(RoleCheckMode.Any, "Moder")]
        public async Task MuteChat(IGuildUser user = null, [Remainder] string reason = null)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MuteChat");
            var userMute = user as IGuildUser;
            if (user == null)
            {
                await ReplyAsync("Введите имя пользователя");
                return;
            }
            if (reason == null)
            {
                await ReplyAsync("Введите причину мута чата");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(x => x.Name == "Moder"))
                {
                    await userMute.AddRoleAsync(role);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " выдал мут чата" + $"<@{user.Id}> " + " Причина: " + reason);
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }
        }

        [Discord.Commands.Command("Unmutechat")]


        [RequireRoles(RoleCheckMode.Any, "Moder")]
        public async Task UnmuteChat(IGuildUser user = null)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MuteChat");
            var unmute = user as IGuildUser;

            if (user == null)
            {
                await ReplyAsync("Введите имя пользователя");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if ((username.Roles.Any(x => x.Name == "Moder")))
                {
                    await unmute.RemoveRoleAsync(role);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " снял мут чата с " + $"<@{user.Id}> ");
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }
        }

        [Discord.Commands.Command("Bankomnat")]
        [RequireRoles(RoleCheckMode.Any, "Moder")]
        public async Task BanKomnat(IGuildUser user = null, [Remainder] string reason = null)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "BanKomnat");
            var userBanKomnat = user as IGuildUser;

            if (user == null)
            {
                await ReplyAsync("Укажите имя пользователя");
                return;
            }
            if (reason == null)
            {
                await ReplyAsync("Укажите причину бана комнат");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(x => x.Name == "Moder"))
                {
                    await userBanKomnat.AddRoleAsync(role);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " выдал бан комнат" + $"<@{user.Id}> " + " Причина: " + reason);
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }
        }

        [Discord.Commands.Command("Unbankomnat")]
        [RequireRoles(RoleCheckMode.Any, "Moder")]
        public async Task UnBanKomnat(IGuildUser user = null)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "BanKomnat");
            var unbankomnat = user as IGuildUser;

            if (user == null)
            {
                await ReplyAsync("Укажите имя пользователя");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(x => x.Name == "Moder"))
                {
                    await unbankomnat.RemoveRoleAsync(role);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + "снял бан комнат с " + $"<@{user.Id}> ");
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }
        }

        [Discord.Commands.Command("Unmutevoice")]


        [RequireRoles(RoleCheckMode.Any, "Moder")]
        public async Task UnMuteVoice(IGuildUser user = null)
        {
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MuteVoice");
            var userMute = user as IGuildUser;

            if (user == null)
            {
                await ReplyAsync("Введите имя пользователя");
                return;
            }
            if (Context.User is SocketGuildUser username)
            {
                if (username.Roles.Any(x => x.Name == "Moder"))
                {

                    await userMute.RemoveRoleAsync(role);
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " снял мут войса" + $"<@{user.Id}> ");
                }
                else
                    await ReplyAsync("У вас не достаточно прав для использования этой команды");
            }
        }

        [Discord.Commands.Command("Warn")]

        public async Task Warn(IGuildUser user = null, [Remainder] string reason = null)
        {
            int z = 3;
            if (Context.User is SocketGuildUser username)
            {
                if ((username.Roles.Any(x => x.Name == "Moder")))
                {
                    int result = z - 1;
                    await ReplyAsync("Пользователь" + Context.Message.Author.Mention + " выдал предупреждение" + $"<@{user.Id}> " + " причина: " + reason + "Попыток осталось: " + result--);
                }
            }
        }
    }
}

                    

            



        

    

       
     

      
        
  



 
        
            
          
        






















    