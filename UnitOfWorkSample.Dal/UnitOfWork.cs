using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkSample.Dal.Entities;
using UnitOfWorkSample.Dal.Interfaces;
using UnitOfWorkSample.Dal.Repositories;

namespace UnitOfWorkSample.Dal
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRepository<ClientEntity, int> _ClientRepository;
        private IRepository<FactureEntity, int> _FactureRepository;
        private SqlConnection _conn;
        private SqlTransaction _transaction;

        public IRepository<ClientEntity, int> ClientRepository { 
            
            get 
            {
                _ClientRepository = _ClientRepository ?? new ClientRepository(_transaction);

                return _ClientRepository;
            
            } 
        
        }

        public IRepository<FactureEntity, int> FactureRepository {
            get
            {
                _FactureRepository = _FactureRepository ?? new FactureRepository(_transaction);

                return _FactureRepository;

            }
        }

        public UnitOfWork(string connectionString)
        {
            try
            {
                _conn = new SqlConnection(connectionString);
                _conn.Open();
                _transaction = _conn.BeginTransaction();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

        }

        public void Rollback()
        {
            
            try
            {
                _transaction.Rollback();

            }
            catch
            {
                Debug.WriteLine("error on rollback");
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _conn.BeginTransaction();
            }
             
        }

        public bool Commit()
        {
            bool isOk = false;
            try
            {
                _transaction.Commit();
                isOk = true;
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _conn.BeginTransaction();
            }
            return isOk;
        }

        protected virtual void Dispose(bool info = true)
        {
            if (_transaction != null)
            {
                Commit();
                _transaction.Dispose();
                _transaction = null;
            }

            if (_conn != null)
            {
                _conn.Dispose();
                _conn = null;
            }
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {


            Dispose(true);
        }
    }
}
