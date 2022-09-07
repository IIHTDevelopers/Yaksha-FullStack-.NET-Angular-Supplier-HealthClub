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
    public class ExceptionalTests
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

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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

        /// <summary>
        /// Test to validate if supplier id must be greater than 0.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidSupplierIdIsPassed()
        {
            //Arrange
            bool res = false;
            _productData.SupplierId = 2;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                productservice.Setup(repo => repo.AddProduct(_productData)).ReturnsAsync(_productData);
                var result = await _productServices.AddProduct(_productData);
                if (result != null || result.SupplierId > 0)
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
        /// Test to validate if Price must be greater then 0 or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Vaidate_PriceIsValidOrNot()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                productservice.Setup(repo => repo.AddProduct(_productData)).ReturnsAsync(_productData);
                var result = await _productServices.AddProduct(_productData);
                if (result != null && result.Price >= 0 )
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
    }
}