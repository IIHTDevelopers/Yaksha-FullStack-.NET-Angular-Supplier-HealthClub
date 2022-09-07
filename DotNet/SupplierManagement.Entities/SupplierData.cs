using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SupplierManagement.Entities
{
    public class SupplierData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }
        public string SupplierCompanyName { get; set; }
        public string ContactPerson{ get; set; }
        public string Email { get; set; }
        public int PhoneNumber{ get; set; }
        public string Address { get; set; }
    }
}