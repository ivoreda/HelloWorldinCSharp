using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args){

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);


            // DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

            Computer myComputer = new Computer() {
                MotherBoard = "Z690",
                hasWifi = true,
                hasLTE = false,
                ReleaseDate = DateTime.Now,
                price = 943.78m,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                MotherBoard,
                hasWifi,
                hasLTE,
                ReleaseDate,
                price,
                VideoCard
            ) VALUES ('" + myComputer.MotherBoard 
                    + "', '" + myComputer.hasWifi
                    + "', '" + myComputer.hasLTE
                    + "', '" + myComputer.ReleaseDate
                    + "', '" + myComputer.price
                    + "', '" + myComputer.VideoCard
                    + "')";

            
            // Console.WriteLine(sql);


            // Console.WriteLine(result);

            string sqlSelect = @"SELECT 
                Computer.MotherBoard,
                Computer.hasWifi,
                Computer.hasLTE,
                Computer.ReleaseDate,
                Computer.price,
                Computer.VideoCard 
                FROM TutorialAppSchema.Computer";
            
            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);
            IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>();

            if (computersEF != null) {

            foreach (Computer singleComputer in computersEF){
                Console.WriteLine("'" + singleComputer.ComputerId 
                    + "', '" + singleComputer.MotherBoard 
                    + "', '" + singleComputer.hasWifi
                    + "', '" + singleComputer.hasLTE
                    + "', '" + singleComputer.ReleaseDate
                    + "', '" + singleComputer.price
                    + "', '" + singleComputer.VideoCard
                    + "'");
            }
            }




        }
    }
}










