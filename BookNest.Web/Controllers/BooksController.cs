using BookNest.Web.Data;
using BookNest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Web.Controllers;

public class BooksController(BookNestContext db) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string? query, string status = "all")
    {
        var books = db.Books.AsNoTracking().AsQueryable();
        var searched = query?.Trim() ?? "";
        if (!string.IsNullOrWhiteSpace(searched))
            books = books.Where(b => b.Title.Contains(searched) ||
                b.Author.Contains(searched) || b.Genre.Contains(searched));

        var allowed = new[] { "all", "want", "reading", "finished" };
        if (!allowed.Contains(status)) status = "all";
        books = status switch
        {
            "want" => books.Where(b => b.Status == ReadingStatus.WantToRead),
            "reading" => books.Where(b => b.Status == ReadingStatus.Reading),
            "finished" => books.Where(b => b.Status == ReadingStatus.Finished),
            _ => books
        };

        return View(new LibraryViewModel
        {
            Books = await books.OrderByDescending(b => b.AddedOn).ThenBy(b => b.Title).ToListAsync(),
            Query = searched, Status = status,
            Total = await db.Books.CountAsync(),
            Reading = await db.Books.CountAsync(b => b.Status == ReadingStatus.Reading),
            Finished = await db.Books.CountAsync(b => b.Status == ReadingStatus.Finished),
            WantToRead = await db.Books.CountAsync(b => b.Status == ReadingStatus.WantToRead)
        });
    }

    [HttpGet]
    public IActionResult Create() => View(new Book());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        book.Id = 0;
        book.AddedOn = DateTime.UtcNow;
        db.Books.Add(book);
        await db.SaveChangesAsync();
        TempData["Success"] = "Book added to your shelf.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await db.Books.FindAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book input)
    {
        if (id != input.Id) return BadRequest();
        if (!ModelState.IsValid) return View(input);
        var book = await db.Books.FindAsync(id);
        if (book == null) return NotFound();
        book.Title = input.Title;
        book.Author = input.Author;
        book.Genre = input.Genre;
        book.Status = input.Status;
        book.TotalPages = input.TotalPages;
        book.PagesRead = input.PagesRead;
        book.Rating = input.Rating;
        book.CoverUrl = input.CoverUrl;
        book.Notes = input.Notes;
        await db.SaveChangesAsync();
        TempData["Success"] = "Your book has been updated.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await db.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await db.Books.FindAsync(id);
        if (book == null) return NotFound();
        db.Books.Remove(book);
        await db.SaveChangesAsync();
        TempData["Success"] = "Book removed from your shelf.";
        return RedirectToAction(nameof(Index));
    }
}
