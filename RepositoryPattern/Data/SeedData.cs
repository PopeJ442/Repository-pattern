using Seedingdata.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RepositoryPattern.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Staging_Players.Any())
            { return; }


            var player = new Player[]
            {
             new Player { PlayerName = "Ojon", PlayerPosition ="Keeper",JerseyNubmer = 1},
          new Player { PlayerName = "Kwame", PlayerPosition ="RightBack",JerseyNubmer =2 },
          new Player { PlayerName = "Kwadwo", PlayerPosition ="Leftback",JerseyNubmer =3 },
          new Player { PlayerName= "Yaw", PlayerPosition ="centerback",JerseyNubmer =4 },
          new Player { PlayerName = "Akwesi", PlayerPosition ="centerback",JerseyNubmer = 5},
          new Player { PlayerName = "Kwabena", PlayerPosition ="Defensive Mildfielder",JerseyNubmer = 6},
          new Player { PlayerName = "Kofi", PlayerPosition ="Reight Winger",JerseyNubmer = 7},
          new Player { PlayerName = "Kwaku", PlayerPosition ="Attacking Mildfielder",JerseyNubmer = 8},
          new Player { PlayerName = "Young", PlayerPosition ="Striker",JerseyNubmer = 9},
          new Player { PlayerName = "Khalifa", PlayerPosition ="Attacking mildfielder",JerseyNubmer = 10},
          new Player { PlayerName = "Bamba", PlayerPosition ="Left Winger",JerseyNubmer = 11},

         
            };
            context.Staging_Players.AddRange(player);
            context.SaveChanges();
        }
        
    }
}
