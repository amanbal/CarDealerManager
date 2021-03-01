using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerManager.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Of Purchase")]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        [Display(Name = "Warranty Duration (Number of Years)")]
        public int WarrantyDuration { get; set; }

        [ForeignKey("CarFK")]
        public Car car { get; set; }
        [Display(Name = "Car")]
        public int CarFK { get; set; }

        [ForeignKey("CustomerFK")]
        public Customer customer { get; set; }
        [Display(Name = "Customer")]
        public int CustomerFK { get; set; }
    }
}
