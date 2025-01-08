using BLL.Controllers.Bases;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class FavoritesController : MvcController
    {
        const string SESSIONKEY = "Favorites";
        private readonly HttpServiceBase _httpService;
        private readonly IService<Patient, PatientModel> _patientService;

        public FavoritesController(HttpServiceBase httpService, IService<Patient, PatientModel> patientService)
        {
            _httpService = httpService;
            _patientService = patientService;
        }

        private int GetUserId() => Convert.ToInt32(User.Claims.SingleOrDefault(c => c.Type == "Id").Value);
        private List<FavoritesModel> GetSession(int UserId) 
        {
            var favorites = _httpService.GetSession<List<FavoritesModel>>(SESSIONKEY);
            return favorites?.Where(f => f.UserId == GetUserId()).ToList();
        }
        public IActionResult Get()
        {
            return View("List",GetSession(GetUserId()));
        }

        public IActionResult Remove(int patientId)
        {
            var favorites = GetSession(GetUserId());
            var favoritesItem = favorites.FirstOrDefault(c => c.PatientId == patientId);
            favorites.Remove(favoritesItem);
            _httpService.SetSession(SESSIONKEY, favorites);
            return RedirectToAction(nameof(Get));
        }

        // GET: /Favorites/Add?patientId=17
        public IActionResult Add(int patientId)
        {
            int userId = GetUserId();
            var favorites = GetSession(userId);
            favorites = favorites ?? new List<FavoritesModel>();
            if (!favorites.Any(f => f.PatientId == patientId))
            {
                var patient = _patientService.Query().SingleOrDefault(p => p.Record.Id == patientId);
                var favoritesItem = new FavoritesModel()
                {
                    PatientId = patientId,
                    UserId = userId,
                    PatientName = patient.Name
                };
                favorites.Add(favoritesItem);
                _httpService.SetSession(SESSIONKEY, favorites);
                TempData["Message"] = $"\"{patient.Name}\" added to favorites.";
            }
            return RedirectToAction("Index", "Patients");
        }

    }
}
