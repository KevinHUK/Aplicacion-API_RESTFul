using System.ComponentModel.DataAnnotations;
using TiendaOrdenadores.Factoria.Enumeradores;

namespace TiendaOrdenadores.Validadores;

public class ValidadorOrdenadorAttribute : ValidationAttribute
{
    public override bool IsValid(Object? value)
    {

        var ordenador = (Ordenador?)value;
        var numProcesadores = 0;
        var numMemorias = 0;
        var numDiscos = 0;
        if (ordenador is not null)
        {

            foreach (var item in ordenador.DameOrdenador())
            {
                switch (item.Tipo)
                {
                    case TipoColeccionComponentes.Guardadores:
                        numDiscos++;
                        break;
                    case TipoColeccionComponentes.Memorizadores:
                        numMemorias++;
                        break;
                    case TipoColeccionComponentes.Procesadores:
                        numProcesadores++;
                        break;

                }


            }

            return
                   (ordenador is { CalorTotal: >= 0, PrecioPorOrdenador: >= 0 } && numDiscos > 0) || numMemorias > 0 || numProcesadores > 0;
        }

        return false;
    }
}