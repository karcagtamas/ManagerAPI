using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatusLibrary.Services.Services.Interfaces;

namespace ManagerAPI.Backend.Controllers;

/// <summary>
/// Book controller
/// </summary>
[Route("api/[controller]")]
[Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
[ApiController]
public class BookController : MyController<Book, BookModel, BookListDto, BookDto>
{
    private readonly IBookService _bookService;

    /// <summary>
    /// Init book controller
    /// </summary>
    /// <param name="bookService">Book service</param>
    public BookController(IBookService bookService) : base(bookService)
    {
        this._bookService = bookService;
    }

    /// <summary>
    /// Get my list endpoint
    /// </summary>
    [HttpGet("my")]
    public IActionResult GetMyList()
    {
        return this.Ok(this._bookService.GetMyList());
    }

    /// <summary>
    /// Get my endpoint
    /// </summary>
    /// <param name="id">Path param id</param>
    [HttpGet("my/{id}")]
    public IActionResult GetMy(int id)
    {
        return this.Ok(this._bookService.GetMy(id));
    }

    /// <summary>
    /// Get my selector list
    /// </summary>
    /// <param name="onlyMine">Only mine query param</param>
    [HttpGet("selector")]
    public IActionResult GetMySelectorList([FromQuery] bool onlyMine)
    {
        return this.Ok(this._bookService.GetMySelectorList(onlyMine));
    }

    /// <summary>
    /// Update my books endpoint
    /// </summary>
    /// <param name="model">Model</param>
    [HttpPut("map")]
    public IActionResult UpdateMyBooks([FromBody] MyBookModel model)
    {
        this._bookService.UpdateMyBooks(model.Ids);
        return this.Ok();
    }

    /// <summary>
    /// Update read status endpoint
    /// </summary>
    /// <param name="models">Models</param>
    [HttpPut("map/status")]
    public IActionResult UpdateReadStatus([FromBody] List<BookReadStatusModel> models)
    {
        foreach (var model in models)
        {
            this._bookService.UpdateReadStatus(model.Id, model.Read);
        }

        return this.Ok();
    }

    /// <summary>
    /// Add book to my list endpoint
    /// </summary>
    /// <param name="id">Path param id</param>
    [HttpPost("map/{id}")]
    public IActionResult AddBookToMyBooks(int id)
    {
        this._bookService.AddBookToMyBooks(id);
        return this.Ok();
    }

    /// <summary>
    /// Remove book from my books endpoint
    /// </summary>
    /// <param name="id">Path param id</param>
    [HttpDelete("map/{id}")]
    public IActionResult RemoveBookFromMyBooks(int id)
    {
        this._bookService.RemoveBookFromMyBooks(id);
        return this.Ok();
    }

    /// <summary>
    /// Create endpoint
    /// </summary>
    /// <param name="model">Model</param>
    [HttpPost]
    [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
    public override IActionResult Create([FromBody] BookModel model)
    {
        this._bookService.Add<BookModel>(model);
        return this.Ok();
    }

    /// <summary>
    /// Delete endpoint
    /// </summary>
    /// <param name="id">Path param id</param>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator,Root,Status Library Administrator")]
    public override IActionResult Delete(int id)
    {
        this._bookService.Remove(id);
        return this.Ok();
    }

    /// <summary>
    /// Update endpoint
    /// </summary>
    /// <param name="id">Path param id</param>
    /// <param name="model">Model</param>
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
    public override IActionResult Update(int id, BookModel model)
    {
        this._bookService.Update<BookModel>(id, model);
        return this.Ok();
    }
}
