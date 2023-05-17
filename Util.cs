using System;
using System.Collections.Generic;
using System.IO;
using SkiaSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatWorx.BadgeMaker
{
  class Util
  {
 public static void PrintEmployees(List<Employee> employees)
  {
   for (int i = 0; i < employees.Count; i++) 
{
  string template = "{0,-10}\t{1,-20}\t{2}";
  Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
}
  }
    public static void MakeCSV(List<Employee> employees)
    {
        // Check to see if folder exists
if (!Directory.Exists("data")) 
{
  // If not, create it
  Directory.CreateDirectory("data");
}
using (StreamWriter file = new StreamWriter("data/employees.csv"))
{
  // Any code that needs the StreamWriter would go in here
}
    }
     async public static Task MakeBadges(List<Employee> employees) {
        // SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));
        // SKData data = newImage.Encode();
        // data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
        int BADGE_WIDTH = 669;
int BADGE_HEIGHT = 1044;
         using(HttpClient client = new HttpClient())
  {
    for (int i = 0; i < employees.Count; i++)
  { 
    SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(employees[i].GetPhotoUrl()));
    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));
    SKData data = background.Encode();
    data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
    SKCanvas canvas = new SKCanvas(badge);
  }
  }
     }
  }
}