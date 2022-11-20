﻿using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace App.Controllers
{
    public class BookController : AppController
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDTO book)
        {
            await _bookService.CreateAsync(book);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
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
                await _bookService.SoftDeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? search)
        {
            return Ok(await _bookService.SearchAsync(search));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, BookUpdateDTO book)
        {
            try
            {
                await _bookService.UpdateAsync(id, book);
                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _bookService.GetByIdAsync(id));
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }
        }
    }
}
