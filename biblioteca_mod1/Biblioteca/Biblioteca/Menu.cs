using System;

namespace Biblioteca
{
    public class Menu
    {
        private Biblioteca biblioteca = new Biblioteca();

        public void MostrarMenu()
        {
            biblioteca.CargarDatosPrueba(); // Cargar datos de prueba al inicio
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nBienvenido a la Biblioteca");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Registrar estudiante");
                Console.WriteLine("3. Registrar profesor");
                Console.WriteLine("4. Prestar libro");
                Console.WriteLine("5. Devolver libro");
                Console.WriteLine("6. Ver estado de todos los libros");
                Console.WriteLine("7. Ver libros prestados de un usuario");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarLibro();
                        break;
                    case "2":
                        RegistrarEstudiante();
                        break;
                    case "3":
                        RegistrarProfesor();
                        break;
                    case "4":
                        PrestarLibro();
                        break;
                    case "5":
                        DevolverLibro();
                        break;
                    case "6":
                        biblioteca.VerEstadoLibros();
                        break;
                    case "7":
                        VerLibrosPrestadosUsuario();
                        break;
                    case "8":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        private void AgregarLibro()
        {
            Console.Write("Ingrese el título del libro: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();
            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine();

            biblioteca.AgregarLibro(titulo, autor, isbn);
            Console.WriteLine("Libro agregado exitosamente.");
        }

        private void RegistrarEstudiante()
        {
            Console.Write("Ingrese el ID del estudiante: ");
            string id = Console.ReadLine();
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la carrera del estudiante: ");
            string carrera = Console.ReadLine();

            biblioteca.RegistrarEstudiante(id, nombre, carrera);
            Console.WriteLine("Estudiante registrado exitosamente.");
        }

        private void RegistrarProfesor()
        {
            Console.Write("Ingrese el ID del profesor: ");
            string id = Console.ReadLine();
            Console.Write("Ingrese el nombre del profesor: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el departamento del profesor: ");
            string departamento = Console.ReadLine();

            biblioteca.RegistrarProfesor(id, nombre, departamento);
            Console.WriteLine("Profesor registrado exitosamente.");
        }

        private void PrestarLibro()
        {
            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine();
            Console.Write("Ingrese el ID del usuario: ");
            string userId = Console.ReadLine();

            if (biblioteca.PrestarLibro(isbn, userId))
            {
                Console.WriteLine("Libro prestado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pudo prestar el libro. Verifique la disponibilidad, el ID del usuario y los límites de préstamo.");
            }
        }

        private void DevolverLibro()
        {
            Console.Write("Ingrese el ISBN del libro: ");
            string isbn = Console.ReadLine();
            Console.Write("Ingrese el ID del usuario: ");
            string userId = Console.ReadLine();

            if (biblioteca.DevolverLibro(isbn, userId))
            {
                Console.WriteLine("Libro devuelto exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pudo devolver el libro. Verifique que el usuario tiene el libro.");
            }
        }

        private void VerLibrosPrestadosUsuario()
        {
            Console.Write("Ingrese el ID del usuario: ");
            string userId = Console.ReadLine();

            biblioteca.VerLibrosPrestadosUsuario(userId);
        }
    }
}