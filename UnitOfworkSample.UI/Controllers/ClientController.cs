using Microsoft.AspNetCore.Mvc;
using UnitOfworkSample.UI.Models;
using UnitOfWorkSample.Dal.Entities;
using UnitOfWorkSample.Dal.Interfaces;

namespace UnitOfworkSample.UI.Controllers
{
    public class ClientController : Controller
    {
        //private readonly IRepository<ClientEntity, int> _repoC;
        //private readonly IRepository<FactureEntity, int> _repoF;
        private readonly IUnitOfWork _uow;
        public ClientController(IUnitOfWork uow)
        {
            //_repoC= repo;
            //_repoF= repof;
            _uow = uow;
        }
        public IActionResult Index()
        {
            IEnumerable<ClientModel> liste = _uow.ClientRepository.GetAll().Select(c=>Mappers.Mappers.MapEntityClientToModel(c));

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientFactureModel c)
        {
            try
            {
                ClientModel cm = new ClientModel()
                {
                    Nom = c.Nom,
                    Prenom = c.Prenom
                };


                int idClient = _uow.ClientRepository.Add(Mappers.Mappers.MapModelClientToEntity(cm));

                FactureModel fm = new FactureModel()
                {
                    NumFacture = c.NumFacture,
                    Montant = c.Montant,
                    IdClient = idClient
                };


               int ret = _uow.FactureRepository.Add(Mappers.Mappers.MapModelFactureToEntity(fm));
                if (ret > 0)
                {
                    _uow.Commit();
                }
                else
                {
                    _uow.Rollback();
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
