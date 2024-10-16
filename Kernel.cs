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
            Console.WriteLine("Bienvenido al sistema operativo MOODENG.\n");
            dibujaMoodeng();
            Console.WriteLine("Escriba \"help\" para recibir una guía de comandos.");
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
            else if (input == "clear" || input == "cls") 
            {
                Console.Clear();
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
            Console.WriteLine("clear\t\t-Limpia la consola.");
            Console.WriteLine("cls\t\t-Limpia la consola.");
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
        protected static void dibujaMoodeng() {
            Console.WriteLine("                     .^.,*.");
            Console.WriteLine("                    (   )  )");
            Console.WriteLine("                   .~       \"-._   _.-'-*'-*'-*'-*'-'-.--._");
            Console.WriteLine("                 /'             `\"'                        `.");
            Console.WriteLine("               _/'                                           `.");
            Console.WriteLine("          __,\"\"                                                ).--.");
            Console.WriteLine("       .-'       `._.'                                          .--.\\");
            Console.WriteLine("      '                                                         )   \\`:");
            Console.WriteLine("     ;                                                          ;    \"");
            Console.WriteLine("    :                                                           )");
            Console.WriteLine("    | 8                                                        ;");
            Console.WriteLine("     =                  )                                     .");
            Console.WriteLine("      \\                .                                    .'");
            Console.WriteLine("       `.            ~  \\                                .-'");
            Console.WriteLine("         `-._ _ _ . '    `.          ._        _        |");
            Console.WriteLine("                           |        /  `\"-*--*' |       |  mb");
            Console.WriteLine("                           |        |           |       :");
            Console.WriteLine(" ~~~~~~~---   ~-~-~-~   -~-~-~-~-~-~~~~~~  ~~~~  ~-~-~-~-~-~-~-");
            Console.WriteLine("------~~~~~~~~~----------~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
            Console.WriteLine(" ~~~~~~~~~   ~~~~~~~~~       ~~~~~~~   ~~~~~~~~~  ~~~~~~~~~~~~~~~\r\n ");
        }
        protected override void Run()
        {
            string input = "";
            input = Console.ReadLine();
            reconocimientoComandos(input);
        }
    }
}
