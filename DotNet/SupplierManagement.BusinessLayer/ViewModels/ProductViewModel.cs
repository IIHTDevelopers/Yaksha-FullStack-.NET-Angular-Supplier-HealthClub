using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierManagement.BusinessLayer.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Quntity is required")]
        public string Quantity { get; set; }
        [Required(ErrorMessage = "SupplierId is required")]
        public int SupplierId { get; set; }
    }
}
