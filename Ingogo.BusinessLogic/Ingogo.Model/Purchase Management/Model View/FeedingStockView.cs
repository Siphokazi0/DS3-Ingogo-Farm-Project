using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//21225381 SD FIKENI: Changed namespace from 'Ingogo.Model' to
//'Ingogo.Model.Purchase_Management.Model_View'

namespace Ingogo.Model.Purchase_Management.Model_View
{
    public class FeedingStockView //: IEnumerable, IDisposable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedingStockId { get; set; }

        [Required(ErrorMessage = "Enter Item Name")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Enter Number Of Item")]
        [Display(Name = "Number of Items")]
        public int NumberOfItems { get; set; }

        [Required(ErrorMessage = "Enter Mass in Kg(s)")]
        [Display(Name = "Mass(kg)")]
        public int Mass { get; set; }

        [Required(ErrorMessage = "Enter Item Price")]
        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }

        [Required(ErrorMessage = "Select Purchase Date")]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfPurchase { get; set; }

        [Required(ErrorMessage = "Select Expairy Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Expairy Date")]
        public DateTime ExpairyDate { get; set; }

        [Display(Name = "Total Mass")]
        public double TotalMass { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
    }
}
