using book_worm_api.Data;
using book_worm_api.Models;
using book_worm_api.Models.Dto;
using book_worm_api.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace book_worm_api.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
            _response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            _response.Result = _db.Books;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}", Name = "GetBook")]
        public async Task<IActionResult> GetBook(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            Book book = _db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.Result = book;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateBook([FromForm] BookCreateDTO bookCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (bookCreateDTO.ImageURL == null)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest();
                    }
                    //string fileName = $"{Guid.NewGuid()}{Path.GetExtension(bookCreateDTO.File.FileName)}";
                    Book bookToCreate = new()
                    {
                        Name = bookCreateDTO.Name,
                        Price = bookCreateDTO.Price,
                        Genre = bookCreateDTO.Genre,
                        Description = bookCreateDTO.Description,
                        ImageURL = bookCreateDTO.ImageURL
                    };
                    _db.Books.Add(bookToCreate);
                    _db.SaveChanges();

                    _response.Result = bookToCreate;
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetBook", new { id = bookToCreate.Id }, _response);

                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateBook(int id, [FromForm] BookUpdateDTO bookUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (bookUpdateDTO == null || id != bookUpdateDTO.Id)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest();
                    }
                    //Book bookFromDb = await _db.Books.FirstOrDefaultAsync(x=>x.Id==id);
                    Book bookFromDb = await _db.Books.FindAsync(id);

                    if (bookFromDb == null)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest();
                    }

                    bookFromDb.Name = bookUpdateDTO.Name;
                    bookFromDb.Price = bookUpdateDTO.Price;
                    bookFromDb.Genre = bookUpdateDTO.Genre;
                    bookFromDb.Description = bookUpdateDTO.Description;
                    bookFromDb.ImageURL = bookUpdateDTO.ImageURL;

                    //TODO: Adjust for Image local storage.

                    _db.Books.Update(bookFromDb);
                    _db.SaveChanges();

                    _response.StatusCode = HttpStatusCode.NoContent;
                    return Ok(_response);

                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteMenuItem(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                Book bookFromDb = await _db.Books.FindAsync(id);

                if (bookFromDb == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }

                //TODO: Adjust for local storage.
             
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);

                _db.Books.Remove(bookFromDb);
                _db.SaveChanges();

                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
