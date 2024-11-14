using System.Collections.Generic;

namespace Biblioteca
{
    public class Estudiante : Usuario
    {
        public string Carrera { get; set; }

        public Estudiante(string id, string nombre, string carrera) : base(id, nombre)
        {
            Carrera = carrera;
            MaxLibrosPrestados = 3;
        }
    }
}