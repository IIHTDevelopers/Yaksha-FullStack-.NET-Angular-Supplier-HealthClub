using Moq;
using SupplierManagement.BusinessLayer.Interfaces;
using SupplierManagement.BusinessLayer.Services;
using SupplierManagement.BusinessLayer.Services.Repository;
using SupplierManagement.BusinessLayer.ViewModels;
using SupplierManagement.DataLayer;
using SupplierManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace SupplierManagement.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly SupplierDbContext _supplierContext;

        private readonly ISupplierService _supplierServices;
        private readonly IProductService _productServices;
        

        public readonly Mock<ISupplierRepository> supplierservice = new Mock<ISupplierRepository>();
        public readonly Mock<IProductRepository> productservice = new Mock<IProductRepository>();
        

        private readonly SupplierData _supplierData;
        private readonly ProductData _productData;
       
        private readonly SupplierViewModel _supplierViewModel;
        private readonly ProductViewModel _productViewModel;
       
        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _supplierServices = new SupplierService(supplierservice.Object);
            _productServices = new ProductService(productservice.Object);
            
            _output = output;

            _supplierData = new SupplierData
            {
                SupplierID = 1,
                SupplierCompanyName = "Compony1",
                ContactPerson = "Person1",
                Email = "s@gmail.com",
                PhoneNumber = 987623983,
                Address = "Address1",
            };
            _productData = new ProductData
            {
                ProductID = 1,
                ProductName = "product1",
                Price = 150,
                Quantity = "2",
                SupplierId = 1,
            };

            _supplierViewModel = new SupplierViewModel
            {
                SupplierID = 1,
                SupplierCompanyName = "Compony1",
                ContactPerson = "Person1",
                Email = "s@gmail.com",
                PhoneNumber = 987623983,
                Address = "Address1",
            };
            _productViewModel = new ProductViewModel
            {
                ProductID = 1,
                ProductName = "product1",
                Price = 150,
                Quantity = "2",
                SupplierId = 1,
            };
        }
        #region RegionSupplier
        /// <summary>
        /// Test to add new supplier.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Supplier()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                supplierservice.Setup(repos => repos.AddSupplier(_supplierData)).ReturnsAsync(_supplierData);
                var result = await _supplierServices.AddSupplier(_supplierData);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Using the below test method Update supplier by using supplier Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Supplier()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateSupplier = new SupplierViewModel()
            {
                SupplierID = 1,
                SupplierCompanyName = "Compony1",
                ContactPerson = "Person1",
                Email = "s@gmail.com",
                PhoneNumber = 987623983,
                Address = "Address1",
            };
            //Act
            try
            {
                supplierservice.Setup(repos => repos.UpdateSupplier(_updateSupplier)).ReturnsAsync(_supplierData); 
                var result = await _supplierServices.UpdateSupplier(_updateSupplier);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        /// <summary>
        /// Test to list all Suppliers 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Suppliers()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                supplierservice.Setup(repos => repos.ListAllSupplier());
                var result = await _supplierServices.ListAllSupplier();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to find Supplier by Supplier Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindSupplierById()
        {
            //Arrange
            var res = false;
            int supplierId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                supplierservice.Setup(repos => repos.FindSupplierById(supplierId)).ReturnsAsync(_supplierData);
                var result = await _supplierServices.FindSupplierById(supplierId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to Delete Supplier by Supplier Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DeleteSupplierById()
        {
            //Arrange
            var res = false;
            int supplierId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                supplierservice.Setup(repos => repos.DeleteSupplierById(supplierId)).ReturnsAsync(_supplierData);
                var result = await _supplierServices.DeleteSupplierById(supplierId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        #endregion 

        #region RegionProduct
        /// <summary>
        /// Test to add new product.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Product()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.AddProduct(_productData)).ReturnsAsync(_productData); 
                var result = await _productServices.AddProduct(_productData);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to update product.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Product()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateProduct = new ProductViewModel()
            {
                ProductID = 1,
                ProductName = "product1",
                Price = 150,
                Quantity = "2",
                SupplierId = 1,
            };
            //Act
            try
            {
                productservice.Setup(repos => repos.UpdateProduct(_updateProduct)).ReturnsAsync(_productData);
                var result = await _productServices.UpdateProduct(_updateProduct);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to list all products.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Products()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.ListAllProducts());
                var result = await _productServices.ListAllProducts();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to find product by product id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindProductById()
        {
            //Arrange
            var res = false;
            int productId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.FindProductById(productId)).ReturnsAsync(_productData);
                var result = await _productServices.FindProductById(productId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to delete product by product id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DeleteProductById()
        {
            //Arrange
            var res = false;
            int productId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                productservice.Setup(repos => repos.DeleteProductById(productId)).ReturnsAsync(_productData);
                var result = await _productServices.DeleteProductById(productId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
        #endregion 
    }
}