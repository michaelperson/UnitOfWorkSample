using UnitOfworkSample.UI.Models;
using UnitOfWorkSample.Dal.Entities;

namespace UnitOfworkSample.UI.Mappers
{
    public  static class Mappers
    {

        public static ClientModel MapEntityClientToModel(ClientEntity entity)
        {
            return new ClientModel()
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Prenom = entity.Prenom
            };
        }

        public static ClientEntity MapModelClientToEntity(ClientModel model)
        {
            return new ClientEntity()
            {
                Id = model.Id,
                Nom = model.Nom,
                Prenom = model.Prenom
            };
        }

        public static FactureModel MapEntityFactureToModel(FactureEntity entity)
        {
            return new FactureModel()
            {
                Id = entity.Id,
                NumFacture = entity.NumFacture,
                Montant = entity.Montant,
                IdClient=entity.IdClient
            };
        }

        public static FactureEntity MapModelFactureToEntity(FactureModel model)
        {
            return new FactureEntity()
            {
                Id = model.Id,
                NumFacture = model.NumFacture,
                Montant = model.Montant,
                IdClient = model.IdClient
            };
        }
    }
}
