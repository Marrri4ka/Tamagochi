using System.Collections.Generic;
using System;
using System.Timers;


namespace Tamagotchi.Models
{
  public class Animal // class
  {
    private string _name;
    private string _status;
    private string _photo;
    private int _food;
    private int _attention;
    private int _rest;
    private int _id;
    private bool _alive = true;
    private static List<Animal> _allAnimals = new List<Animal>{}; //list

    private static Timer _timer;

    public static void PassTime()
    {
      foreach(Animal animal in _allAnimals)
      {
        Random rng = new Random();
        animal.SetFood(-rng.Next(1, 21));
        animal.SetRest(-rng.Next(1, 21));
        animal.SetAttention(-rng.Next(1, 21));
      }
    }

    public Animal (string name) // constructor
    {
      _name = name;
      _allAnimals.Add(this); //what is this <---this is the Animal being constructed
      _id = _allAnimals.Count;
      _food = 100;
      _attention = 100;
      _rest = 100;
      SetStatus();


      if(_timer == null)
      {
        _timer = new Timer(10000); //10 seconds (for testing)
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Enabled = true;
      }
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      PassTime();
      Console.WriteLine("Tick");

    }

    public string GetPhoto()
    {
      return _photo;
    }


    private void SetStatus()
    {
      int result = (_food + _attention + _rest) / 3;
      if (result == 100)
      {
        _status = _name + " feels perfect!";
        _photo = "~/img/perfect.png";
      }
      else if (result < 100 && result >= 80 )
      {
        _status = _name + " is very happy!";
        _photo = "~/img/veryhappy.png";
      }
      else if (result < 80 && result >= 60)
      {
        _status = _name + " feels happy.";
        _photo = "~/img/happy.png";
      }

      else if (result < 60 && result >= 40)
      {
        _status = _name + " feels content.";
        _photo = "~/img/happy.png";
      }
      else if (result < 40 && result >= 20)
      {
        _status = _name + " is getting sick!";
        _photo = "~/img/gettingsick.png";
      }

      else if (result < 20 && result > 0)
      {
        _status = _name + " is gravely ill!";
        _photo = "~/img/verysick.png";
      }

      else if (result <= 0)
      {
        _status = _name + " is dead...";
        _photo = "~/img/dead.png";
      }
    }

    public bool isLiving()
    {
      return _alive;
    }

    public void Dies()
    {
        _alive = false;
        _status =  _name + " has died...";
    }

    public string GetStatus()
    {
      return _status;
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

      SetStatus();
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
      SetStatus();
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
      SetStatus();
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
