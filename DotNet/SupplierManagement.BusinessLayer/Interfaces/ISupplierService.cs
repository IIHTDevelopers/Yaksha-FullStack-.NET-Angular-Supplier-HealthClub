using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.BusinessLayer.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierData> AddSupplier(SupplierData supplierData);
        Task<SupplierData> FindSupplierById(int supplierId);
        Task<SupplierData> UpdateSupplier(SupplierViewModel model);
        Task<SupplierData> DeleteSupplierById(int supplierId);
        Task<IEnumerable<SupplierData>> ListAllSupplier();
    }
}
