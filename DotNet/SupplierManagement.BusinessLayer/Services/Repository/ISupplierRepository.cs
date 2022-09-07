using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.BusinessLayer.Services.Repository
{
    public interface ISupplierRepository
    {
        Task<SupplierData> AddSupplier(SupplierData supplierData);
        Task<SupplierData> FindSupplierById(int supplierId);
        Task<SupplierData> DeleteSupplierById(int supplierId);
        Task<SupplierData> UpdateSupplier(SupplierViewModel model);
        Task<IEnumerable<SupplierData>> ListAllSupplier();
    }
}
