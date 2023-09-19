using MVC_ComponentesCodeFirst.Models;

namespace MVC_ComponentesCodeFirst.App_Data;

public static class DbInitializerComponentes
{
    public static void Initialize(ComponentesCodeFirstContext contexto)
    {
        
        contexto.Database.EnsureCreated();
        if (contexto.Componentes != null && contexto.Componentes.Any())
        {
            return;
        }

        var componentes = new []
        {
            new Componente
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

                Categoria = CategoriasComponentes.Procesador,
                Descripcion = "Procesador Intel i7",
                NumeroDeSerie = "789-XCD",
                Precio = 138,
                Cores = 10,
                Grados = 12,
                Megas = 0
            },
            new Componente
            {

                Categoria = CategoriasComponentes.Procesador,
                Descripcion = "Procesador Intel i7",
                NumeroDeSerie = "789-XCT",
                Precio = 138,
                Cores = 11,
                Grados = 12,
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

                Categoria = CategoriasComponentes.Memorizador,
                Descripcion = "Banco De Memoria SDRAM",
                NumeroDeSerie = "879FH-L",
                Precio = 125,
                Cores = 0,
                Grados = 15,
                Megas = 1024
            },
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
                NumeroDeSerie = "789-XX",
                Precio = 50,
                Cores = 0,
                Grados = 10,
                Megas = 512000
            },
            new Componente
            {

                Categoria = CategoriasComponentes.Almacenador,
                Descripcion = "DiscoDuro SanDisk",
                NumeroDeSerie = "789-XX-2",
                Precio = 90,
                Cores = 0,
                Grados = 29,
                Megas = 1024000
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
                NumeroDeSerie = "797-X",
                Precio = 78,
                Cores = 10,
                Grados = 30,
                Megas = 0
            },

            new Componente
            {

                Categoria = CategoriasComponentes.Procesador,
                Descripcion = "Procesador Ryzen AMD",
                NumeroDeSerie = "797-X2",
                Precio = 178,
                Cores = 29,
                Grados = 30,
                Megas = 0
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
            new Componente
            {

                Categoria = CategoriasComponentes.Almacenador,
                Descripcion = "Disco Mecánico Patatin",
                NumeroDeSerie = "788-fg",
                Precio = 37,
                Cores = 0,
                Grados = 35,
                Megas = 250
            },
            new Componente
            {

                Categoria = CategoriasComponentes.Almacenador,
                Descripcion = "Disco Mecánico Patatin",
                NumeroDeSerie = "788-fg-2",
                Precio = 67,
                Cores = 0,
                Grados = 35,
                Megas = 250
            },
            new Componente
            {

                Categoria = CategoriasComponentes.Almacenador,
                Descripcion = "Disco Mecánico Patatin",
                NumeroDeSerie = "788-fg-3",
                Precio = 97,
                Cores = 0,
                Grados = 35,
                Megas = 250
            }
        };
        contexto.Componentes!.AddRange(componentes);
        contexto.SaveChanges();
    }
}