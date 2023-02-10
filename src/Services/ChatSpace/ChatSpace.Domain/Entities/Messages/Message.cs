#region Corpspace© Apache-2.0
// Copyright © 2023 The Corpspace Technologies. All rights reserved.
// Author: Sultan Soltanov
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatSpace.Domain.Entities.User;
using ChatSpace.Domain.Constants;
using Corpspace.Commons.Domain.Entities;
using Corpspace.Commons.Domain.Entities.Auditing;

namespace ChatSpace.Domain.Entities.Messages;

[Table($"{GeneralConstants.ServiceName}_Message")]
public class Message : Entity<Guid>, IHasModificationTime
{
    public Message(Guid userId, Guid channelId, Guid originalId, bool isPinned, 
        string content, string type, Dictionary<string, object> props, string hashtags, 
        List<string> fileIds, bool hasReactions, long replyCount, List<ChatUser> participants, 
        bool? isFollowing, Metadata metadata, DateTime modificationAt, DateTime creationAt, DateTime? deletionAt, bool isDeleted)
    {
        UserId = userId;
        ChannelId = channelId;
        OriginalId = originalId;
        IsPinned = isPinned;
        Content = content;
        Type = type;
        Props = props;
        Hashtags = hashtags;
        FileIds = fileIds;
        HasReactions = hasReactions;
        ReplyCount = replyCount;
        Participants = participants;
        IsFollowing = isFollowing;
        Metadata = metadata;
        ModificationAt = modificationAt;
        CreationAt = creationAt;
        DeletionAt = deletionAt;
        IsDeleted = isDeleted;
    }

    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public Guid ChannelId { get; set; }
    
    public Guid OriginalId { get; set; }

    public bool IsPinned { get; set; }

    [Required]
    [StringLength(GeneralConstants.MaxMessageLength)]
    public string Content { get; set; }

    public string Type { get; set; }
    
    public Dictionary<string, object> Props { get; set; }
    
    public string Hashtags { get; set; }
    
    public List<string> FileIds { get; set; }

    public bool HasReactions { get; set; }

    public long ReplyCount { get; set; }

    public List<ChatUser> Participants { get; set; }
    
    public bool? IsFollowing { get; set; }
    
    public Metadata Metadata { get; set; }

    public DateTime ModificationAt { get; set; }
    
    public DateTime CreationAt { get; set; }
    
    public DateTime? DeletionAt { get; set; }
    
    public bool IsDeleted { get; set; }
}
