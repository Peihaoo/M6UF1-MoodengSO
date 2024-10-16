using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Keyboard;
namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());
            Console.WriteLine("Bienvenido a Moodeng");

        }
        protected static void reconocimientoComandos(string input){
            if (input == "help")
            {
                help();
            }
            else if (input == "about")
            {
                about();
            }
            else if (input == "shutdown")
            {
                shutdown();
            }
            else if (input == "restart" || input == "reboot")
            {
                reboot();
            }
            else
            {
                Console.WriteLine("Comando desconocido.");
            }
        }
        protected static void help()
        {
            Console.WriteLine("help\t\t-Muestra guía de comandos.");
            Console.WriteLine("about\t\t-Muestra información sobre el sistema operativo.");
            Console.WriteLine("\nshutdown\t\t-Apaga el sistema.");
            Console.WriteLine("\nreboot\t\t-Reinicia el sistema.");
            Console.WriteLine("restart\t\t-Reinicia el sistema.");
        }
        protected static void about()
        {
            Console.WriteLine("¿Qué es Moodeng?");
            Console.WriteLine("Moodeng es un sistema operativo open source. Un sistema operativo es el \n" +
                              "software que administra directamente el hardware y los recursos de un sistema, como la CPU, la \n" +
                              "memoria y el almacenamiento. El sistema operativo se encuentra entre las aplicaciones y \n" +
                              "el hardware y establece las conexiones entre todo el software y los recursos físicos que \n" +
                              "realizan el trabajo.");
        }
        protected static void shutdown()
        {
            Cosmos.System.Power.Shutdown();
        }
        protected static void reboot()
        {
            Cosmos.System.Power.Reboot();
        }
        protected override void Run()
        {
            string input = "";
            Console.WriteLine("Escriba \"help\" para recibir una guía de comandos.");
            input = Console.ReadLine();
            reconocimientoComandos(input);
        }
    }
}
