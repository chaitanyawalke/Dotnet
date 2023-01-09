namespace ipl.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;

public class PlayerManager{

  static List<Player> players=new List<Player>();
   static string Filename=@"F:\practice\ipl/ccc.json";

  public static List<Player> GetAllPlayers()

  {
    var readData=System.IO.File.ReadAllText(Filename);

    List<Player> newlist=JsonSerializer.Deserialize<List<Player>>(readData);

    return newlist;

  }


  public static void InsertIntoFile(Player insert)
  {
    var readData=System.IO.File.ReadAllText(Filename);

    List<Player> newlist=JsonSerializer.Deserialize<List<Player>>(readData);

    newlist.Add(insert);


    var data=JsonSerializer.Serialize<List<Player>>(newlist);

    System.IO.File.WriteAllText(Filename,data);
  }

}
