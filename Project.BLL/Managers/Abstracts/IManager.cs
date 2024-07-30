using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Abstracts
{
    public interface IManager<T> where T : IEntity
    {
        //List Command

        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        List<T> GetActives();
        Task<List<T>> GetActivesAsync();
        List<T> GetPassives();
        Task<List<T>> GetPassivesAsync();
        List<T> GetModifieds();
        Task<List<T>> GetModifiedsAsync();

        //Modify Commands
        void Add(T item);
        Task AddAsync(T item);
        void Delete(T item);
        Task DeleteAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        string Destroy(T item);
        Task<string> DestroyAsync(T item);

        //Linq Commands
        List<T> Where(Expression<Func<T, bool>> exp);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);

        object Select(Expression<Func<T, object>> exp); //Anonymus Type'a mapping'e destek vermek icin kullanabilecegimiz bir Select metodudur...
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp); //Generic tip'e göre işlem yapmasını istedigimizi Select metodu...

        //Find Command
        Task<T> FindAsync(int id);

        List<T> GetLastDatas(int count);
        List<T> GetFirstDatas(int count);
    }
}
