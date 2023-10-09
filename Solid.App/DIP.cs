using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.DIP
{
    public class ProductService
    {
        private readonly IRepository _repository;
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }
        public List<string> TGetAll()
        {
            return _repository.GetAll();
            
        }
    }
    public class ProductRepositoryFromSqlServer:IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Sql Server Kalem 1", "Sql Server Kalem 2" };
        }
    }
    public class ProductRepositoryFromOracle : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Oracle Kalem 1", "Oracle Kalem 2" };
        }
    }
    public interface IRepository
    {
        List<string> GetAll();
    }


}
