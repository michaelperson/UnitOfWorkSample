using Microsoft.AspNetCore.Mvc;
using UnitOfworkSample.UI.Models;
using UnitOfWorkSample.Dal.Entities;
using UnitOfWorkSample.Dal.Interfaces;

namespace UnitOfworkSample.UI.Controllers
{
    public class FactureController : Controller
    {
        private readonly IRepository<FactureEntity,int> _repo;
        
        public FactureController(IRepository<FactureEntity, int> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FactureModel f)
        {
            try
            {

                _repo.Add(Mappers.Mappers.MapModelFactureToEntity(f));
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
