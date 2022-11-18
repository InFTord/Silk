using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Silk.Data.Entities;

namespace Silk.Data.MediatR.Greetings;

public static class GetPendingGreetings
{
    public record Request(int ShardCount, int ShardID) : IRequest<IReadOnlyList<PendingGreetingEntity>>;
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class Handler : IRequestHandler<Request, IReadOnlyList<PendingGreetingEntity>>
    {
        private readonly GuildContext _db;
        
        public Handler(GuildContext db) => _db = db;


        public async ValueTask<IReadOnlyList<PendingGreetingEntity>> Handle(Request request, CancellationToken cancellationToken)
        {
            
            
            return await _db.PendingGreetings
                           .FromSqlRaw("SELECT * FROM pending_greetings pg WHERE (pg.guild_id::bigint >> 22) % {0} = {1}", request.ShardCount, request.ShardID)
                           .ToArrayAsync(cancellationToken); // Will EF Core do client eval for this?
        }
    }

}