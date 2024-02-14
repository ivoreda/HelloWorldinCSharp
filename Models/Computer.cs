using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
  public class Computer{
    public int ComputerId {get; set;}
    public string MotherBoard {get; set;} = "";
    public int? CPUCores {get; set;}
    public bool hasWifi {get; set;}
    public bool hasLTE {get; set;}
    public DateTime ReleaseDate {get; set;}
    public decimal price {get; set;}
    public string VideoCard {get; set;} = "";


    public Computer(){
    }
}
}