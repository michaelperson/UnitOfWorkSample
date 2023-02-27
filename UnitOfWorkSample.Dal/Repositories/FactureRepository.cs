using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkSample.Dal.Entities;
using UnitOfWorkSample.Dal.Interfaces;

namespace UnitOfWorkSample.Dal.Repositories
{
    internal class FactureRepository : IRepository<FactureEntity,int>
    {
        private readonly SqlTransaction _transaction;

        public FactureRepository(SqlTransaction transaction)
        {
            _transaction = transaction;

        }
        public int Add(FactureEntity entity)
        {
            try
            {

                SqlCommand ocmd = new SqlCommand();
                ocmd.Connection = _transaction.Connection;
                ocmd.Transaction = _transaction;
                ocmd.CommandText = "insert into Factures (NumFacture, Montant, idClient) OUTPUT INSERTED.Id values (@NumFacture, @Montant, @idClient)";
                ocmd.Parameters.AddWithValue("NumFacture", entity.NumFacture);
                ocmd.Parameters.AddWithValue("Montant", entity.Montant);
                ocmd.Parameters.AddWithValue("idClient", entity.IdClient);

                return (int)ocmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FactureEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public FactureEntity GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(FactureEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
