using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services;
using BLL.Models;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class BranchesController : MvcController
    {
        // Service injections:
        private readonly IBranchService _branchService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public BranchesController(
			IBranchService branchService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _branchService = branchService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Branches
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _branchService.Query().ToList();
            return View(list);
        }

        // GET: Branches/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _branchService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entiy name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BranchModel branch)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _branchService.Create(branch.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = branch.Record.Id });
                }
                ModelState.AddModelError("", result.Message); // shown in the validation summary of view
            }
            SetViewData();
            return View(branch);
        }

        // GET: Branches/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _branchService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Branches/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BranchModel branch)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _branchService.Update(branch.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = branch.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(branch);
        }

        // GET: Branches/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _branchService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Branches/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _branchService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
