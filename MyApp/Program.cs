using System;

using System.Net;
using System.IO;  // para archivos csv
using LectorCSV;
using MyApp;
using NLog;

NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); //para nloh

String DirCadetes = "Cadetes.csv";
string DirClientes = "Clientes.csv";
HelperCsv archivo = new HelperCsv();
List<Cliente> clientes = new List<Cliente>();


clientes = archivo.LeerCsvCliente(DirClientes);

List<Cadete> cadetes = new List<Cadete>();
cadetes = archivo.LeerCsvCadete(DirCadetes);

Cadeteria cadeteria = new Cadeteria("caca", 45, cadetes);
List<Pedido> Pedidos = new List<Pedido>();

Random Random = new Random();
int nro = 1;
int aux = 0;
//cargado pedidos
while (aux == 0)
{       try
        {
                aux = 1;                                //por si se ingresa algo erroneo en el aux
                Console.WriteLine("Cargado de pedidos. ");
                
                Console.WriteLine("ingrese la obserbacion. ");
                string obs = Console.ReadLine();

                Console.WriteLine("ingrese el estado. ");
                string estado = Console.ReadLine();
                
                Pedido nuevo = new Pedido(nro, obs, clientes[Random.Next(clientes.Count)], estado);
                nro ++;
                Pedidos.Add(nuevo);
                Console.WriteLine("Ingresar otro pedido? 0_NO 1_ SI");
                aux = Convert.ToInt32(Console.ReadLine());
        }
        catch (System.Exception e)
        {
                logger.Error(e.ToString());
                Console.WriteLine("datos incorrectos");
        }

}

//asignacion pedidos
foreach (Pedido pedido in Pedidos)                              //a cada pedido lo asigno de manera aleatoria en un cadete
{
        cadetes[Random.Next(cadetes.Count)].pedidos.Add(pedido);
}

foreach (Pedido pedido in Pedidos)
{
        Console.WriteLine("--- Pedido Nro: " + pedido.Nro + " ---");
                try
                {
                        
                        Console.WriteLine(
                        "Desea cambiar el estado del pedido? (0 - No, 1 - Comprado, 2 - Entregado, 3 - En camino");
                        int estado = Convert.ToInt32(Console.ReadLine());
                        switch (estado)
                        {
                                case 1:
                                        pedido.estado = "Comprado";
                                break;
                                case 2:
                                        pedido.estado = "Entregado";
                                break;
                                case 3:
                                        pedido.estado = "En camino";
                                break;
                                
                        }
                }
                catch (System.Exception e)
                {
                        logger.Error(e.ToString());
                        Console.WriteLine("datos incorrectos");
                        throw;
                }

                Console.WriteLine( "¿Desea cambiar el cadete del pedido? (0 - No, 1 - Si ");
                if (Convert.ToInt32(Console.ReadLine()) != 1) continue;
                cadeteria.Cadetes.ForEach(x => x.pedidos.Remove(pedido));
                cadeteria.Cadetes.ElementAt(Random.Next(cadetes.Count)).pedidos.Add(pedido);
}
