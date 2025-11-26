using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BrooklynStandard.Models;
using BrooklynStandard.Models.Data;

namespace BrooklynStandard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Test()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Web()
    {
        return View();
    }

    public IActionResult Software()
    {
        return View();
    }

    public IActionResult RequestForm()
    {
        return View();
    }

    [HttpPost]
    public void UserRequest(int id, string fullname, string email, int number, string company, string file, string request)
    {
        UserRequest userRequest = new UserRequest();
        userRequest.Id = id;
        userRequest.FullName = fullname;
        userRequest.Email = email;
        userRequest.Number = number;
        userRequest.Company = company;
        userRequest.File = file;
        userRequest.Request = request;
    }
    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
