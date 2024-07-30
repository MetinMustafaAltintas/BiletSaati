using Microsoft.Data.SqlClient;
using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _iRep;

        public BaseManager(IRepository<T> iRep)
        {
            _iRep = iRep;
        }
        public void Add(T item)
        {
            _iRep.Add(item);
        }

        public async Task AddAsync(T item)
        {
            await _iRep.AddAsync(item);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _iRep.Any(exp);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.AnyAsync(exp);
        }

        public void Delete(T item)
        {
            _iRep.Delete(item);
        }

        public async Task DeleteAsync(T item)
        {
             await _iRep.DeleteAsync(item);
        }

        public string Destroy(T item)
        {
            if (item.Status == ENTITIES.Enums.DataStatus.Deleted)
            {
                try
                {
                    _iRep.Destroy(item); // Veritabanından silme işlemi yapılır
                    return "Veri basarıyla yok edildi"; // Veri başarıyla silindi
                }

                catch (Exception ex)
                {
                    // Veritabanı hata mesajını yakalayarak özelleştirilmiş hata mesajı döndürülür

                    if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                    {
                        return "Veriler silinemiyor. Lütfen kategorideki ürünleri silin";
                    }
                }

            }
            return $"Veriyi silemezsiniz cünkü {item.ID} id'sine sahip veri pasif degil";
        }

        public async Task<string> DestroyAsync(T item)
        {
            if (item.Status == ENTITIES.Enums.DataStatus.Deleted)
            {
                try
                {
                    await _iRep.DestroyAsync(item); // Veritabanından silme işlemi yapılır
                    return "Veri basarıyla yok edildi"; // Veri başarıyla silindi
                }

                catch (Exception ex)
                {
                    // Veritabanı hata mesajını yakalayarak özelleştirilmiş hata mesajı döndürülür

                    if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
                    {
                        return "Veriler silinemiyor. Lütfen kategorideki ürünleri silin";
                    }
                }

            }
            return $"Veriyi silemezsiniz cünkü {item.ID} id'sine sahip veri pasif degil";
        }

        public async Task<T> FindAsync(int id)
        {
            return await _iRep.FindAsync(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return _iRep.FirstOrDefault(exp);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.FirstOrDefaultAsync(exp);
        }

        public List<T> GetActives()
        {
            return _iRep.GetActives();
        }

        public async Task<List<T>> GetActivesAsync()
        {
            return await _iRep.GetActivesAsync();
        }

        public List<T> GetAll()
        {
            return _iRep.GetAll();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _iRep.GetAllAsync();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _iRep.GetFirstDatas(count);
        }

        public List<T> GetLastDatas(int count)
        {
            return _iRep.GetLastDatas(count);
        }

        public List<T> GetModifieds()
        {
            return _iRep.GetModifieds();
        }

        public async Task<List<T>> GetModifiedsAsync()
        {
             return await _iRep.GetModifiedsAsync();
        }

        public List<T> GetPassives()
        {
            return _iRep.GetPassives();
        }

        public async Task<List<T>> GetPassivesAsync()
        {
            return await _iRep.GetPassivesAsync();
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _iRep.Select(exp);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _iRep.Select(exp);
        }

        public void Update(T item)
        {
             _iRep.Update(item);
        }

        public async Task UpdateAsync(T item)
        {
            await _iRep.UpdateAsync(item);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _iRep.Where(exp);
        }

        public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _iRep.WhereAsync(exp);
        }
    }
}
