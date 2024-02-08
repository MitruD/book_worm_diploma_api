using book_worm_api.Data;
using book_worm_api.Models;
using book_worm_api.Models.Dto;
using book_worm_api.Utility;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public BookController(IWebHostEnvironment hostEnvironment, ApplicationDbContext db)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
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
                    if (bookCreateDTO.ImageFile == null || bookCreateDTO.ImageFile.Length == 0)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest();
                    }

                    Book bookToCreate = new()
                    {
                        Name = bookCreateDTO.Name,
                        Author = bookCreateDTO.Author,
                        Price = bookCreateDTO.Price,
                        Genre = bookCreateDTO.Genre,
                        Description = bookCreateDTO.Description,
                        ImageURL = await SaveImage(bookCreateDTO.ImageFile),
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

                    Book bookFromDb = await _db.Books.FindAsync(id);

                    if (bookFromDb == null)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest();
                    }

                    bookFromDb.Name = bookUpdateDTO.Name;
                    bookFromDb.Author = bookUpdateDTO.Author;
                    bookFromDb.Price = bookUpdateDTO.Price;
                    bookFromDb.Genre = bookUpdateDTO.Genre;
                    bookFromDb.Description = bookUpdateDTO.Description;
                    bookFromDb.ImageURL = await SaveImage(bookUpdateDTO.ImageFile);

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

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

    }
}
