using LoadMoreExample.Models;
using LoadMoreExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoadMoreExample.Controllers;
public class HomeController : Controller
{
    private static List<string> _items = [
        "Item 1",
        "Item 2",
        "Item 3",
        "Item 4",
        "Item 5",
        "Item 6",
        "Item 7",
        "Item 8",
        "Item 9",
        "Item 10"
    ];

    private readonly byte _itemsPerPage = 3;

    public IActionResult Index()
    {        
        return View(GetItems(1));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult LoadMore(int pageNumber)
    {
        return Ok(GetItems(pageNumber));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private ItemsViewModel GetItems(int pageNumber)
    {
        var skip = _itemsPerPage * (pageNumber - 1);

        return new ItemsViewModel
        {
            Items = _items.Skip(skip).Take(_itemsPerPage).ToList(),
            HasMoreItems = _items.Count > pageNumber * _itemsPerPage
        };
    }
}
