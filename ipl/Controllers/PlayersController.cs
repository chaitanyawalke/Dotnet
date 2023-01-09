using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ipl.Models;

namespace ipl.Controllers;

public class PlayersController : Controller
{
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(ILogger<PlayersController> logger)
    {
        _logger = logger;
    }

    public IActionResult Display()

    {
        List<Player> allplayers=PlayerManager.GetAllPlayers();
        ViewData["abc"]=allplayers;
        return View();
    }

   
    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
