using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public interface IRepositorioOrdenador
{
    Ordenador? GetOrdenador(int Id);

    decimal? GetPrecioTotal(int Id);

    int? GetCalorTotal (int Id);

    void DeleteOrdenador(int Id);

    void Update(Ordenador? ordenador, int id);

    void AddOrdenador(Ordenador ordenador);

    List<Ordenador>? GetOrdenadorList();
}