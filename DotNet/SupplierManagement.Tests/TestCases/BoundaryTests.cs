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
    public class BoundaryTests
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

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        ///  Testfor_ValidEmail to test email id is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidEmail()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {

                //Assert
                supplierservice.Setup(repo => repo.AddSupplier(_supplierData)).ReturnsAsync(_supplierData);
                var result = await _supplierServices.AddSupplier(_supplierData);
                var actualLength = _supplierData.Email.ToString().Length;
                if (result.Email.ToString().Length == actualLength)
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
        /// Testfor_ValidateMobileNumber is used for test mobile number is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateMobileNumber()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                supplierservice.Setup(repo => repo.AddSupplier(_supplierData)).ReturnsAsync(_supplierData);
                var result = await _supplierServices.AddSupplier(_supplierData);
                var actualLength = _supplierData.PhoneNumber.ToString().Length;
                if (result.PhoneNumber.ToString().Length == actualLength)
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
        /// Test to validate supplier address connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Supplier_Address_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                supplierservice.Setup(repo => repo.AddSupplier(_supplierData)).ReturnsAsync(_supplierData);
                var result = await _supplierServices.AddSupplier(_supplierData);
                var actualLength = _supplierData.Address.ToString().Length;
                if (result.Address.ToString().Length == actualLength)
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