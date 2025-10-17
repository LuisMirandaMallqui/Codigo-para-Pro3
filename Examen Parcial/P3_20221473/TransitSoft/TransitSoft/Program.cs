using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TransitSoftBusiness;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;


namespace TransitSoft
{
    public class Program
    {
        private static ReporteInfraccionService reporte;
        //OSCAR SEBASTIAN CESPEDES VASQUEZ
        static void Main(string[] args)
        {
            reporte = new ReporteInfraccionService();
            BindingList<ReporteInfraccion> lista = new BindingList<ReporteInfraccion>();
            FileStream fs = new FileStream("reportes_infracciones.bin", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                while (fs.Position < fs.Length)
                {
                    ReporteInfraccion objeto = (ReporteInfraccion)formatter.Deserialize(fs);
                    
                    lista.Add(objeto);
                }
                List<ReporteInfraccion> lista2 = new List<ReporteInfraccion>();

                foreach (ReporteInfraccion reporte in lista)
                {
                    //Console.WriteLine(reporte.Materno);
                    lista2.Add(reporte);
                }
                reporte.ejecutandoInsercion(lista2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar: " + ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }
    }   
    
}
