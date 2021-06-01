using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Repositories
{   // Veritabanı ile ilgili en sık kullanılan komutları, işlemleri interface olarak yazdık.
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id); // id'ye göre nesne getir.
        Task<IEnumerable<TEntity>> GetAllAsync(); // tüm nesneleri getir.
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate); // movie.Find(x=>x.id==23) olan filmi bana getir.
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); // category.SingleOrDefaultAsync(x=>x.Name == "Komedi") olanları bana getir.
        Task AddAsync(TEntity entity); // bir nesneye ait ürün ekle.
        Task AddRangeAsync(IEnumerable<TEntity> entities); // bir nesneye ait tüm ürün ekle.
        void Remove(TEntity entity); // bir nesneye ait ürün sil.
        void RemoveRange(IEnumerable<TEntity> entities); // bir nesneye ait tüm ürünleri sil.
        TEntity Update(TEntity entity); // bir nesneye ait ürün düzenle.
    }
}
