using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Models;

namespace Portal.Controllers
{
    public class RecipeController : Controller
    {
      private readonly RecipeDbContext _recipeRepo;  
      
      public RecipeController()
      {
        _recipeRepo = new RecipeDbContext();
      }

        //
        // GET: /Recipe/

        public ActionResult Index()
        {
            return View(_recipeRepo.Recipes.ToList());
        }

        //
        // GET: /Recipe/Details/5

        public ActionResult Details(int id = 0)
        {
            RecipeModels recipemodels = _recipeRepo.Recipes.Find(id);
            if (recipemodels == null)
            {
                return HttpNotFound();
            }
            return View(recipemodels);
        }

        //
        // GET: /Recipe/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Recipe/Create

        [HttpPost]
        public ActionResult Create(RecipeModels recipemodels)
        {
            if (ModelState.IsValid)
            {
              recipemodels.DataDodania = DateTime.Now;
              recipemodels.Autor = User.Identity.Name;
                _recipeRepo.Recipes.Add(recipemodels);
                _recipeRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipemodels);
        }

        //
        // GET: /Recipe/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RecipeModels recipemodels = _recipeRepo.Recipes.Find(id);
            if (recipemodels == null)
            {
                return HttpNotFound();
            }
            return View(recipemodels);
        }

        //
        // POST: /Recipe/Edit/5

        [HttpPost]
        public ActionResult Edit(RecipeModels recipemodels)
        {
            if (ModelState.IsValid)
            {
                _recipeRepo.Entry(recipemodels).State = EntityState.Modified;
                _recipeRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipemodels);
        }

        //
        // GET: /Recipe/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RecipeModels recipemodels = _recipeRepo.Recipes.Find(id);
            if (recipemodels == null)
            {
                return HttpNotFound();
            }
            return View(recipemodels);
        }

        //
        // POST: /Recipe/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeModels recipemodels = _recipeRepo.Recipes.Find(id);
            _recipeRepo.Recipes.Remove(recipemodels);
            _recipeRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _recipeRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}