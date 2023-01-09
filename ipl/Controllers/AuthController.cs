using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ipl.Models;

using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;


namespace ipl.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    List<Player> players = new List<Player>();
   // String Filename = @"F:\practice\ipl/ccc.json";

    public IActionResult Login()
    {
        return View();
    }



    public IActionResult RegDone()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

     public IActionResult Postregister(string firstName,string lastName,string contactnumber,string email,string password)

    {
        Player p1=new Player(){FirstName=firstName,LastName=lastName,ContactNumber=contactnumber,Email=email,Password=password};
        PlayerManager.InsertIntoFile(p1);
        return Redirect("RegDone");
       // return View();
    }

    public IActionResult Validate(string email, string password)
    {

        // players.Add(new Player{Email=email, Password=password});
        // var PlayerJosn = JsonSerializer.Serialize<List<Player>>(players);
        // System.IO.File.WriteAllText(Filename, PlayerJosn);

        // var readData = System.IO.File.ReadAllText(Filename);

        // List<Player>? newplayer = JsonSerializer.Deserialize<List<Player>>(readData);
        // players = newplayer;



 


        foreach (Player p in players)
        {
            if (p.Email == email && p.Password == password)
            {
                return Redirect("RegDone");
            }
        }
        return View();

    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
