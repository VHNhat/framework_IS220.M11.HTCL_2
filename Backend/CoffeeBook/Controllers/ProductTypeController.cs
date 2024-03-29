﻿using CoffeeBook.DataAccess;
using CoffeeBook.Models;
using CoffeeBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeBook.Controllers
{
    /*[Route("api/[controller]")]*/
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductTypeService service;
        private readonly Context context;

        public ProductTypeController(IConfiguration config, Context ctx)
        {
            _config = config;
            context = ctx;
            service = new ProductTypeService(_config, context);
        }

        [Route("ProductTypes")]
        [HttpGet]
        public JsonResult Get()
        {
            List<ProductType> table = service.FindAll();
            return new JsonResult(table);
        }

        [Route("ProductType/{id}")]
        [HttpGet]
        public ActionResult GetById(int id)
        {
            ProductType type = service.GetProductTypeById(id);
            if (type == null) return BadRequest();
            return new JsonResult(type);
        }

        [Route("ProductType/create")]
        [HttpPost]
        public ActionResult Post(ProductType productType)
        {
            string jwt = Request.Cookies["jwt"];
            if (!string.IsNullOrEmpty(jwt))
            {
                var Role = getCurrentRole(jwt);
                if (Role == "1" || Role == "2")
                {
                    if (ModelState.IsValid)
                    {
                        if (service.Post(productType) > 0)
                        {
                            return Ok();
                        }

                    }
                    return BadRequest();
                }
            }
            return Unauthorized(new { message = "Bạn không có quyền truy cập" });
        }

        [Route("ProductType/update/{id}")]
        [HttpPut]
        public ActionResult Put(int id, ProductType productType)
        {
            string jwt = Request.Cookies["jwt"];
            if (!string.IsNullOrEmpty(jwt))
            {
                var Role = getCurrentRole(jwt);
                if (Role == "1" || Role == "2")
                {
                    if (ModelState.IsValid)
                    {
                        if (service.Put(id, productType) > 0)
                            return Ok();
                    }
                    return BadRequest();
                }
            }
            return Unauthorized(new { message = "Bạn không có quyền truy cập" });
        }

        [Route("ProductType/delete/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string jwt = Request.Cookies["jwt"];
            if (!string.IsNullOrEmpty(jwt))
            {
                var Role = getCurrentRole(jwt);
                if (Role == "1" || Role == "2")
                {
                    if (service.Delete(id) > 0)
                        return Ok();

                    return BadRequest();
                }
            }
            return Unauthorized(new { message = "Bạn không có quyền truy cập" });
        }

        private string getCurrentRole(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = jsonToken as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == "RoleId").Value;
            return role;
        }
    }
}
