﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class StorageLog
    {
        [Key]
        public int StorageLogId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }

        [StringLength(25)]
        public string LogDate { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public virtual Storage Storage {get;set; }

        public int Count { get; set; }


    }
}
