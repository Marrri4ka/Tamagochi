using System.Collections.Generic;
using System;

namespace Tamagotchi.Models
{
  public class Animal // class
  {
    private string _name; // field
    private int _id;
    private static List<Animal> _allAnimals = new List<Animal>{}; //list

    public Animal (string name) // constructor
    {
      _name = name;
      _allAnimals.Add(this); //what is this
      _id = _allAnimals.Count;
    }


    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }
    public static List<Animal> GetAll()
    {
      return _allAnimals;
    }

    public static void ClearAll()
    {
      _allAnimals.Clear();
    }
    public int GetId()
    {
      return _id;
    }

    public static Animal Find (int searchId)
    {

      return _allAnimals[searchId-1];
    }


  }
}
