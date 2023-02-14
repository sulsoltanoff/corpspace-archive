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

using ChatSpace.Domain.Entities.Team;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corpspace.ChatSpace.Infrastructure.EntityConfiguration;

public class TeamTypeConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");
        
        builder.HasKey(team => team.Id);
        
        builder.Property(team => team.Name).IsRequired().HasMaxLength(256);
        
        builder.Property(team => team.DisplayName).IsRequired().HasMaxLength(256);
        
        builder.Property(team => team.Description).HasMaxLength(512);
        
        builder.Property(team => team.ModificationAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.Property(team => team.CreationAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        builder.Property(team => team.DeletionAt).IsRequired(false);
        
        builder.Property(team => team.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasMany(team => team.Members).WithOne().HasForeignKey(member => member.TeamId);
        
        builder.HasMany(team => team.Admins).WithOne().HasForeignKey(admin => admin.TeamId);
    }
}