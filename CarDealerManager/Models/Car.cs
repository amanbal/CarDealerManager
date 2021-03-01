using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealerManager.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Car Brand Name")]
        public string CarBrandName { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Year Needs 4 numbers")]
        [Display(Name = "Year")]
        public string CarYear { get; set; }

        [Required]
        [Display(Name = "Fuel Type")]
        public FuelType Fuel { get; set; }

        [Required]
        [Display(Name = "Transmission Type")]
        public TransmissionType Transmission { get; set; }

        [Required]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "InStock")]
        public int InStock { get; set; }

        [ForeignKey("SupplierFK")]
        [Display(Name = "Supplier")]
        public Supplier supplier { get; set; }
        public int SupplierFK { get; set; }
    }

    public enum FuelType
    {
        Diesel,
        BioFuel,
        EthanolFuel,
        Electrical,
        Hybrid
    }

    public enum TransmissionType
    {
        Automatic,
        Manual,
        CVT,
        DCT,
        DSG,
        Tiptronic
    }
}
