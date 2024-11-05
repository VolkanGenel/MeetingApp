using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        // [HttpGet] Default olarak bu metotlar Get metotlarıdır. Bu ibare burada default olarak vardır.
        // [HttpGet] Başına Http Get koyunca ve Form Post Methodu olunca hata verir ama hiç bilgi girmezsek metot post olarak da çalışır. Ancak headre QueryScript alanı boş olacağından bir anlam ifade etmez; çünkü metot parametreleri almalıydı.
        public IActionResult Apply()
        {
            return View();
        }
        // [HttpPost]
        // public IActionResult Apply(string Name, string Phone, string Email, bool WillAttend)
        // {
        //     Console.WriteLine(Name);
        //     Console.WriteLine(Email);
        //     Console.WriteLine(Phone);
        //     Console.WriteLine(WillAttend);
        //     return View();
        // }

        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {
            if(ModelState.IsValid) 
            {
            //burada veritabanı kaydı işlemlerini yapabiliriz.
            Repository.CreateUser(model);
            ViewBag.UserCount = Repository.Users.Where(info=>info.WillAttend == true).Count();
            return View("Thanks", model);
            } else
            {
                return View(model);
            }
        }
            public IActionResult List()
        {
            List<UserInfo> users = Repository.Users;               
            return View(users); 
        }
        //meeting/details/2
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}