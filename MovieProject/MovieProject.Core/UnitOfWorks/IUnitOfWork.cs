using MovieProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.UnitOfWorks
{   // Yapılan işlemler sonucu veritabanına da yansıması için Commit işlemleri çağırılır. Herhangi bir hataya karşılık commit etmediğimiz sürece, yapılan işlemler db'e             yansımaz.
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        ICategoryRepository Categories { get; }
        ICinemaRepository Cinemas { get; }
        Task CommitAsync();
        void Commit();
    }
}
