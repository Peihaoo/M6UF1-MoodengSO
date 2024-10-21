using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Keyboard;
using System.IO;
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
            if (espacio/1000 >= 1)   
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
        protected static void fileList(String [] files)
        {
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
        protected static void dirList(String [] dirs)
        {
            foreach (var directory in dirs)
            {
                Console.WriteLine(directory);
            }
        }
        protected static void ls(String [] dirs)
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
        protected static void makeFile()
        {
            try
            {
                var file_stream = File.Create(@"0:\testing.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void makeDirectory()
        {
            try
            {
                Directory.CreateDirectory(@"0:\testdirectory\");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void removeDirectory(string nombreDir)
        {
            try
            {
                Directory.Delete(@nombreDir);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void removeFile(string nombreFile)
        {
            try
            {
                File.Delete(@nombreFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void writeFile(string nombreArchivo)
        {
            try
            {
                File.WriteAllText(@"0:\testing.txt", "Learning how to use VFS!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void nano(string nombre, string texto)
        {
            try
            {
                File.WriteAllText(@nombre, texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void moveFile(string nombre, string newPath)
        {
            try
            {
                File.Copy(nombre, newPath);
                File.Delete(nombre);
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
            }
        }
        protected static void readFile(string nombre)
        {
            try
            {
                Console.WriteLine(File.ReadAllText(@nombre));
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
        protected override void Run()
        {
            string input = "";
            input = Console.ReadLine();
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
            else if (input == "diskspace")
            {
                var available_space = fs.GetAvailableFreeSpace(@"0:\");
                espaiLliure((int)available_space);
            }
            else if (input == "disktype")
            {
                var fs_type = fs.GetFileSystemType(@"0:\");
                Console.WriteLine("Tipo de sistema de archivos: " + fs_type);
            }
            else if (input == "filelist")
            {
                var files_list = Directory.GetFiles(@"0:\");
                fileList(files_list);
            }
            else if (input == "dirlist")
            {
                var files_list = Directory.GetFiles(@"0:\");
                var directory_list = Directory.GetDirectories(@"0:\");
                fileList(files_list);
                dirList(directory_list);
            }
            else if (input == "ls")
            {
                var directory_list = Directory.GetFiles(@"0:\");
                ls(directory_list);
            }
            else if (input == "touch")
            {
                makeFile();
            }
            else if (input == "mkdir")
            {
                makeDirectory();
            }
            else if (input.Contains("rm") == true)
            {
                string[] words = input.Split(' ');
                if (input.Contains("rmdir") == true)
                {
                    removeDirectory(words[1]);
                }
                else
                {
                    removeFile(words[1]);
                }
            }
            else if (input.Contains("nano") == true)
            {
                string[] words = input.Split('"');
                if (words[2] == " ")
                {
                    nano(words[0], words[3]);
                }
                else
                {
                    Console.WriteLine("Formato incorrecto.");
                }
            }
            else if (input.Contains("mv") == true)
            {
                string[] words = input.Split(' ');
                moveFile(words[0], words[1]);
            }
            else if (input.Contains("rd") == true)
            {
                string[] words = input.Split(' ');
                if (input.Contains("rdB"))
                {
                    readAllBytes(words[1]);
                }
                else
                {
                    readFile(words[1]);
                }
            }
            else
            {
                Console.WriteLine("Comando desconocido.");
            }
        }
    }
}
