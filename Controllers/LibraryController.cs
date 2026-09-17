using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers;

public class LibraryController : Controller
{
    private static readonly List<LibraryMember> issuedBooks = new()
    {
        new LibraryMember
        {
            MemberId = 1,
            MemberName = "Rahul Patel",
            Department = "Computer Engineering",
            Email = "rahul@gmail.com",
            BookId = 101,
            IssueDate = DateTime.Today.AddDays(-5),
            ReturnDate = null
        },

        new LibraryMember
        {
            MemberId = 2,
            MemberName = "Priya Shah",
            Department = "Information Technology",
            Email = "priya@gmail.com",
            BookId = 102,
            IssueDate = DateTime.Today.AddDays(-12),
            ReturnDate = null
        },

        new LibraryMember
        {
            MemberId = 3,
            MemberName = "Amit Mehta",
            Department = "Computer Engineering",
            Email = "amit@gmail.com",
            BookId = 103,
            IssueDate = DateTime.Today.AddDays(-20),
            ReturnDate = null
        },

        new LibraryMember
        {
            MemberId = 4,
            MemberName = "Neha Patel",
            Department = "Civil Engineering",
            Email = "neha@gmail.com",
            BookId = 104,
            IssueDate = DateTime.Today.AddDays(-10),
            ReturnDate = DateTime.Today.AddDays(-2)
        }
    };

    private static readonly List<Book> books = new()
    {
        new Book
        {
            BookId = 101,
            Title = "C# Programming",
            Author = "Jon Skeet",
            Category = "Programming",
            Price = 650,
            AvailableCopies = 5
        },

        new Book
        {
            BookId = 102,
            Title = "ASP.NET Core MVC",
            Author = "Adam Freeman",
            Category = "Web Development",
            Price = 850,
            AvailableCopies = 3
        },

        new Book
        {
            BookId = 103,
            Title = "Database System Concepts",
            Author = "Abraham Silberschatz",
            Category = "Database",
            Price = 900,
            AvailableCopies = 4
        },

        new Book
        {
            BookId = 104,
            Title = "Computer Networks",
            Author = "Andrew S. Tanenbaum",
            Category = "Networking",
            Price = 750,
            AvailableCopies = 2
        }
    };

    public IActionResult Index()
    {
        return View(issuedBooks);
    }

    [HttpGet]
    public IActionResult IssueBook()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult IssueBook(LibraryMember member)
    {
        if (!ModelState.IsValid)
        {
            return View(member);
        }

        member.MemberId = issuedBooks.Count + 1;

        issuedBooks.Add(member);

        TempData["SuccessMessage"] =
            "Book has been successfully issued.";

        return RedirectToAction(nameof(Index));
    }

    public IActionResult BookDetails(int id)
    {
        LibraryMember? member =
            issuedBooks.FirstOrDefault(x => x.BookId == id);

        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    public IActionResult About()
    {
        return View();
    }
}
