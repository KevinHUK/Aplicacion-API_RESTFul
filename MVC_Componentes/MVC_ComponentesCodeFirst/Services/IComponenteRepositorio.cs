using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public interface IComponenteRepositorio
{

        List<Componente>? All();
        Componente? GetById(int Id);
        void Add(Componente componente);
        void Update(Componente componente, int id);
        void Delete(int id);




}