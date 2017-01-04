using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int ShipActivityId { get; set; }
        public virtual ShipActivity job { get; set; }
        public string Name { get; set; }
        public Duration MaintanceDuration { get; set; }
        public Status status { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DueDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LastDone { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Due RunningHours must be a positive number")]
        public int? DueRunningHours { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Last Done RunningHours must be a positive number")]
        public int? LastDoneRunningHours { get; set; }
        public bool Critical { get; set; }
        [StringLength(int.MaxValue)]
        public string Comments { get; set; }

    }

    public enum Duration
    {
        [Display(Name = "Running Hours")]
        Hours,
        Days,
    }

    public enum Status
    {
        Due,
        Scheduled,
        Overdue
    }


}