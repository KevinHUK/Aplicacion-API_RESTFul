using MVC_ComponentesDatabaseFirst.Models;

namespace MVC_ComponentesDatabaseFirst.Services;

public interface IComponenteRepositorio
{

        List<Componente>? All();
        Componente? GetById(int Id);
        void Add(Componente componente);
        void Update(Componente componente);
        void Delete(int id);


}