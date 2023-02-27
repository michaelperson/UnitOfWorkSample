using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkSample.Dal.Entities;
using UnitOfWorkSample.Dal.Repositories;

namespace UnitOfWorkSample.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<ClientEntity, int> ClientRepository { get; }
        IRepository<FactureEntity, int> FactureRepository { get; }

        bool Commit();
        void Rollback();
    }
}
