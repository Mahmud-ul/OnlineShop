using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.Repository.Contract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int? Id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Remove(T entity);
    }
}
