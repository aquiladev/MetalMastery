using System;
using System.Data;
using System.Web.Mvc;
using MetalMastery.Core.Domain;

namespace MetalMastery.Admin.Controllers
{   
    public class ArticlesController : Controller
    {
        //
        // GET: /Articles/

        public ViewResult Index()
        {
            return View(context.Articles.Include(article => article.Owner).ToList());
        }

        //
        // GET: /Articles/Details/5

        public ViewResult Details(System.Guid id)
        {
            Article article = context.Articles.Single(x => x.Id == id);
            return View(article);
        }

        //
        // GET: /Articles/Create

        public ActionResult Create()
        {
            ViewBag.PossibleOwners = context.Users;
            return View();
        } 

        //
        // POST: /Articles/Create

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Id = Guid.NewGuid();
                context.Articles.Add(article);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleOwners = context.Users;
            return View(article);
        }
        
        //
        // GET: /Articles/Edit/5
 
        public ActionResult Edit(System.Guid id)
        {
            Article article = context.Articles.Single(x => x.Id == id);
            ViewBag.PossibleOwners = context.Users;
            return View(article);
        }

        //
        // POST: /Articles/Edit/5

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                context.Entry(article).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleOwners = context.Users;
            return View(article);
        }

        //
        // GET: /Articles/Delete/5
 
        public ActionResult Delete(System.Guid id)
        {
            Article article = context.Articles.Single(x => x.Id == id);
            return View(article);
        }

        //
        // POST: /Articles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(System.Guid id)
        {
            Article article = context.Articles.Single(x => x.Id == id);
            context.Articles.Remove(article);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}