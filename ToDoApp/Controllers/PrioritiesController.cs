using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class PrioritiesController : Controller
    {
        private readonly IRepository<Priority> priorityRepository;

        public PrioritiesController(IRepository<Priority> priorityRepository)
        {
            this.priorityRepository = priorityRepository;
        }
        public async Task<IActionResult> Index()
        {
            var priorities = await priorityRepository.GetAll();
            return View(priorities);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Priority model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var Saved = await priorityRepository.Add(model);
            if (Saved)
                return RedirectToAction("Index");

            ViewBag.Message = "Failed to save";
            return View(model);
        }
    }
}
