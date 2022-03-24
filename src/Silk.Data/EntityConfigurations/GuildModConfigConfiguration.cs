﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Silk.Data.Entities;
using Silk.Data.Entities.Guild.Config;

namespace Silk.Data.EntityConfigurations;

public sealed class GuildModConfigEntityConfiguration : IEntityTypeConfiguration<GuildModConfigEntity>
{
    public void Configure(EntityTypeBuilder<GuildModConfigEntity> builder)
    {
        builder.Property(b => b.NamedInfractionSteps)
               .HasConversion(b => JsonConvert.SerializeObject(b,
                                                               new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }),
                              b => JsonConvert.DeserializeObject<Dictionary<string, InfractionStepEntity>>(b)!);

        builder.HasOne(c => c.Invites)
               .WithOne(c => c.GuildConfig)
               .HasForeignKey<InviteConfigEntity>(c => c.GuildModConfigId);
    }
}