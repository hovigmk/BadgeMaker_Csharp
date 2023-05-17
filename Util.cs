using System;
using System.Collections.Generic;
using System.IO;
using SkiaSharp;

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
     public static void MakeBadges(List<Employee> employees) {
        SKImage newImage = SKImage.FromEncodedData(File.OpenRead("badge.png"));
        SKData data = newImage.Encode();
        data.SaveTo(File.OpenWrite("data/employeeBadge.png"));
     }
  }
}