using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierManagement.BusinessLayer.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public int SupplierID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string SupplierCompanyName { get; set; }
        [Required(ErrorMessage = "Contact is required")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
