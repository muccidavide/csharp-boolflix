using csharp_boolflix.Context;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;

namespace csharp_boolflix.Controllers
{
    public class ActorController : Controller
    {
        private BoolflixDbContext _db;
        ActorEditModel ActorEditModel;

        public ActorController()
        {
            _db = new BoolflixDbContext();
            ActorEditModel = new ActorEditModel();
            ActorEditModel.Actors = _db.Actors.ToList();
        }

        public IActionResult Index()
        {
            return View(ActorEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActorEditModel formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Actors = ActorEditModel.Actors;
                return View(formData);
            }

            _db.Actors.Add(formData.Actor);
            _db.SaveChanges();

            return RedirectToAction("Index", ActorEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Actor actorToDelete = _db.Actors.FirstOrDefault(x => x.Id == id);

            if(actorToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Actors.Remove(actorToDelete);
                _db.SaveChanges();

                return RedirectToAction("Index", ActorEditModel);
            }
        }

        public IActionResult Update(ActorEditModel formData, int id)
        {
            Actor actorToUpdate = _db.Actors.FirstOrDefault(x => x.Id == id);

            if (actorToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                actorToUpdate.FirstName = formData.Actor.FirstName;
                actorToUpdate.LastName = formData.Actor.LastName;
                _db.SaveChanges();

                return RedirectToAction("Index", ActorEditModel);
            }
        }
    }
}
