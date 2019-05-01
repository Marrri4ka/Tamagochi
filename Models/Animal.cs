using System.Collections.Generic;
using System;

namespace Tamagotchi.Models
{
  public class Animal // class
  {
    private string _name;
    private int _food;
    private int _attention;
    private int _rest;
    private int _id;
    private bool _alive = true;
    private static List<Animal> _allAnimals = new List<Animal>{}; //list

    public Animal (string name) // constructor
    {
      _name = name;
      _allAnimals.Add(this); //what is this
      _id = _allAnimals.Count;
      _food = 100;
      _attention = 100;
      _rest = 100;
    }

    public bool isLiving()
    {
      return _alive;
    }

    public void Dies()
    {
        _alive = false;
        //Description "your dear " + _name + " has died :("
    }

    public int GetFood()
    {
      return _food;
    }

    public void SetFood(int newFood)
    {
      _food += newFood;

      if(_food > 100)
      {
        _food = 100;
      }

      else if(_food <= 0)
      {
        Dies();
      }
    }

    public int GetAttention()
    {
      return _attention;
    }

    public void SetAttention(int newAttention)
    {
      _attention += newAttention;

      if(_attention > 100)
      {
        _attention = 100;
      }
      else if(_attention<=0)
      {
        Dies();
      }


    }
    public int GetRest()
    {
      return _rest;
    }

    public void SetRest(int newRest)
    {
      _rest += newRest;
      if(_rest > 100)
      {
        _rest = 100;
      }
      if(_rest<=0)
      {
        Dies();
      }
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
