#region Corpspace© Apache-2.0
// Copyright © 2023 Sultan Soltanov. All rights reserved.
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

using System.ComponentModel.DataAnnotations.Schema;
using ChatSpace.Domain.Constants;
using ChatSpace.Domain.Entities.User;
using Corpspace.Commons.Domain.Entities;
using Corpspace.Commons.Domain.Entities.Auditing;

namespace ChatSpace.Domain.Entities.Messages;

public class ChatThreadResponse : Entity<Guid>, IHasModificationTime
{
    public Guid MessageId { get; set; }
    
    public long ReplyCount { get; set; }
    
    public DateTime? LastReplyAt { get; set; }
    
    public DateTime? LastViewedAt { get; set; }
    
    public List<AppUser> Participants { get; set; }
    
    public Guid ThreadsId { get; set; }
    
    public ChatThreads AppChatThreads { get; set; }
    
    public Message Message { get; set; }

    public long UnreadReplies { get; set; }
    
    public long UnreadMentions { get; set; }
    
    public bool IsUrgent { get; set; }

    public DateTime? ModificationAt { get; set; }
    
    public DateTime? CreationAt { get; set; }
    
    public DateTime? DeletionAt { get; set; }
    
    public bool IsDeleted { get; set; }
}