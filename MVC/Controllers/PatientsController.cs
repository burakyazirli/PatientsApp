using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class PatientsController : MvcController
    {
        // Service injections:
        private readonly IPatientService _patientService;
        private readonly IBranchService _branchService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public PatientsController(
			IPatientService patientService
            , IBranchService branchesService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _patientService = patientService;
            _branchService = branchesService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Patients
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _patientService.Query().ToList();
            return View(list);
        }

        // GET: Patients/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _patientService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["BranchesId"] = new SelectList(_branchService.Query().ToList(), "Record.Id", "Name");
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _patientService.Create(patient.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = patient.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(patient);
        }

        // GET: Patients/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _patientService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Patients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _patientService.Update(patient.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = patient.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(patient);
        }

        // GET: Patients/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _patientService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Patients/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _patientService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
