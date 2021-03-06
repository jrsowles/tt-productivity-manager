﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Setting : Entity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string DefaultValue { get; set; }

        public virtual ICollection<UserSetting> UserSettings { get; set; }
    }
}