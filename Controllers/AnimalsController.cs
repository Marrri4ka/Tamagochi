using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;
using System;

namespace Tamagotchi.Controllers
{
  public class AnimalsController : Controller
  {

    [HttpGet("/animals")]
    public ActionResult IndexAnimal()
    {
      List<Animal> allAnimals = Animal.GetAll();
      return View(allAnimals);
    }

    [HttpGet("/animals/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost ("/animals")]
    public ActionResult Create (string name)
    {
      Animal myAnimal = new Animal(name);
      return RedirectToAction("IndexAnimal");
    }

    [HttpPost("/animals/delete")]
    public ActionResult DeleteAll()
    {
      Animal.ClearAll();
      return View();
    }

    [HttpGet("/animals/{id}")]
    public ActionResult Show(int id)
    {
      Animal animal = Animal.Find(id);
      return View(animal);
    }

    [HttpPost("/animals/timepass/")]
    public ActionResult Update()
    {
      Animal.PassTime();
      return RedirectToAction("IndexAnimal");
    }

    [HttpPost("/animals/{id}/feed")]
    public ActionResult Feed(int id)
    {
      Random rng = new Random();
      Animal animal = Animal.Find(id);
      animal.SetFood(rng.Next(5, 21));

      return RedirectToAction("IndexAnimal");
    }

    [HttpPost("/animals/{id}/sleep")]
    public ActionResult Sleep(int id)
    {
      Random rng = new Random();
      Animal animal = Animal.Find(id);
      animal.SetRest(rng.Next(5, 21));

      return RedirectToAction("IndexAnimal");

    }

    [HttpPost("/animals/{id}/play")]
    public ActionResult Play(int id)
    {
      Random rng = new Random();
      Animal animal = Animal.Find(id);
      animal.SetAttention(rng.Next(5, 21));

      return RedirectToAction("IndexAnimal");
    }
  }
}
