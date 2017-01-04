using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Models
{
    public class ShipActivity
    {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public virtual Ship ship { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity activity { get; set; }

    }

    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ComponentId { get; set; }
        public virtual Component Component { get; set; }
        public Type MaintenanceType { get; set; }
        
    }

    public enum Type
    {
        [Display(Name = "Machinery Maintenance")]
        Machinery,
        [Display(Name = "Deck Maintenance")]
        Deck,
        [Display(Name = "Alarms and Trip Tests")]
        Tests
    }

    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }


}