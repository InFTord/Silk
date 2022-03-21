using System.Threading.Tasks;
using FuzzySharp;
using Microsoft.Extensions.Logging;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Rest.Core;
using Remora.Results;
using Silk.Services.Data;
using Silk.Services.Interfaces;
using Unidecode.NET;

namespace Silk.Services.Guild;

public class SuspiciousUserDetectionService
{
    private readonly IDiscordRestUserAPI                     _users;
    private readonly IInfractionService                      _infractions;
    private readonly GuildConfigCacheService                 _config;
    private readonly ILogger<SuspiciousUserDetectionService> _logger;

    private readonly string[] SuspiciousUsernames = new[]
    {
        "ModMail",
        "Bot Moderator",
        "Discord Moderator",
        "Hypesquad Events",
    };
    
    public SuspiciousUserDetectionService
    (
        IDiscordRestUserAPI users,
        IInfractionService infractions,
        GuildConfigCacheService config,
        ILogger<SuspiciousUserDetectionService> logger
    )
    {
        _users       = users;
        _infractions = infractions;
        _config      = config;
        _logger = logger;
    }

    public async Task<Result> HandleSuspiciousUserAsync(Snowflake guildID, IUser user)
    {
        var config = await _config.GetModConfigAsync(guildID);

        if (!config.BanSuspiciousUsernames)
            return Result.FromSuccess();
        
        // TODO: add to config and make toggelable. This will go under phishing settings.
        var detection = IsSuspcectedPhishingUsername(user.Username);
        
        if (!detection.isSuspicious)
            return Result.FromSuccess();

        if (user.IsBot.IsDefined(out var bot) && bot)
        {
            _logger.LogTrace("Suspiciously named bot: {BotName}, similar to {SimilarName}", user.Username, detection.mostSimilarTo);
            return Result.FromSuccess();
        }

        var self = await _users.GetCurrentUserAsync();

        if (!self.IsSuccess)
            return Result.FromError(self.Error);

        // We delete the last day of messages to clear any potential join message.
        var infraction = await _infractions.BanAsync(guildID, user.ID, self.Entity.ID, 1, $"Suspicious username detected: `{user.Username}` ➜ `{detection.mostSimilarTo}`");
        
        if (!infraction.IsSuccess)
            return Result.FromError(infraction.Error);
        
        return Result.FromSuccess();
    }
    
    private (bool isSuspicious, string mostSimilarTo) IsSuspcectedPhishingUsername(string username)
    {
        var normalized = username.Unidecode();

        var fuzzy = Process.ExtractOne(normalized, SuspiciousUsernames);

        if (fuzzy.Score > 75)
            _logger.LogTrace("Potentially suspicious Username: {Normalized}, most similar to {FuzzyMatched}, Score: {Score}", normalized, fuzzy.Value, fuzzy.Score);
        
        // This is somewhat arbitrary, and may be adjusted to be more or less sensitive.
        return (fuzzy.Score > 80, fuzzy.Value);
    }
}