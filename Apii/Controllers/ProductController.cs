﻿using API.IServices;
using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly ServiceContext _serviceContext;

        public ProductController(ISecurityService securityService, IProductService productService, IUserService userService, ServiceContext serviceContext)
        {
            _productService = productService;
            _securityService = securityService;
            _userService = userService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] ProductItem productItem)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);

            if (validCredentials == true)
            {
                return _productService.InsertProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }

        }

        [HttpDelete(Name = "DeleteProduct")]
        public void Delete([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int Id)
        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);

            if (validCredentials == true)
            {
                _productService.DeleteProduct(Id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModifyProduct")]
        public void Patch([FromQuery] string userName,
                          [FromQuery] string userPassword,
                          [FromQuery] int id,
                          [FromBody]  ProductItem productItem)

        {
            var validCredentials = _securityService.ValidateUserCredentials(userName, userPassword, 1);
            if (validCredentials == true)
            {
                _productService.UpdateProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        //[HttpGet(Name = "GetProductsByCriteria")]
        //public List<ProductItem> GetProductByCriteria([FromQuery]string ProductBrand)
        //{

        //    return _productService.GetProductByCriteria(ProductBrand);
        //}

        [HttpGet(Name = "GetAllProducts")]
        public List<ProductItem> GetAll()
        {

            return _productService.GetAll();
        }

        [HttpGet(Name = "GetProductById")]
        public List<ProductItem> GetProductById([FromQuery] int id)
        {

            return _productService.GetProductById(id);
        }

    }
}