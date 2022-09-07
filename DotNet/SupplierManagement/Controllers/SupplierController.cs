using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierManagement.BusinessLayer.Interfaces;
using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplierManagement.Controllers
{
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;
        public SupplierController(ISupplierService supplierService, IProductService productService)
        {
            _supplierService = supplierService;
            _productService = productService;
        }

        #region SupplierRegion
        /// <summary>
        /// Add a new Supplier
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Supplier/Add-Supplier")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSupplier([FromBody] SupplierViewModel model)
        {
            var supplierExists = await _supplierService.FindSupplierById(model.SupplierID);
            if (supplierExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Supplier already exists!" });
            //New object and value for user
            SupplierData supplierData = new SupplierData()
            {
                SupplierID=model.SupplierID,
                SupplierCompanyName=model.SupplierCompanyName,
                Address=model.Address,
                ContactPerson=model.ContactPerson,
                Email=model.Email,
                PhoneNumber=model.PhoneNumber
            };
            var result = await _supplierService.AddSupplier(supplierData);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Supplier creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "Supplier created successfully!" });

        }

        /// <summary>
        /// Update a existing Supplier
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Supplier/Update-Supplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] SupplierViewModel model)
        {
            var supplier = await _supplierService.FindSupplierById(model.SupplierID);
            if (supplier == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Supplier With Id = {model.SupplierID} cannot be found" });
            }
            else
            {
                var result = await _supplierService.UpdateSupplier(model);
                return Ok(new Response { Status = "Success", Message = "Supplier Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing Supplier
        /// </summary>
        /// <param name="SupplierId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Supplier/Delete-Supplier/{SupplierId}")]
        public async Task<IActionResult> DeleteSupplier(int SupplierId)
        {
            var supplier = await _supplierService.FindSupplierById(SupplierId);
            if (supplier == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Supplier With Id = {SupplierId} cannot be found" });
            }
            else
            {
                var result = await _supplierService.DeleteSupplierById(SupplierId);
                return Ok(new Response { Status = "Success", Message = "Supplier deleted successfully!" });
            }
        }

        /// <summary>
        /// Get Supplier by Id
        /// </summary>
        /// <param name="SupplierId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Supplier/Get-Supplier/{SupplierId}")]
        public async Task<IActionResult> GetSupplierById(int SupplierId)
        {
            var supplier = await _supplierService.FindSupplierById(SupplierId);
            if (supplier == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Supplier With Id = {SupplierId} cannot be found" });
            }
            else
            {
                return Ok(supplier);
            }
        }

        /// <summary>
        /// List All Suppliers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Supplier/All-Suppliers")]
        public async Task<IEnumerable<SupplierData>> ListAllSuppliers()
        {
            return await _supplierService.ListAllSupplier();
        }
        #endregion


        #region Product
        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Product/Add-Product")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel model)
        {
            var productExists = await _productService.FindProductById(model.ProductID);
            if (productExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Product already exists!" });
            //New object and value for user
            ProductData productData = new ProductData()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                Price = model.Price,
                Quantity = model.Quantity,
                SupplierId = model.SupplierId,
            };
            var result = await _productService.AddProduct(productData);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Product creation failed! Please check product details and try again." });

            return Ok(new Response { Status = "Success", Message = "Product created successfully!" });

        }

        /// <summary>
        /// Update a existing Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("product/Update-product")]
        public async Task<IActionResult> Updateproduct([FromBody] ProductViewModel model)
        {
            var product = await _productService.FindProductById(model.ProductID);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With Id = {model.ProductID} cannot be found" });
            }
            else
            {
                var result = await _productService.UpdateProduct(model);
                return Ok(new Response { Status = "Success", Message = "Product Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing Product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Product/Delete-Product/{ProductId}")]
        public async Task<IActionResult> DeletwProduct(int ProductId)
        {
            var product = await _productService.FindProductById(ProductId);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With Id = {ProductId} cannot be found" });
            }
            else
            {
                var result = await _productService.DeleteProductById(ProductId);
                return Ok(new Response { Status = "Success", Message = "Product deleted successfully!" });
            }
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Product/Get-Product/{ProductId}")]
        public async Task<IActionResult> GetProductById(int ProductId)
        {
            var product = await _productService.FindProductById(ProductId);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Product With Id = {ProductId} cannot be found" });
            }
            else
            {
                return Ok(product);
            }
        }

        /// <summary>
        /// List All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Product/All-Products")]
        public async Task<IEnumerable<ProductData>> ListAllProducts()
        {
            return await _productService.ListAllProducts();
        }
        #endregion
    }
}
