﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TinyTwoProjectManager.Models
{
    public class Task : DatabaseTable
    {
        public int? TaskGroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool Complete { get; set; }

        public DateTime? FirstDateCompleted { get; set; }

        public DateTime? LastDateCompleted { get; set; }

        public int TimesCompleted { get; set; }

        [Required]
        public string UserId { get; set; }


        public virtual ApplicationUser User { get; set; }

        public virtual TaskGroup TaskGroup { get; set; }
    }
}