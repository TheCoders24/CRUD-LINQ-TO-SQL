﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
//using System.Configuration;


namespace CRUD_LINQ_TO_SQL
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CapaPresentacion.Menu miMenu = new CapaPresentacion.Menu();
            Application.Run(miMenu);
        }
    }
}