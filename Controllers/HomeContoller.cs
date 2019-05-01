using Microsoft.AspNetCore.Mvc;


namespace Tamagotchi.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult IndexHome()
    {

      return View();
    }

  }
}
