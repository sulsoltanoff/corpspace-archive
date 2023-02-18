﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Corpspace.ChatSpace.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Corpspace.ChatSpace.Infrastructure.Migrations
{
    [DbContext(typeof(ChatAppContext))]
    partial class ChatAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ChannelsType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(76)
                        .HasColumnType("character varying(76)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastPostAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .HasMaxLength(76)
                        .HasColumnType("character varying(76)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Channel");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Channels.ChannelType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("ChannelType");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Draft", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ChannelId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Draft");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
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

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FileIds")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasReactions")
                        .HasColumnType("boolean");

                    b.Property<string>("Hashtags")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool?>("IsFollowing")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("MetadataId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("OriginalId")
                        .HasColumnType("uuid");

                    b.Property<string>("Participants")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Props")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ReplyCount")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("CreationAt");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("MetadataId");

                    b.ToTable("ChatSpace_Message");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Metadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Acknowledgements")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Embeds")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Emojis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Files")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Reactions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Metadata");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.ThreadResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastReplyAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("LastViewedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

                    b.ToTable("ChatSpace_ThreadResponse");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Messages.Threads", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<long>("Total")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnreadMentions")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnreadThreads")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalUnreadUrgentMentions")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Threads");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.Team.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("512");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(76)
                        .HasColumnType("character varying(76)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(76)
                        .HasColumnType("character varying(76)");

                    b.HasKey("Id");

                    b.ToTable("ChatSpace_Team");
                });

            modelBuilder.Entity("ChatSpace.Domain.Entities.User.ChatUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BotDescription")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime?>("BotLastIconUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ChannelId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletionAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool?>("EmailVerified")
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

                    b.Property<DateTime>("JoinTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("LastActivityAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime?>("LastPictureUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Locale")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<DateTime?>("ModificationAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Dictionary<string, string>>("NotifyProps")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("Props")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ThreadResponseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserTeamId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TeamId");

                    b.HasIndex("ThreadResponseId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserTeamId");

                    b.ToTable("ChatSpace_User");
                });

            modelBuilder.Entity("UserChannel", b =>
                {
                    b.Property<Guid>("ChannelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ChannelId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChannel");

                    b.HasData(
                        new
                        {
                            ChannelId = new Guid("c73e09c9-2427-4e3d-bb08-244bb93f1f23"),
                            UserId = new Guid("206b50ae-13da-4e23-9483-350c65794917")
                        });
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
                    b.HasOne("ChatSpace.Domain.Entities.Channels.AppChannel", null)
                        .WithMany()
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.Team.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("ChatSpace.Domain.Entities.Messages.ThreadResponse", null)
                        .WithMany("Participants")
                        .HasForeignKey("ThreadResponseId");

                    b.HasOne("ChatSpace.Domain.Entities.User.ChatUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.Team.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("UserTeamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("UserChannel", b =>
                {
                    b.HasOne("ChatSpace.Domain.Entities.Channels.AppChannel", null)
                        .WithMany()
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChatSpace.Domain.Entities.User.ChatUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
