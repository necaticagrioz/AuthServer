﻿using AuthServer.Core.DTO_s;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IServiceGeneric<Product, ProductDTO> _productService;

        public ProductController(IServiceGeneric<Product, ProductDTO> productService)
        {
             _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return ActionResultInstance(await _productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProducts(ProductDTO productDTO)
        {
            return ActionResultInstance(await _productService.AddAsync(productDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpateProduct(ProductDTO productDTO)
        {
            return ActionResultInstance(await _productService.Update(productDTO, productDTO.Id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return ActionResultInstance(await _productService.Remove(id));
        }
    }
}
