using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aktur_Proje_2.Controllers
{
    public class AdminController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository()); 
        Context c = new Context();
        public IActionResult Index()
        {
            var values = um.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddUser() {
            return View();  
        }
        [HttpPost]
        public IActionResult AddUser(User p)
        {
            UserValidator uv= new UserValidator();
            ValidationResult results=uv.Validate(p);
            if (results.IsValid)
            {
                um.TAdd(p);
                return RedirectToAction("", "Admin");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
           return View();
        }

        public IActionResult DeleteUser(int id)
        {
            var uservalue=um.TGetById(id);
            ((BusinessLayer.Abstract.IGenericService<User>)um).TDelete(uservalue);
            return RedirectToAction("", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var uservalue = um.TGetById(id);
            List<SelectListItem> employevalues = (from x in um.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.ID.ToString()
                                                   }).ToList();
            ViewBag.cv = employevalues;
            return View(uservalue);
        }

        [HttpPost]
        public IActionResult UpdateUser(User p)
        {
            um.TUpdate(p);
            return RedirectToAction("","Admin");
        }
    }
}
