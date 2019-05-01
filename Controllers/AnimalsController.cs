using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

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

  }
}
