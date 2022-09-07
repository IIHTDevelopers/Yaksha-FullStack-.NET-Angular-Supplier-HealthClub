using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        Task<ProductData> AddProduct(ProductData productData);
        Task<ProductData> FindProductById(int productId);
        Task<ProductData> DeleteProductById(int productId);
        Task<ProductData> UpdateProduct(ProductViewModel model);
        Task<IEnumerable<ProductData>> ListAllProducts();
    }
}
