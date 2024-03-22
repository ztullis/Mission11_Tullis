using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Mission11_Tullis.Models;
using Mission11_Tullis.Models.ViewModels;

namespace Mission11_Tullis.Controllers
{
    public class HomeController : Controller
    {
        public IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var BooksListView = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(BooksListView);
        }
    }
}
