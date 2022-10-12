using csharp_boolflix.Context;
using csharp_boolflix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace csharp_boolflix.Controllers
{
    public class FilmController : Controller
    {
        private BoolflixDbContext _db;
        public FilmEditModel FilmEditModel;

        public FilmController()
        {
            _db = new BoolflixDbContext();
            FilmEditModel = new FilmEditModel();
            FilmEditModel.Films = _db.Films.ToList();
            FilmEditModel.Actors = _db.Actors.ToList();
            FilmEditModel.Genres = _db.Genres.ToList();
            FilmEditModel.Features = _db.Features.ToList();

        }

        public IActionResult Index()
        {
            return View(FilmEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FilmEditModel formData)
        {
            if (!ModelState.IsValid)
            {
                formData.Actors = FilmEditModel.Actors;
                formData.Genres = FilmEditModel.Genres;
                formData.Features = FilmEditModel.Features;
                return View("Index", formData);
            }
            formData.FilmToEdit.MediaInfo = new MediaInfo();
            // Attach Genres Selected
            formData.FilmToEdit.MediaInfo.Genres = _db.Genres.Where(g => formData.GenresToEdit.Contains(g.Id)).ToList<Genre>();
            // Attach Actors Selected
            formData.FilmToEdit.MediaInfo.Cast = _db.Actors.Where(a => formData.ActorsToEdit.Contains(a.Id)).ToList<Actor>();
            // Attach Features
            formData.FilmToEdit.MediaInfo.Features = _db.Features.Where(f => formData.FeaturesToEdit.Contains(f.Id)).ToList<Feature>();

            _db.Films.Add(formData.FilmToEdit);

            try
            {
                _db.Films.Add(formData.FilmToEdit);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                formData.Actors = FilmEditModel.Actors;
                formData.Genres = FilmEditModel.Genres;
                formData.Features = FilmEditModel.Features;
                return View("Index", formData);

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(FilmEditModel formData, int id)
        {
            if (!ModelState.IsValid)
            {
                formData.Actors = FilmEditModel.Actors;
                formData.Genres = FilmEditModel.Genres;
                formData.Features = FilmEditModel.Features;
                return View("Index", formData);
            }

            Film filmToUpdate = _db.Films.FirstOrDefault(f => f.Id == id);

            if(filmToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                filmToUpdate.Title = formData.FilmToEdit.Title;
                filmToUpdate.Duration = formData.FilmToEdit.Duration;
                filmToUpdate.Description = formData.FilmToEdit.Description;

                try
                {               
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    formData.Actors = FilmEditModel.Actors;
                    formData.Genres = FilmEditModel.Genres;
                    formData.Features = FilmEditModel.Features;
                    return View("Index", formData);

                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Film filmToDelete = _db.Films.FirstOrDefault(f => f.Id == id);
            MediaInfo mediaInfoToDelete = _db.MediaInfos.FirstOrDefault(f => f.Id == id);

            if(filmToDelete == null || mediaInfoToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Films.Remove(filmToDelete);
                _db.MediaInfos.Remove(mediaInfoToDelete);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}