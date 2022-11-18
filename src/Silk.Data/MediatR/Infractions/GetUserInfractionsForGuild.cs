﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Remora.Rest.Core;
using Silk.Data.DTOs.Guilds;
using Silk.Data.Entities;

namespace Silk.Data.MediatR.Infractions;

public static class GetUserInfractionsForGuild
{
    public sealed record Request(Snowflake GuildID, Snowflake TargetID) : IRequest<IEnumerable<Infraction>>;

    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class Handler : IRequestHandler<Request, IEnumerable<Infraction>>
    {
        private readonly GuildContext _db;
        public Handler(GuildContext db) => _db = db;

        public async ValueTask<IEnumerable<Infraction>> Handle(Request request, CancellationToken cancellationToken)
        {
            
            
            var query = _db.Infractions
                           .Where(inf => inf.TargetID == request.TargetID)
                           .Where(inf => inf.GuildID == request.GuildID);
            
            return (await query.ToListAsync(cancellationToken)).Select(InfractionEntity.ToDTO)!;
        }
    }
}