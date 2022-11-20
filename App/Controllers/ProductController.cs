﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Product;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers
{
    public class ProductController : AppController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService= productService;
        }


       [Authorize(Roles ="SuperAdmin")]
       [HttpPost]
       public async Task<IActionResult> Create([FromBody]ProductCreateDto product)
       {
            await _productService.CreateAsync(product);
            return Ok();
       }


        [Authorize(Roles = "Member")]
        [HttpGet]
       public async Task<IActionResult> GetAll()
       {
            return Ok(await _productService.GetAllAsync());
       }


        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();  
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete([Required] int id)
        {
            try
            {
                await _productService.SoftDeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id,ProductUpdateDto product)
        {
            try
            {
                await _productService.UpdateAsync(id,product);
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }

        }
        [Authorize(Roles = "Member")]
        [HttpGet]
        public async Task<IActionResult> Serach(string? search)
        {
            return Ok(await _productService.SearchAsync(search));
        } 


    }
}
