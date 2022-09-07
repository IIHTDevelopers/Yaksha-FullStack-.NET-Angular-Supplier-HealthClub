using SupplierManagement.BusinessLayer.Interfaces;
using SupplierManagement.BusinessLayer.Services.Repository;
using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupplierManagement.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       
        public async Task<ProductData> AddProduct(ProductData productData)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductData> FindProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductData> DeleteProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductData> UpdateProduct(ProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductData>> ListAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}