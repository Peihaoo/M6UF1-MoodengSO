using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Keyboard;
using System.IO;
using Cosmos.System.FileSystem;
using Microsoft.VisualBasic;

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
        protected static void dibujaMoodeng()
        {
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
            Console.WriteLine("                           |        /  `\"-*--*' |       |");
            Console.WriteLine("                           |        |           |       :");
            Console.WriteLine(" ~~~~~~~---   ~-~-~-~   -~-~-~-~-~-~~~~~~  ~~~~  ~-~-~-~-~-~-~-");
            Console.WriteLine("------~~~~~~~~~----------~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
            Console.WriteLine(" ~~~~~~~~~   ~~~~~~~~~       ~~~~~~~   ~~~~~~~~~  ~~~~~~~~~~~~~~~\r\n ");
        }
        protected static void help()
        {
            Console.WriteLine("help\t\t\t-Muestra guía de comandos.");
            Console.WriteLine("about\t\t\t-Muestra información sobre el sistema operativo.");
            Console.WriteLine("\nshutdown\t\t-Apaga el sistema.");
            Console.WriteLine("\nreboot\t\t\t-Reinicia el sistema.");
            Console.WriteLine("restart\t\t\t-Reinicia el sistema.");
            Console.WriteLine("clear\t\t\t-Limpia la consola.");
            Console.WriteLine("cls\t\t\t\t-Limpia la consola.");
            Console.WriteLine("\ndiskspace\t\t-Muestra el espacio disponible en el disco");
            Console.WriteLine("disktype\t\t-Muestra el tipo de sistema de archivos.");
            Console.WriteLine("filelist\t\t-Muestra una lista de archivos.");
            Console.WriteLine("dirlist\t\t\t-Muestra una lista de archivos y directorios.");
            Console.WriteLine("ls\t\t\t\t-Muestra los archivos y directorios dentro del directorio actual");
            Console.WriteLine("touch nombre\t-Crea un archivo.");
            Console.WriteLine("mkdir nombre\t-Crea un directorio.");
            Console.WriteLine("rm archivo.txt\t-Elimina el archivo seleccionado");
            Console.WriteLine("rmdir nombre\t-Elimina el archivo seleccionado");
            Console.WriteLine("nano \"archivo\" \"Texto\"\t-Sobreescribe un archivo existente.");
            Console.WriteLine("mv archivo.txt path\t\t-Mueve un archivo.");
            Console.WriteLine("rd archivo.txt\t-Visualiza los contenidos de un archivo.");
            Console.WriteLine("rdB archivo.txt\t-Lee todos los bytes de un archivo.");
            Console.WriteLine("\nsum num1 num2\t -Devuelve la suma de los dos numeros");
            Console.WriteLine("sub num1 num2\t -Devuelve la resta de los dos numeros");
            Console.WriteLine("mult num1 num2\t -Devuelve la multiplicacion entre los dos numeros");
            Console.WriteLine("div num1 num2\t -Devuelve la division entre los dos numeros");
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
        protected static void espaiLliure(int espacio)
        {
            int espacioFormated = espacio;
            Console.WriteLine("Espacio libre: ");
            //Si podemos pasar a MB
            if (espacio / 1000 >= 1)
            {
                espacioFormated = (espacio / 1000);
                //Si podemos pasar a GB
                if (espacioFormated / 1000 >= 1)
                {
                    espacioFormated /= 1000;
                    //Si podemos pasar a TB
                    if (espacioFormated / 1000 >= 1)
                    {
                        espacioFormated /= 1000;
                        Console.Write(espacioFormated + "TB");
                    }
                    //No llega a TB
                    else
                    {
                        Console.Write(espacioFormated + "GB");
                    }
                }
                //No llega a GB
                else
                {
                    Console.Write(espacioFormated + "MB");
                }
            }
            //No llega a MB
            else
            {
                Console.Write(espacioFormated + "B");
            }
            Console.WriteLine("");
        }
        protected static void shutdown()
        {
            Cosmos.System.Power.Shutdown();
        }
        protected static void reboot()
        {
            Cosmos.System.Power.Reboot();
        }
        protected static void fileList(String[] files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        protected static void dirList(String[] dirs)
        {
            foreach (var directory in dirs)
            {
                Console.WriteLine(directory);
            }
        }
        protected static void ls(String[] dirs)
        {
            try
            {
                foreach (var file in dirs)
                {
                    var content = File.ReadAllText(file);

                    Console.WriteLine("File name: " + file);
                    Console.WriteLine("File size: " + content.Length);
                    Console.WriteLine("Content: " + content);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void makeFile(string nombre)
        {
            var currentDir = Directory.GetCurrentDirectory();
            string path = currentDir + "\\" + nombre;
            try
            {
                var file_stream = File.Create(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void makeDirectory(string nombre)
        {
            var sobreescribir = "";
            var currentDir = Directory.GetCurrentDirectory();
            try
            {
                if (File.Exists(nombre))
                {
                    Console.WriteLine("Ya existe el directorio " + nombre + ", quieres sobreescribirlo? (Y/N)");
                    sobreescribir = Console.ReadLine();
                    if (sobreescribir == "Y" || sobreescribir == "y")
                    {
                        removeDirectory(nombre);
                    }
                }
                Directory.CreateDirectory(currentDir + "\\" + nombre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void removeDirectory(string nombreDir)
        {
            var currentDir = Directory.GetCurrentDirectory();
            try
            {
                Directory.Delete(currentDir + "\\" + nombreDir);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void removeFile(string nombreFile)
        {
            var currentDir = Directory.GetCurrentDirectory();
            try
            {
                File.Delete(currentDir + "\\ + nombreFile");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void nano(string nombre, string texto)
        {
            var currentDir = Directory.GetCurrentDirectory();
            string path = currentDir + "\\" + nombre;
            try
            {
                File.WriteAllText(path, texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void moveFile(string nombre, string destination)
        {
            var currentDir = Directory.GetCurrentDirectory();
            string sourcePath = currentDir + "\\" + nombre;
            string destinationPath = currentDir + "\\" + destination;

            try
            {
                File.Copy(sourcePath, destinationPath);
                File.Delete(sourcePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        protected static void readFile(string nombre)
        {
            try
            {
                Console.WriteLine(File.ReadAllText(nombre));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void readAllBytes(string nombre)
        {
            try
            {
                Console.WriteLine(File.ReadAllBytes(@nombre));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static float sumar (float num1, float num2)
        {
            return num1+num2;
        }
        protected static float restar (float num1, float num2)
        {
            return num1 - num2;
        }
        protected static float multiplicar(float num1, float num2)
        {
            return num1 * num2;
        }
        protected static void dividir(float num1, float num2)
        {
            if (num2 == 0) Console.Write("No se puede dividir entre 0.\n");
            else Console.Write((num1/num2).ToString("0.00"));
        }
        protected override void Run()
        {
            string input = "";
            input = Console.ReadLine();
            string[] comandParts = input.Split(' ');

            switch (comandParts[0].ToLower())
            {
                case "help": help(); break;
                case "about": about(); break;
                case "shutdown": shutdown(); break;
                case "restart": reboot(); break;
                case "reboot": reboot(); break;
                case "clear": Console.Clear(); break;
                case "cls": Console.Clear(); break;
                case "diskspace":
                    var available_space = fs.GetAvailableFreeSpace(@"0:\");
                    espaiLliure((int)available_space);
                    break;
                case "filelist":
                    var files_list = Directory.GetFiles(@"0:\");
                    fileList(files_list);
                    break;
                case "dirlist":
                    files_list = Directory.GetFiles(@"0:\");
                    var directory_list = Directory.GetDirectories(@"0:\");
                    fileList(files_list);
                    dirList(directory_list);
                    break;
                case "ls":
                    directory_list = Directory.GetFiles(@"0:\");
                    ls(directory_list);
                    break;
                case "touch":
                    makeFile(comandParts[1]);
                    break;
                case "mkdir":
                    makeDirectory(comandParts[1]);
                    break;
                case "rm": removeFile(comandParts[1]); break;
                case "rmdir": removeDirectory(comandParts[1]); break;
                case "nano":
                    string[] split = input.Split('"');
                    if (split[2] == " ")
                    {
                        nano(split[1], comandParts[3]);
                    }
                    else
                    {
                        Console.WriteLine("Formato incorrecto.");
                    }
                    break;
                case "mv": moveFile(comandParts[1], comandParts[2]); break;
                case "rd": readFile(comandParts[1]); break;
                case "rdB": readAllBytes(comandParts[1]); break;
                case "sum": Console.WriteLine("Resultado: " + sumar(float.Parse(comandParts[1]),float.Parse(comandParts[2])).ToString("0.00")); break;
                case "sub": Console.WriteLine("Resultado: " + restar(float.Parse(comandParts[1]),float.Parse(comandParts[2])).ToString("0.00")); break;
                case "mult": Console.Write("Resultado: " + multiplicar(float.Parse(comandParts[1]), float.Parse(comandParts[2])).ToString("0.00")); break;
                case "div": 
                    Console.WriteLine("Resultado: "); 
                    dividir(float.Parse(comandParts[1]), float.Parse(comandParts[2]));
                    break;

                default:
                    Console.WriteLine("Comando desconocido.");
                    break;
            }
        }
    }
}
