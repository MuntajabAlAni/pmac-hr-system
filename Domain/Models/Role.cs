using System;
using System.Collections.Generic;
using System.ComponentModel;
using Domain.Attributes;
using Domain.Enums;

namespace Domain.Models
{
    public class Role
    {
        [IgnoreChange]
        public Guid Id { get; set; }

        [System.ComponentModel.DisplayName("وصف الدور")]
        public string Description { get; set; } = null!;

        [System.ComponentModel.DisplayName("الصلاحيات")]
        public List<Permission> Permissions { get; set; } = new();
    }
}