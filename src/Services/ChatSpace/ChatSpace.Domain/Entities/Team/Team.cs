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

namespace ChatSpace.Domain.Entities.Team;

[Table($"{GeneralConstants.ServiceName}_Team")]
public class Team : Entity<Guid>, IHasModificationTime
{
    public string Name { get; set; }
    
    public string DisplayName { get; set; }
    
    public string Description { get; set; }

    public List<ChatUser> Members { get; set; }
    
    public List<ChatUser> Admins { get; set; }

    public DateTime ModificationAt { get; set; }
    
    public DateTime CreationAt { get; set; }
    
    public DateTime? DeletionAt { get; set; }
    
    public bool IsDeleted { get; set; }
}