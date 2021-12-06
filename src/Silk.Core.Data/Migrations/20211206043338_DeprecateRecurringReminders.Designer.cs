﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Silk.Core.Data;

namespace Silk.Core.Data.Migrations
{
    [DbContext(typeof(GuildContext))]
    [Migration("20211206043338_DeprecateRecurringReminders")]
    partial class DeprecateRecurringReminders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Silk.Core.Data.Entities.CommandInvocationEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InvocationTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("CommandInvocations");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.DisabledCommandEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("GuildConfigEntityId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildConfigEntityId");

                    b.HasIndex("GuildId", "CommandName")
                        .IsUnique();

                    b.ToTable("DisabledCommandEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.ExemptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Exemption")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("exempt_from");

                    b.Property<decimal>("Guild")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("guild_id");

                    b.Property<int?>("GuildModConfigEntityId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Target")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("target_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("GuildModConfigEntityId");

                    b.ToTable("ExemptionEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("GreetingChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("GreetingOption")
                        .HasColumnType("integer");

                    b.Property<string>("GreetingText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("VerificationRole")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("GuildConfigs");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildEntity", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildGreetingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("ChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("GuildConfigEntityId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("MetadataSnowflake")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Option")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GuildConfigEntityId");

                    b.ToTable("GuildGreetingEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildLoggingConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal?>("FallbackLoggingChannel")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("fallback_logging_channel");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("guild_id");

                    b.Property<int?>("InfractionsId")
                        .HasColumnType("integer");

                    b.Property<bool>("LogInfractions")
                        .HasColumnType("boolean")
                        .HasColumnName("log_infractions");

                    b.Property<bool>("LogMemberJoins")
                        .HasColumnType("boolean")
                        .HasColumnName("log_member_joins");

                    b.Property<bool>("LogMemberLeaves")
                        .HasColumnType("boolean")
                        .HasColumnName("log_member_leaves");

                    b.Property<bool>("LogMessageDeletes")
                        .HasColumnType("boolean")
                        .HasColumnName("log_message_deletes");

                    b.Property<bool>("LogMessageEdits")
                        .HasColumnType("boolean")
                        .HasColumnName("log_message_edits");

                    b.Property<int?>("MemberJoinsId")
                        .HasColumnType("integer");

                    b.Property<int?>("MemberLeavesId")
                        .HasColumnType("integer");

                    b.Property<int?>("MessageDeletesId")
                        .HasColumnType("integer");

                    b.Property<int?>("MessageEditsId")
                        .HasColumnType("integer");

                    b.Property<bool>("UseWebhookLogging")
                        .HasColumnType("boolean")
                        .HasColumnName("use_webhook_logging");

                    b.HasKey("Id");

                    b.HasIndex("InfractionsId");

                    b.HasIndex("MemberJoinsId");

                    b.HasIndex("MemberLeavesId");

                    b.HasIndex("MessageDeletesId");

                    b.HasIndex("MessageEditsId");

                    b.ToTable("GuildLoggingConfigEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildModConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AutoDehoist")
                        .HasColumnType("boolean");

                    b.Property<bool>("AutoEscalateInfractions")
                        .HasColumnType("boolean");

                    b.Property<bool>("BlacklistInvites")
                        .HasColumnType("boolean");

                    b.Property<bool>("BlacklistWords")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeleteMessageOnMatchedInvite")
                        .HasColumnType("boolean");

                    b.Property<bool>("DeletePhishingLinks")
                        .HasColumnType("boolean");

                    b.Property<bool>("DetectPhishingLinks")
                        .HasColumnType("boolean");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("LogMemberJoins")
                        .HasColumnType("boolean");

                    b.Property<bool>("LogMemberLeaves")
                        .HasColumnType("boolean");

                    b.Property<bool>("LogMessageChanges")
                        .HasColumnType("boolean");

                    b.Property<decimal>("LoggingChannel")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("LoggingConfigId")
                        .HasColumnType("integer");

                    b.Property<string>("LoggingWebhookUrl")
                        .HasColumnType("text");

                    b.Property<int>("MaxRoleMentions")
                        .HasColumnType("integer");

                    b.Property<int>("MaxUserMentions")
                        .HasColumnType("integer");

                    b.Property<decimal>("MuteRoleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("NamedInfractionSteps")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("ScanInvites")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseAggressiveRegex")
                        .HasColumnType("boolean");

                    b.Property<bool>("UseWebhookLogging")
                        .HasColumnType("boolean");

                    b.Property<bool>("WarnOnMatchedInvite")
                        .HasColumnType("boolean");

                    b.Property<decimal>("WebhookLoggingId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.HasIndex("LoggingConfigId");

                    b.ToTable("GuildModConfigs");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.InfractionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CaseNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("Enforcer")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("EscalatedFromStrike")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<bool>("Handled")
                        .HasColumnType("boolean");

                    b.Property<bool>("HeldAgainstUser")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("InfractionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InfractionType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("UserId", "GuildId");

                    b.ToTable("Infractions");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.InfractionStepEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ConfigId")
                        .HasColumnType("integer");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConfigId");

                    b.ToTable("InfractionStepEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.InviteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("GuildModConfigEntityId")
                        .HasColumnType("integer");

                    b.Property<decimal>("InviteGuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("VanityURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildModConfigEntityId");

                    b.ToTable("InviteEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.LoggingChannelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("ChannelId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("channel_id");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("guild_id");

                    b.Property<decimal>("WebhookId")
                        .HasColumnType("numeric(20,0)")
                        .HasColumnName("webhook_id");

                    b.Property<string>("WebhookToken")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("webhook_token");

                    b.HasKey("Id");

                    b.ToTable("LoggingChannelEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.ReminderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("ChannelId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("text");

                    b.Property<decimal>("MessageId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("OwnerId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("ReplyAuthorId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("ReplyId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("ReplyMessageContent")
                        .HasColumnType("text");

                    b.Property<bool>("WasReply")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.TagEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("GuildEntityId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OriginalTagId")
                        .HasColumnType("integer");

                    b.Property<decimal>("OwnerId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Uses")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GuildEntityId");

                    b.HasIndex("OriginalTagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.UserEntity", b =>
                {
                    b.Property<decimal>("Id")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("DatabaseId")
                        .HasColumnType("bigint");

                    b.Property<int>("Flags")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InitialJoinDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id", "GuildId");

                    b.HasIndex("GuildId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.UserHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<List<DateTime>>("JoinDates")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone[]");

                    b.Property<List<DateTime>>("LeaveDates")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone[]");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "GuildId")
                        .IsUnique();

                    b.ToTable("UserHistoryEntity");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.DisabledCommandEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildConfigEntity", null)
                        .WithMany("DisabledCommands")
                        .HasForeignKey("GuildConfigEntityId");

                    b.HasOne("Silk.Core.Data.Entities.GuildEntity", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.ExemptionEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildModConfigEntity", null)
                        .WithMany("Exemptions")
                        .HasForeignKey("GuildModConfigEntityId");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildConfigEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildEntity", "Guild")
                        .WithOne("Configuration")
                        .HasForeignKey("Silk.Core.Data.Entities.GuildConfigEntity", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildGreetingEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildConfigEntity", null)
                        .WithMany("Greetings")
                        .HasForeignKey("GuildConfigEntityId");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildLoggingConfigEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.LoggingChannelEntity", "Infractions")
                        .WithMany()
                        .HasForeignKey("InfractionsId");

                    b.HasOne("Silk.Core.Data.Entities.LoggingChannelEntity", "MemberJoins")
                        .WithMany()
                        .HasForeignKey("MemberJoinsId");

                    b.HasOne("Silk.Core.Data.Entities.LoggingChannelEntity", "MemberLeaves")
                        .WithMany()
                        .HasForeignKey("MemberLeavesId");

                    b.HasOne("Silk.Core.Data.Entities.LoggingChannelEntity", "MessageDeletes")
                        .WithMany()
                        .HasForeignKey("MessageDeletesId");

                    b.HasOne("Silk.Core.Data.Entities.LoggingChannelEntity", "MessageEdits")
                        .WithMany()
                        .HasForeignKey("MessageEditsId");

                    b.Navigation("Infractions");

                    b.Navigation("MemberJoins");

                    b.Navigation("MemberLeaves");

                    b.Navigation("MessageDeletes");

                    b.Navigation("MessageEdits");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildModConfigEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildEntity", "Guild")
                        .WithOne("ModConfig")
                        .HasForeignKey("Silk.Core.Data.Entities.GuildModConfigEntity", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silk.Core.Data.Entities.GuildLoggingConfigEntity", "LoggingConfig")
                        .WithMany()
                        .HasForeignKey("LoggingConfigId");

                    b.Navigation("Guild");

                    b.Navigation("LoggingConfig");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.InfractionEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildEntity", "Guild")
                        .WithMany("Infractions")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silk.Core.Data.Entities.UserEntity", "User")
                        .WithMany("Infractions")
                        .HasForeignKey("UserId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.InfractionStepEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildModConfigEntity", "Config")
                        .WithMany("InfractionSteps")
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Config");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.InviteEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildModConfigEntity", null)
                        .WithMany("AllowedInvites")
                        .HasForeignKey("GuildModConfigEntityId");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.TagEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildEntity", null)
                        .WithMany("Tags")
                        .HasForeignKey("GuildEntityId");

                    b.HasOne("Silk.Core.Data.Entities.TagEntity", "OriginalTag")
                        .WithMany("Aliases")
                        .HasForeignKey("OriginalTagId");

                    b.Navigation("OriginalTag");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.GuildEntity", "Guild")
                        .WithMany("Users")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.UserHistoryEntity", b =>
                {
                    b.HasOne("Silk.Core.Data.Entities.UserEntity", "User")
                        .WithOne("History")
                        .HasForeignKey("Silk.Core.Data.Entities.UserHistoryEntity", "UserId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildConfigEntity", b =>
                {
                    b.Navigation("DisabledCommands");

                    b.Navigation("Greetings");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildEntity", b =>
                {
                    b.Navigation("Configuration")
                        .IsRequired();

                    b.Navigation("Infractions");

                    b.Navigation("ModConfig")
                        .IsRequired();

                    b.Navigation("Tags");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.GuildModConfigEntity", b =>
                {
                    b.Navigation("AllowedInvites");

                    b.Navigation("Exemptions");

                    b.Navigation("InfractionSteps");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.TagEntity", b =>
                {
                    b.Navigation("Aliases");
                });

            modelBuilder.Entity("Silk.Core.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("History")
                        .IsRequired();

                    b.Navigation("Infractions");
                });
#pragma warning restore 612, 618
        }
    }
}
