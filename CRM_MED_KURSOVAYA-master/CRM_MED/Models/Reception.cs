using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_MED.Models
{
    public class Reception
    {
        [Key]
        public int ReceptionId { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; } = null!;

        [StringLength(300)]
        public string Report { get; set; }

        [StringLength(10)]
        public string StartTime { get; set; }

        [StringLength(20)]

        public int DayOfWeekId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
