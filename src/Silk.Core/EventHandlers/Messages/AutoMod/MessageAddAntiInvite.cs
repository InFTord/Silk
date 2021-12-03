﻿using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Silk.Core.Data.Entities;
using Silk.Core.Services.Data;

namespace Silk.Core.EventHandlers.Messages.AutoMod
{
    public sealed class MessageAddAntiInvite
    {
        private readonly GuildConfigCacheService    _guildConfigCache;
        private readonly AntiInviteHelper _inviteHelper;

        public MessageAddAntiInvite(DiscordClient client, GuildConfigCacheService guildConfigCache, AntiInviteHelper inviteHelper)
        {
            client.MessageCreated += CheckForInvite;
            _guildConfigCache = guildConfigCache;
            _inviteHelper = inviteHelper;
        }

        public async Task CheckForInvite(DiscordClient client, MessageCreateEventArgs args)
        {
            if (!args.Channel.IsPrivate && args.Author != client.CurrentUser)
            {
                GuildModConfigEntity? config = await _guildConfigCache.GetModConfigAsync(args.Guild.Id);

                bool hasInvite = _inviteHelper.CheckForInvite(args.Message, config, out string invite);

                if (!hasInvite)
                    return;

                bool isBlacklisted = await _inviteHelper.IsBlacklistedInvite(args.Message, config, invite);

                if (isBlacklisted)
                    await _inviteHelper.TryAddInviteInfractionAsync(args.Message, config);
            }
        }
    }
}