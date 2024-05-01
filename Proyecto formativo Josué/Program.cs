namespace Proyecto_formativo_Josué
{
    internal class Program
    {


        static string[,] empleados = new string[10, 8]; 
        static int cantidadEmpleados = 3; 

        static void Main(string[] args)
        {
            empleados[0, 0] = "Juan";
            empleados[0, 1] = "Pérez";
            empleados[0, 2] = "1990-05-15";
            empleados[0, 3] = "Soltero";
            empleados[0, 4] = "Calle Principal 123";
            empleados[0, 5] = "Salvadoreño";
            empleados[0, 6] = "admin";
            empleados[0, 7] = "123";

            empleados[1, 0] = "María";
            empleados[1, 1] = "López";
            empleados[1, 2] = "1985-10-25";
            empleados[1, 3] = "Casado";
            empleados[1, 4] = "Avenida Central 456";
            empleados[1, 5] = "Hondureño";
            empleados[1, 6] = "usuario1";
            empleados[1, 7] = "clave1";

            empleados[2, 0] = "Carlos";
            empleados[2, 1] = "Martínez";
            empleados[2, 2] = "1988-08-08";
            empleados[2, 3] = "Soltero";
            empleados[2, 4] = "Calle Secundaria 789";
            empleados[2, 5] = "Guatemalteco";
            empleados[2, 6] = "usuario2";
            empleados[2, 7] = "clave2";

            bool loggedIn = Login();
            if (loggedIn)
            {
                int opcion;
                do
                {
                    Console.WriteLine("\nSeleccione una opción:");
                    Console.WriteLine("1. Ingresar nuevos empleados");
                    Console.WriteLine("2. Consultar nómina de empleados");
                    Console.WriteLine("3. Actualizar la información de un empleado");
                    Console.WriteLine("4. Salir");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            IngresarEmpleado();
                            break;
                        case 2:
                            ConsultarNomina();
                            break;
                        case 3:
                            ActualizarEmpleado();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                            break;
                    }
                } while (opcion != 4);
            }
        }

        static bool Login()
        {
            int intentos = 0;
            while (intentos < 3)
            {
                Console.Write("\nUsuario: ");
                string usuario = Console.ReadLine();
                Console.Write("Contraseña: ");
                string contraseña = Console.ReadLine();

                for (int i = 0; i < cantidadEmpleados; i++)
                {
                    if (usuario == empleados[i, 6] && contraseña == empleados[i, 7])
                    {
                        Console.WriteLine("\nInicio de sesión exitoso.");
                        return true;
                    }
                }
                intentos++;
                Console.WriteLine($"Usuario o contraseña incorrectos. Intento {intentos} de 3.");
            }
            Console.WriteLine("\nLa cantidad de intentos erróneos ya ha alcanzado su límite.");
            return false;
        }

        static void IngresarEmpleado()
        {
            if (cantidadEmpleados < empleados.GetLength(0))
            {
                Console.WriteLine("\nIngresar nuevo empleado:");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write($"Ingrese {ObtenerNombreCampo(i)}: ");
                    empleados[cantidadEmpleados, i] = Console.ReadLine();
                }
                Console.Write("Ingrese usuario: ");
                empleados[cantidadEmpleados, 6] = Console.ReadLine();
                Console.Write("Ingrese contraseña: ");
                empleados[cantidadEmpleados, 7] = Console.ReadLine();
                cantidadEmpleados++;
                Console.WriteLine("Empleado ingresado exitosamente.");
            }
            else
            {
                Console.WriteLine("\nNo hay espacio disponible para ingresar más empleados.");
            }
        }

        static void ConsultarNomina()
        {
            Console.WriteLine("\nNómina de empleados:");
            for (int i = 0; i < cantidadEmpleados; i++)
            {
                Console.WriteLine($"Empleado {i + 1}:");
                for (int j = 0; j < 6; j++)
                {
                    Console.WriteLine($"{ObtenerNombreCampo(j)}: {empleados[i, j]}");
                }
                Console.WriteLine("Usuario: " + empleados[i, 6]);
                Console.WriteLine();
            }
        }

        static void ActualizarEmpleado()
        {
            Console.Write("\nIngrese el número de empleado a actualizar (1 - 3): ");
            int indiceEmpleado = Convert.ToInt32(Console.ReadLine()) - 1;

            if (indiceEmpleado >= 0 && indiceEmpleado < cantidadEmpleados)
            {
                Console.WriteLine("\nIngrese los nuevos datos:");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write($"Nuevo {ObtenerNombreCampo(i)}: ");
                    empleados[indiceEmpleado, i] = Console.ReadLine();
                }
                Console.WriteLine("Datos del empleado actualizados exitosamente.");
            }
            else
            {
                Console.WriteLine("\nNúmero de empleado inválido.");
            }
        }

        static string ObtenerNombreCampo(int indice)
        {
            string[] nombresCampos = { "Nombre", "Apellido", "Fecha de nacimiento", "Estado civil", "Dirección", "Nacionalidad" };
            return nombresCampos[indice];
        }

    }
}
