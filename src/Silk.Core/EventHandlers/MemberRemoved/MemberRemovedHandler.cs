﻿using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Silk.Core.Data.Entities;
using Silk.Core.Services.Data;

namespace Silk.Core.EventHandlers.MemberRemoved
{
    public sealed class MemberRemovedHandler
    {
        private readonly GuildConfigCacheService _guildConfigCacheService;
        public MemberRemovedHandler(DiscordClient client, GuildConfigCacheService guildConfigCacheService)
        {
            client.GuildMemberRemoved += OnMemberRemoved;
            _guildConfigCacheService = guildConfigCacheService;
        }

        public async Task OnMemberRemoved(DiscordClient c, GuildMemberRemoveEventArgs e)
        {
            GuildModConfigEntity config = await _guildConfigCacheService.GetModConfigAsync(e.Guild.Id);
            // This should be done in a separate service //
            if (config.LogMemberLeaves && config.LoggingChannel is not 0)
                await e.Guild.GetChannel(config.LoggingChannel).SendMessageAsync(GetLeaveEmbed(e));
        }

        private static DiscordEmbedBuilder GetLeaveEmbed(GuildMemberRemoveEventArgs e)
        {
            return new DiscordEmbedBuilder()
                  .WithTitle("User joined:")
                  .WithDescription($"User: {e.Member.Mention}")
                  .AddField("User ID:", e.Member.Id.ToString(), true)
                  .WithThumbnail(e.Member.AvatarUrl)
                  .WithColor(DiscordColor.Green);
        }
    }
}