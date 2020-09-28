﻿using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using SilkBot.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SilkBot.Commands.Moderation.Utilities
{
    public sealed class MessageEditHandler
    {


        public MessageEditHandler(DiscordClient client)
        {

            client.MessageUpdated += OnMessageEdit;
        }

        private async Task OnMessageEdit(MessageUpdateEventArgs e)
        {
            var config = SilkBot.Bot.Instance.SilkDBContext.Guilds.First(g => g.DiscordGuildId == e.Guild.Id);
            CheckForInvite(e, config);
            var logChannel = config.GeneralLoggingChannel;
            if (e.Message.Author.IsCurrent || e.Message.Author.IsBot) return;

            if (logChannel == default) return;


            var embed =
                new DiscordEmbedBuilder()
                .WithAuthor($"{e.Message.Author.Username} ({e.Message.Author.Id})", iconUrl: e.Message.Author.AvatarUrl)
                .WithDescription($"[Message edited in]({e.Message.JumpLink}) {e.Message.Channel.Mention}:\n" +
                $"Time: {DateTime.Now:HH:mm}\n" +
                $"📝 **Original:**\n```\n{e.MessageBefore.Content}\n```\n" +
                $"📝 **Changed:**\n```\n{e.Message.Content}\n```\n")
                .AddField("Message ID:", e.Message.Id.ToString(), true)
                .AddField("Channel ID:", e.Channel.Id.ToString(), true)
                .WithColor(DiscordColor.CornflowerBlue)
                .WithFooter("Silk!", e.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now);
            var loggingChannel = await e.Client.GetChannelAsync(logChannel.Value);
            await e.Client.SendMessageAsync(loggingChannel, embed: embed);
        }
        private void CheckForInvite(MessageUpdateEventArgs e, Guild config)
        {
            if (config.WhiteListInvites)
            {
                if (e.Message.Content.Contains("discord.gg") || e.Message.Content.Contains("discord.com/invite"))
                {
                    var invite = Regex.Match(e.Message.Content, @"(discord\.gg\/.+)") ?? Regex.Match(e.Message.Content.ToLower(), @"(discord\.com\/invite\/.+)");
                    if (!invite.Success)
                    {
                        return;
                    }

                    var inviteLink = string.Join("", e.Message.Content.Skip(invite.Index).TakeWhile(c => c != ' ')).Replace("discord.com/invite", "discord.gg/");
                    if (!config.WhiteListedLinks.Any(link => link.Link == inviteLink))
                    {
                        e.Message.DeleteAsync().GetAwaiter();
                    }
                }
            }
        }
    }
}