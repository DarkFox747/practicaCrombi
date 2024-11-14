using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Menu
    {
        private Biblioteca biblioteca = new Biblioteca();

        public void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nBienvenido a la Biblioteca");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Registrar usuario");
                Console.WriteLine("3. Prestar libro");
                Console.WriteLine("4. Devolver libro");
                Console.WriteLine("5. Ver estado de todos los libros");
                Console.WriteLine("6. Ver libros prestados de un usuario");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarLibro();
                        break;
                    case "2":
                        RegistrarUsuario();
                        break;
                    case "3":
                        PrestarLibro();
                        break;
                    case "4":
                        DevolverLibro();
                        break;
                    case "5":
                        biblioteca.VerEstadoLibros();
                        break;
                    case "6":
                        VerLibrosPrestadosUsuario();
                        break;
                    case "7":
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

        private void RegistrarUsuario()
        {
            Console.Write("Ingrese el ID del usuario: ");
            string id = Console.ReadLine();
            Console.Write("Ingrese el nombre del usuario: ");
            string nombre = Console.ReadLine();

            biblioteca.RegistrarUsuario(id, nombre);
            Console.WriteLine("Usuario registrado exitosamente.");
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
                Console.WriteLine("No se pudo prestar el libro. Verifique la disponibilidad y el ID del usuario.");
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
