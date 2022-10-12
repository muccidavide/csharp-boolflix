using csharp_boolflix.Context;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace csharp_boolflix.Controllers
{
    public class FeatureGenreController : Controller
    {
        private BoolflixDbContext _db;
        public GenresFeaturesEditModel GenresFeaturesEditModel;
        public FeatureGenreController()
        {
            _db = new BoolflixDbContext();
            GenresFeaturesEditModel = new GenresFeaturesEditModel();
            GenresFeaturesEditModel.Genres = _db.Genres.ToList();
            GenresFeaturesEditModel.Features = _db.Features.ToList();
        }
        public IActionResult Index()
        {
           
            return View(GenresFeaturesEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeature(GenresFeaturesEditModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", GenresFeaturesEditModel);
            }

            _db.Features.Add(formData.FeatureToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index",GenresFeaturesEditModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFeature(int id, GenresFeaturesEditModel formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Genres = GenresFeaturesEditModel.Genres;
                formData.Features = formData.Features;
                return View("Index", formData);
            }

            Feature featureToUpdate = _db.Features.FirstOrDefault(x => x.Id == id);

            if (featureToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                featureToUpdate.Name = formData.FeatureToEdit.Name;

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("StoreDataExcetipn", ex.Message);
                    formData.Genres = GenresFeaturesEditModel.Genres;
                    formData.Features = formData.Features;
                    return View("Index", formData);

                }

                return RedirectToAction("Index", GenresFeaturesEditModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFeature(int id)
        {
            Feature featureToRemove = _db.Features.FirstOrDefault(x => x.Id == id);

            if (featureToRemove == null)
            {
                return NotFound();
            }

            _db.Features.Remove(featureToRemove);
            _db.SaveChanges();

            return RedirectToAction("Index", GenresFeaturesEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGenre(GenresFeaturesEditModel formData)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", GenresFeaturesEditModel);
            }

            _db.Genres.Add(formData.GenreToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index", GenresFeaturesEditModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateGenre(int id, GenresFeaturesEditModel formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Genres = GenresFeaturesEditModel.Genres;
                formData.Features = formData.Features;
                return View("Index", formData);
            } 

            Genre genreToUpdate = _db.Genres.FirstOrDefault(x => x.Id == id);

            if(genreToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                genreToUpdate.Name = formData.GenreToEdit.Name;

                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("StoreDataExcetipn", ex.Message);
                    formData.Genres = GenresFeaturesEditModel.Genres;
                    formData.Features = formData.Features;
                    return View("Index", formData);

                }

                return RedirectToAction("Index", GenresFeaturesEditModel);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGenre(int id)
        {
            Genre genreToRemove = _db.Genres.FirstOrDefault(x => x.Id == id);

            if(genreToRemove == null)
            {
                return NotFound();
            }
            
            _db.Genres.Remove(genreToRemove);
            _db.SaveChanges();

            return RedirectToAction("Index", GenresFeaturesEditModel);
        }
    }
}
