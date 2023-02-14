﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Corpspace.ChatSpace.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Corpspace.ChatSpace.Infrastructure.Migrations
{
    [DbContext(typeof(ChatAppContext))]
    [Migration("20230214162146_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChatSpace.Domain.Entities.Channels.AppChannel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ChannelsType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(76)
                        .HasColumnType("character varying(76)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastPostAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(76)
                        .HasColumnType("character varying(76)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Channel");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Channels.ChannelMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("ModificationAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("ChatUserId");

                    b.ToTable("ChannelMembers", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Draft", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Drafts", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("ModificationAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Image");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<string>>("FileIds")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("HasReactions")
                        .HasColumnType("boolean");

                    b.Property<string>("Hashtags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsFollowing")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MetadataId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OriginalId")
                        .HasColumnType("uuid");

                    b.Property<long>("ReplyCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MetadataId");

                    b.ToTable("ChatSpace_Message");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Metadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Acknowledgements")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("Acknowledgements");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreationAt");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("DeletionAt");

                    b.Property<List<string>>("Embeds")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("Embeds");

                    b.Property<List<string>>("Emojis")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("Emojis");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime>("ModificationAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ModificationAt");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Priority");

                    b.Property<List<string>>("Reactions")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("Reactions");

                    b.HasKey("Id");

                    b.ToTable("Metadatas", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.ThreadResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("boolean");

                    b.Property<long>("LastReplyAt")
                        .HasColumnType("bigint");

                    b.Property<long>("LastViewedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MessageId")
                        .HasMaxLength(200)
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ReplyCount")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ThreadsId")
                        .HasColumnType("uuid");

                    b.Property<long>("UnreadMentions")
                        .HasColumnType("bigint");

                    b.Property<long>("UnreadReplies")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.HasIndex("ThreadsId");

                    b.ToTable("ThreadResponse", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Threads", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModificationAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Total")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnreadMentions")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnreadThreads")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnreadUrgentMentions")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Threads", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Team.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("ModificationAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.User.ChatUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BotDescription")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<long>("BotLastIconUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L);

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("FailedAttempts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<bool>("IsBot")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("LastActivityAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime>("LastPictureUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Locale")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModificationAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Dictionary<string, string>>("NotifyProps")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Dictionary<string, string>>("Props")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeamId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ThreadResponseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("TeamId");

                    b.HasIndex("TeamId1");

                    b.HasIndex("ThreadResponseId");

                    b.ToTable("ChatUsers", (string)null);
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Channels.ChannelMember", b =>
                {
                    b.HasOne("ChatSpace.Domain.Entities.Channels.AppChannel", "Channel")
                        .WithMany("ChannelMembers")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.User.ChatUser", "ChatUser")
                        .WithMany()
                        .HasForeignKey("ChatUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("ChatUser");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Message", b =>
                {
                    b.HasOne("ChatSpace.Domain.Entities.Messages.Metadata", "Metadata")
                        .WithMany()
                        .HasForeignKey("MetadataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.ThreadResponse", b =>
                {
                    b.HasOne("ChatSpace.Domain.Entities.Messages.Message", "Message")
                        .WithOne()
                        .HasForeignKey("ChatSpace.Domain.Entities.Messages.ThreadResponse", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.Messages.Threads", "AppThreads")
                        .WithMany("ThreadResponses")
                        .HasForeignKey("ThreadsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppThreads");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.User.ChatUser", b =>
                {
                    b.HasOne("ChatSpace.Domain.Entities.Messages.Message", null)
                        .WithMany("Participants")
                        .HasForeignKey("MessageId");

                    b.HasOne("ChatSpace.Domain.Entities.Team.Team", null)
                        .WithMany("Admins")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.Team.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.Messages.ThreadResponse", null)
                        .WithMany("Participants")
                        .HasForeignKey("ThreadResponseId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Channels.AppChannel", b =>
                {
                    b.Navigation("ChannelMembers");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Message", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.ThreadResponse", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Threads", b =>
                {
                    b.Navigation("ThreadResponses");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Team.Team", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
