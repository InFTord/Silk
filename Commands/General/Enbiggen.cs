﻿using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using SilkBot.Utilities;

namespace SilkBot.Commands.General
{
    public class Enbiggen : BaseCommandModule
    {
        [Command("Enlarge")]
        public async Task Enlarge(CommandContext ctx, DiscordEmoji emoji) =>
            await ctx.RespondAsync(embed: new DiscordEmbedBuilder()
                .WithDescription("Emoji Name: " + emoji.GetDiscordName())
                .WithImageUrl(emoji.Url)
                .WithColor(new DiscordColor("42d4f5"))
                .AddFooter(ctx));

    }
}
