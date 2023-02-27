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
    internal class ClientRepository : IRepository<ClientEntity, int>
    {
        private readonly SqlTransaction _transaction;

        public ClientRepository(SqlTransaction transaction)
        {
            _transaction = transaction;

        }

        public int Add(ClientEntity entity)
        {
            try
            {
                SqlCommand ocmd = new SqlCommand();
                ocmd.Connection=_transaction.Connection;
                ocmd.Transaction = _transaction;
                ocmd.CommandText = "insert into Client (Nom, Prenom) OUTPUT INSERTED.Id values (@Nom, @Prenom)";
                ocmd.Parameters.AddWithValue("Nom", entity.Nom);
                ocmd.Parameters.AddWithValue("Prenom", entity.Prenom);

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

        public IEnumerable<ClientEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClientEntity GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
