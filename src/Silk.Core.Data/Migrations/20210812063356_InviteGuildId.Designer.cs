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
    [Migration("20210812063356_InviteGuildId")]
    partial class InviteGuildId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Silk.Core.Data.Models.CommandInvocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("UserId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("CommandInvocations");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.DisabledCommand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommandName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("GuildConfigId")
                        .HasColumnType("integer");

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("GuildConfigId");

                    b.HasIndex("GuildId", "CommandName")
                        .IsUnique();

                    b.ToTable("DisabledCommand");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.GlobalUser", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<int>("Cash")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastCashOut")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("GlobalUsers");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Guild", b =>
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

            modelBuilder.Entity("Silk.Core.Data.Models.GuildConfig", b =>
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

            modelBuilder.Entity("Silk.Core.Data.Models.GuildModConfig", b =>
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

                    b.Property<bool>("WarnOnMatchedInvite")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("GuildId")
                        .IsUnique();

                    b.ToTable("GuildModConfigs");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Infraction", b =>
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

            modelBuilder.Entity("Silk.Core.Data.Models.InfractionStep", b =>
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

                    b.ToTable("InfractionStep");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("GuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("GuildModConfigId")
                        .HasColumnType("integer");

                    b.Property<decimal>("InviteGuildId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("VanityURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildModConfigId");

                    b.ToTable("Invite");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Reminder", b =>
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

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<bool>("WasReply")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Tag", b =>
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

                    b.HasIndex("GuildId");

                    b.HasIndex("OriginalTagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.User", b =>
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

            modelBuilder.Entity("Silk.Core.Data.Models.UserHistory", b =>
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

                    b.ToTable("UserHistory");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.DisabledCommand", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.GuildConfig", null)
                        .WithMany("DisabledCommands")
                        .HasForeignKey("GuildConfigId");

                    b.HasOne("Silk.Core.Data.Models.Guild", "Guild")
                        .WithMany()
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.GuildConfig", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.Guild", "Guild")
                        .WithOne("Configuration")
                        .HasForeignKey("Silk.Core.Data.Models.GuildConfig", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.GuildModConfig", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.Guild", "Guild")
                        .WithOne("ModConfig")
                        .HasForeignKey("Silk.Core.Data.Models.GuildModConfig", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Infraction", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.Guild", "Guild")
                        .WithMany("Infractions")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silk.Core.Data.Models.User", "User")
                        .WithMany("Infractions")
                        .HasForeignKey("UserId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.InfractionStep", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.GuildModConfig", "Config")
                        .WithMany("InfractionSteps")
                        .HasForeignKey("ConfigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Config");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Invite", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.GuildModConfig", null)
                        .WithMany("AllowedInvites")
                        .HasForeignKey("GuildModConfigId");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Tag", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.Guild", null)
                        .WithMany("Tags")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Silk.Core.Data.Models.Tag", "OriginalTag")
                        .WithMany("Aliases")
                        .HasForeignKey("OriginalTagId");

                    b.Navigation("OriginalTag");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.User", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.Guild", "Guild")
                        .WithMany("Users")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.UserHistory", b =>
                {
                    b.HasOne("Silk.Core.Data.Models.User", "User")
                        .WithOne("History")
                        .HasForeignKey("Silk.Core.Data.Models.UserHistory", "UserId", "GuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Guild", b =>
                {
                    b.Navigation("Configuration")
                        .IsRequired();

                    b.Navigation("Infractions");

                    b.Navigation("ModConfig")
                        .IsRequired();

                    b.Navigation("Tags");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.GuildConfig", b =>
                {
                    b.Navigation("DisabledCommands");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.GuildModConfig", b =>
                {
                    b.Navigation("AllowedInvites");

                    b.Navigation("InfractionSteps");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.Tag", b =>
                {
                    b.Navigation("Aliases");
                });

            modelBuilder.Entity("Silk.Core.Data.Models.User", b =>
                {
                    b.Navigation("History")
                        .IsRequired();

                    b.Navigation("Infractions");
                });
#pragma warning restore 612, 618
        }
    }
}
