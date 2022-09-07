using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.BusinessLayer.Services.Repository
{
    public interface IProductRepository
    {
        Task<ProductData> AddProduct(ProductData productData);
        Task<ProductData> FindProductById(int productId);
        Task<ProductData> DeleteProductById(int productId);
        Task<ProductData> UpdateProduct(ProductViewModel model);
        Task<IEnumerable<ProductData>> ListAllProducts();
    }
}
