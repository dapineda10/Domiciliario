using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domiciliario
{
    class Program
    {
        public static Domiciliario[] vecDomiciliario = new Domiciliario[2];
        public static Pedidos[,] vecPedidos = new Pedidos[5, 5];

        static void Main(string[] args)
        {
            var opcion = string.Empty;

            do
            {
                Console.WriteLine("\nMenú\n" +
                    "Seleccione una opcion: \n" +
                    "1. Agregar Domiciliario \n" +
                    "2. Agregar Pedido \n" +
                    "0. Salir del Sistema \n");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Puede ingresar hasta 2 domiciliarios, ingrese por favor la cantidad que requiere");
                        var cantDomi = int.Parse(Console.ReadLine());
                        AgregarDomiciliario(cantDomi);
                        break;
                    case "2":
                        Console.WriteLine("Cuantos pedidos desea realizar? ");
                        var cantPedi = int.Parse(Console.ReadLine());
                        RegistrarPedido(cantPedi);
                        break;
                    default:
                        Console.WriteLine("El valor ingresado no es el correcto");
                        break;
                }
            } while (!opcion.Equals("0"));
            Console.ReadKey();
        }

        private static void RegistrarPedido(int cantidadPedido)
        {
            Pedidos pedido;
            for (int c= 0; c<cantidadPedido;c++)
            {
                pedido = new Pedidos();
                Console.WriteLine("Ingrese datos de pedido: ");
                pedido.Pedido = Console.ReadLine();
                Console.WriteLine(" Ingrese cliente de pedido: ");
                pedido.Cliente = Console.ReadLine();
                Console.WriteLine(" Ingrese la distancia a realizar el domicilio: ");
                pedido.Distancia = int.Parse(Console.ReadLine());


                
                //Muestra lista de domiciliario si existe y lo asigna.
                if (vecDomiciliario.Length > 0)
                {

                    Console.WriteLine("Elija uno de los siguientes domiciliarios digitando el código");

                    foreach (var item in vecDomiciliario)
                    {
                        Console.WriteLine($"{item.Codigo} - {item.Nombre}");
                    }

                    bool hayDomiciliario = false;
                    do
                    {
                        int domiciliario = validarNumero();
                        if (vecDomiciliario.Any(d => d.Codigo == domiciliario))
                        {
                            pedido.codigoDomiciliario = domiciliario;
                            hayDomiciliario = true;
                        }
                        else
                        {
                            Console.WriteLine("El domiciliario no existe, ingrese por favor uno de la lista");
                            foreach (var item in vecDomiciliario)
                            {
                                Console.WriteLine($"{item.Codigo} - {item.Nombre}");
                            }
                        }

                    } while (!hayDomiciliario);

                }


                for (int i = 0; i < vecPedidos.GetLength(0); i++)
                {                    
                    for (int j = 0; j < vecPedidos.GetLength(1); j++)
                    {
                        if(vecPedidos[i,j] == null)
                        {
                            vecPedidos[i, j] = pedido;
                            Console.WriteLine("******  Hemos recibido su pedido  *******");
                        break;
                        }                                               
                    }
                    break;
                }

            }

            //Imprimir matriz
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; i < 5; i++)
                {
                    if (vecPedidos[i, j] == null)
                    {
                        Console.Write("Libre");
                    }
                    else
                    {
                        Console.Write("[" + vecPedidos[i, j].Pedido + "]");
                    }
                        
                }
                Console.WriteLine();
            }

            foreach (var item in vecPedidos)
            {
                if (item != null)
                {
                    try
                    {
                        Console.WriteLine($"Cliente: {item.Cliente} Domiciliario: {item.codigoDomiciliario} Distancia: {item.Distancia} Pedido: {item.Pedido}");
                    }
                    catch (Exception e)
                    {
                        Console.ReadKey();
                    }
                }
            }
        }

        public static void AgregarDomiciliario(int cantDomi)
        {
            Domiciliario domiciliario;
            for(int i = 0; i< cantDomi; i++)
            {
                domiciliario = new Domiciliario();
                Console.WriteLine("Por favor ingrese el nombre del domiciliario: ");
                domiciliario.Nombre = Console.ReadLine();
                Console.WriteLine("Por favor ingrese el código del domiciliario: ");
                domiciliario.Codigo = validarNumero();
                vecDomiciliario[i] = domiciliario;
            }
        }

        private static int validarNumero() {
            bool soloNumero = false;
            int numero = 0;
            while (!soloNumero)
            {
                try
                {
                    
                    numero = int.Parse(Console.ReadLine());
                    soloNumero = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Sólo se pueden agregar números");
                }
            }
            return numero;
        }

    }
}
