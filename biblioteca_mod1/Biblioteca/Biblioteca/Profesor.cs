using System.Collections.Generic;

namespace Biblioteca
{
    public class Profesor : Usuario
    {
        public string Departamento { get; set; }

        public Profesor(string id, string nombre, string departamento) : base(id, nombre)
        {
            Departamento = departamento;
            MaxLibrosPrestados = 5;
        }

        public override bool PuedePedirPrestado()
        {
            return LibrosPrestados.Count < MaxLibrosPrestados;
        }
    }
}
