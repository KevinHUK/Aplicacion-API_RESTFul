using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.Services;

public class FakeRepositorioOrdenadores : IRepositorioOrdenador
{

    private readonly List<Ordenador> ordenadores = new ();

    public FakeRepositorioOrdenadores()
    {
        ordenadores.Add(
            new Ordenador()
            {
                Propietario = "Andres",
                Componentes = new[]
                {
                    new Componente
                    {

                        Categoria = CategoriasComponentes.Memorizador,
                        Descripcion = "Banco De Memoria SDRAM",
                        NumeroDeSerie = "879FH-T",
                        Precio = 150,
                        Cores = 0,
                        Grados = 24,
                        Megas = 2048
                    },
                    new Componente
                    {

                        Categoria = CategoriasComponentes.Almacenador,
                        Descripcion = "DiscoDuro SanDisk",
                        NumeroDeSerie = "789-XX-3",
                        Precio = 128,
                        Cores = 0,
                        Grados = 39,
                        Megas = 2048000
                    },
                    new Componente
                    {

                        Categoria = CategoriasComponentes.Procesador,
                        Descripcion = "Procesador Ryzen AMD",
                        NumeroDeSerie = "797-X3",
                        Precio = 278,
                        Cores = 34,
                        Grados = 60,
                        Megas = 0
                    },


                }!,

            });
        ordenadores.Add(
            new Ordenador()
            {
                Propietario = "Maria",
                Componentes = new[]
                {
                    new Componente()
                    {

                        Categoria = CategoriasComponentes.Procesador,
                        Descripcion = "Procesador Intel i7",
                        NumeroDeSerie = "789-XCS",
                        Precio = 134,
                        Cores = 9,
                        Grados = 10,
                        Megas = 0
                    },
                    new Componente
                    {

                        Categoria = CategoriasComponentes.Memorizador,
                        Descripcion = "Banco De Memoria SDRAM",
                        NumeroDeSerie = "879FH",
                        Precio = 100,
                        Cores = 0,
                        Grados = 10,
                        Megas = 512
                    },
                    new Componente
                    {

                        Categoria = CategoriasComponentes.Almacenador,
                        Descripcion = "DiscoDuro SanDisk",
                        NumeroDeSerie = "789-XX",
                        Precio = 50,
                        Cores = 0,
                        Grados = 10,
                        Megas = 512000
                    }
                }!,

            });
    }
    public Ordenador? GetOrdenador(int Id)

    {
        
        return ordenadores.Find(x => x.Id == Id);
    }

    public decimal? GetPrecioTotal(int Id)
    {
        var ordenador = ordenadores.Find(x => x.Id == Id);
        if (ordenador != null)
        {
            ordenador.Precio = ordenador.Componentes!.Sum(x => x.Precio);
        }
        return ordenador!.Precio;
    }

    public int? GetCalorTotal(int Id)
    {

        var ordenador =ordenadores.Find(x=>x.Id == Id);
        
        if (ordenador != null)
        {
            ordenador.CalorTotal = ordenador.Componentes!.Sum(x => x.Grados);


        }
        return ordenador!.CalorTotal;
    }

    public void DeleteOrdenador(int Id)
    {
        ordenadores.RemoveAt(Id);
    }

    public void Update(Ordenador? ordenador, int id)
    {
	    if (ordenador != null)
        {
            var ordenadorSinActualizar = ordenadores.Find(x => x.Id == id);
            if (ordenadorSinActualizar != null)
            {
	            ordenadorSinActualizar.Componentes = ordenador.Componentes;
	            ordenadorSinActualizar.CalorTotal = ordenador.CalorTotal;
	            ordenadorSinActualizar.Precio = ordenador.Precio;
	            ordenadorSinActualizar.PedidoId = ordenador.PedidoId;
	            ordenadorSinActualizar.Propietario = ordenador.Propietario;
            }
        }

	    if (ordenador != null) ordenadores.Add(ordenador);
    }



    public void AddOrdenador(Ordenador ordenador)
    {
        var idNueva = ordenadores.Count;
        ordenador.Id = idNueva;
        ordenadores.Add(ordenador);
    }

    public List<Ordenador>? GetOrdenadorList()
    {
        return ordenadores.ToList();
    }
}