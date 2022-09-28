using System;

using System.Net;
using System.IO;  // para archivos csv
using LectorCSV;
using NLog;
String DirCadetes = "Cadetes.csv";
string DirClientes = "Clientes.csv";
HelperCsv archivo = new HelperCsv();
List<string[]> clientes = new List<string[]>();
clientes = archivo.LeerCsv(DirClientes);

foreach (string[] item in clientes)
{
    
        Console.WriteLine(item);
    
}



