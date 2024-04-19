using AutoMapper;
using LibraryAPI.DTO.Book;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("/api/book")]
[ApiController]
public class BookController : Controller
{
    private readonly IBookInfoRepository _bookInfoRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public BookController(
        IBookRepository bookRepository,
        IBookInfoRepository bookInfoRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _bookRepository = bookRepository;
        _bookInfoRepository = bookInfoRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var categories = await _bookRepository.GetListAsync();
        return Ok(categories);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null) return NotFound("Book not found");

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto data)
    {
        var category = await _categoryRepository.GetByIdAsync(data.CategoryId);
        if (category == null) return NotFound("Category not found");

        var bookInfo = await _bookInfoRepository.Create(new BookInfoEntity
        {
            Name = data.Name,
            Author = data.Author,
            PublicationDate = data.PublicationDate
        });

        var book = await _bookRepository.Create(new BookEntity
        {
            CategoryId = category.Id,
            BookInfoId = bookInfo.Id
        });

        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateBookDto data)
    {
        //Find book
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null) return NotFound("Book not found");

        //Find category
        if (book.CategoryId != data.CategoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(data.CategoryId);
            if (category == null) return NotFound("Category not found");

            book.CategoryId = category.Id;
        }


        //Update book info
        var updatedBookInfo = await _bookInfoRepository.UpdateByIdAsync(book.BookInfoId, new BookInfoEntity
        {
            Name = data.Name,
            Author = data.Author,
            PublicationDate = data.PublicationDate
        });

        if (updatedBookInfo == null) return NotFound("Book info not found");

        //Update book
        var updatedBook = await _bookRepository.UpdateByIdAsync(id, book);

        if (updatedBook == null) return NotFound("Book not found");

        return Ok(book);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> SoftDeleteById([FromRoute] Guid id)
    {
        var book = await _bookRepository.SoftDeleteByIdAsync(id);
        return Ok(book);
    }
}