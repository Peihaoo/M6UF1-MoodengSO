using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Keyboard;
using System.IO;
using Cosmos.System.FileSystem;
using Microsoft.VisualBasic;
using IL2CPU.API.Attribs;
using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using Cosmos.HAL.Audio;
using Cosmos.System.Graphics;
using System.Drawing;


namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        //static string ASC16Base64 = "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AAB4zMzM2MzGxsbMAAAAAAAA/sbGwMDAwMDAwAAAAAAAAAAA/mxsbGxsbGwAAAAAAAAA/sZgMBgwYMb+AAAAAAAAAAAAftjY2NjYcAAAAAAAAAAAZmZmZmZ8YGDAAAAAAAAAAHbcGBgYGBgYAAAAAAAAAH4YPGZmZjwYfgAAAAAAAAA4bMbG/sbGbDgAAAAAAAA4bMbGxmxsbGzuAAAAAAAAHjAYDD5mZmZmPAAAAAAAAAAAAH7b29t+AAAAAAAAAAAAAwZ+29vzfmDAAAAAAAAAHDBgYHxgYGAwHAAAAAAAAAB8xsbGxsbGxsYAAAAAAAAAAP4AAP4AAP4AAAAAAAAAAAAYGH4YGAAA/wAAAAAAAAAwGAwGDBgwAH4AAAAAAAAADBgwYDAYDAB+AAAAAAAADhsbGBgYGBgYGBgYGBgYGBgYGBgYGNjY2HAAAAAAAAAAABgYAH4AGBgAAAAAAAAAAAAAdtwAdtwAAAAAAAAAOGxsOAAAAAAAAAAAAAAAAAAAAAAAABgYAAAAAAAAAAAAAAAAAAAAGAAAAAAAAAAADwwMDAwM7GxsPBwAAAAAANhsbGxsbAAAAAAAAAAAAABw2DBgyPgAAAAAAAAAAAAAAAAAfHx8fHx8fAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
        //static MemoryStream ASC16FontMS = new MemoryStream(Convert.FromBase64String(ASC16Base64));
        //Canvas canvas;
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();

        [ManifestResourceStream(ResourceName = "CosmosKernel2.AudioCosmos.wav")] public static byte[] AudioCosmos;
        
        //private readonly Sys.Graphics.Bitmap bitmap = new Sys.Graphics.Bitmap(10, 10,
        //        new byte[] { 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
        //            255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
        //            0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
        //            0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255,
        //            23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0,
        //            255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 153, 57, 12, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
        //            243, 255, 0, 255, 243, 255, 153, 57, 12, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243,
        //            255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72, 72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
        //            255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72,
        //            72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
        //            10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
        //            243, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255,
        //            10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
        //            243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148,
        //            255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
        //            0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, }, ColorDepth.ColorDepth32);

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());
            //canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
            //canvas.Clear(Color.Blue);
            //canvas.Display();

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
            Console.WriteLine("mkfile nombre\t-Crea un archivo.");
            Console.WriteLine("mkdir nombre\t-Crea un directorio.");
            Console.WriteLine("rm archivo.txt\t-Elimina el archivo seleccionado");
            Console.WriteLine("rmdir nombre\t-Elimina el archivo seleccionado");
            Console.WriteLine("nano archivo \t-Sobreescribe un archivo existente.");
            Console.WriteLine("mv archivo.txt path\t\t-Mueve un archivo.");
            Console.WriteLine("rd archivo.txt\t-Visualiza los contenidos de un archivo.");
            Console.WriteLine("rdB archivo.txt\t-Lee todos los bytes de un archivo.");
            Console.WriteLine("sum num1 num2\t -Devuelve la suma de los dos numeros");
            Console.WriteLine("sub num1 num2\t -Devuelve la resta de los dos numeros");
            Console.WriteLine("mult num1 num2\t -Devuelve la multiplicacion entre los dos numeros");
            Console.WriteLine("div num1 num2\t -Devuelve la division entre los dos numeros");
            Console.WriteLine("pow num1 num2\t -Devuelve la potencia num1^num2");
            Console.WriteLine("sqrt num1\t -Devuelve la raiz cuadrada del numero");

            Console.WriteLine("music\t-Toca una cancion");
        }
        protected static void about()
        {
            Console.WriteLine("¿Qué es Moodeng?");
            Console.WriteLine("Moodeng es un sistema operativo open source. Un sistema operativo es el " +
                              "software que administra directamente el hardware y los recursos de un sistema, como la CPU, la " +
                              "memoria y el almacenamiento. El sistema operativo se encuentra entre las aplicaciones y " +
                              "el hardware y establece las conexiones entre todo el software y los recursos físicos que " +
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
        protected static void readFilesDir()
        {
            Console.WriteLine("Escribe el nombre de la carpeta que deseas explorar (por ejemplo, 'nombre_carpeta'):");
            string folderName = Console.ReadLine();

            string directoryPath = @"0:" + folderName;

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Error: La carpeta no existe - " + directoryPath);
                return;
            }

            var directoryList = Directory.GetFiles(directoryPath);

            if (directoryList.Length == 0)
            {
                Console.WriteLine("No hay archivos en la carpeta.");
                return;
            }

            try
            {
                foreach (var file in directoryList)
                {
                    var fileInfo = new FileInfo(file);
                    Console.WriteLine("Nombre del archivo: " + fileInfo.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        protected static void makeFile(string nombre)
        {
            try
            {
                if (File.Exists(nombre))
                {
                    Console.WriteLine("Ya existe el fichero " + nombre);
                }
                else
                {
                    var file_stream = File.Create(@"0:\" + nombre);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void makeDirectory(string nombre)
        {
            try
            {
                if (File.Exists(nombre))
                {
                    Console.WriteLine("Ya existe el directorio " + nombre);
                }
                else
                {
                    Directory.CreateDirectory(@"0:\"+nombre+"\\");
                }
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
                Directory.Delete(@"0:\"+nombreDir+"\\");
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
                File.Delete(@"0:\"+nombreFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void nano(string nombre)
        {
            string texto = "";
            Console.WriteLine("Introduce el texto que quieras escribir en el archivo");
            texto = Console.ReadLine();
            try
            {
                File.WriteAllText(@"0:\"+nombre,texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void moveFile()
        {
            try
            {
                Console.WriteLine("Escribe el nombre del fichero que deseas mover (ejemplo: 'testing.txt'):");
                string fileName = Console.ReadLine();

                // Construir la ruta completa del archivo
                string filePath = @"0:\" + fileName;

                Console.WriteLine("Escribe el nombre de la carpeta donde deseas mover el archivo (ejemplo: 'testdirectory'):");
                string folderName = Console.ReadLine();

                // Construir la nueva ruta usando la carpeta y el nombre del archivo original
                string newDirectoryPath = @"0:\" + folderName;
                string newFilePath = Path.Combine(newDirectoryPath, fileName);

                // Verificar si el archivo de origen existe
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: El archivo de origen no existe - " + filePath);
                    return;
                }

                // Verificar si el directorio de destino existe
                if (!Directory.Exists(newDirectoryPath))
                {
                    Console.WriteLine("Error: El directorio de destino no existe - " + newDirectoryPath);
                    return;
                }

                // Mover el archivo
                File.Copy(filePath, newFilePath, true);
                File.Delete(filePath);
                Console.WriteLine("Archivo movido de " + filePath + " a " + newFilePath);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Error de entrada/salida: " + ioEx.Message);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine("Error de permisos: " + uaEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        protected static void readFile()
        {
            try
            {
                Console.WriteLine("Escribe el nombre del fichero");
                string nombre = "";
                nombre = Console.ReadLine();
                Console.WriteLine(File.ReadAllText(@"0:\" + nombre));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        protected static void readAllBytes()
        {
            try
            {
                Console.WriteLine("Escribe el nombre del fichero");
                string nombre = Console.ReadLine();

                byte[] bytes = File.ReadAllBytes(@"0:\" + nombre);
                Console.WriteLine("Bytes del archivo:");
                foreach (byte b in bytes)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("Error: Archivo no encontrado - " + fnfEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
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
            else Console.Write((num1/num2).ToString("0.00") + "\n");
        }
        protected static double pow(double num1, double num2)
        {
            double resultado = num1;
            for (int i = 1; i<num2; i++)
            {
                resultado = resultado * num1;
            }
            return resultado;
        }
        protected static double sqrt(double num)
        {
            double resultado = 0;

            if (num == 0) resultado = 0;
            else if (num == 1) resultado = 1;
            else resultado = Math.Sqrt(num);

            return resultado;
        }
        protected override void Run()
        {
            string input = "";
            input = Console.ReadLine();
            string[] comandParts = input.Split(' ');
            var mixer = new AudioMixer();
            var audioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, AudioCosmos);
            var driver = AC97.Initialize(bufferSize: 4096);
            mixer.Streams.Add(audioStream);

            var audioManager = new AudioManager()
            {
                Stream = mixer,
                Output = driver
            };

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
                case "disktype":
                    var fs_type = fs.GetFileSystemType(@"0:\");
                    Console.WriteLine("Tipo de disco: " + fs_type);
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
                    readFilesDir();
                    break;
                case "mkfile":
                    makeFile(comandParts[1]);   break;
                case "mkdir":
                    makeDirectory(comandParts[1]);  break;
                case "rm": removeFile(comandParts[1]); break;
                case "rmdir": removeDirectory(comandParts[1]); break;
                case "nano": nano(comandParts[1]);   break;
                case "mv": moveFile(); break;
                case "rd": readFile(); break;
                case "rdb": readAllBytes(); break;
                case "sum": Console.WriteLine("Resultado: " + sumar(float.Parse(comandParts[1]),float.Parse(comandParts[2])).ToString("0.00") + "\n"); break;
                case "sub": Console.WriteLine("Resultado: " + restar(float.Parse(comandParts[1]),float.Parse(comandParts[2])).ToString("0.00") + "\n"); break;
                case "mult": Console.Write("Resultado: " + multiplicar(float.Parse(comandParts[1]), float.Parse(comandParts[2])).ToString("0.00") + "\n"); break;
                case "div": 
                    Console.WriteLine("Resultado: "); 
                    dividir(float.Parse(comandParts[1]), float.Parse(comandParts[2]));
                    break;
                case "pow": Console.Write("Resultado: " + pow(double.Parse(comandParts[1]), float.Parse(comandParts[2])).ToString("0.00") + "\n"); break;
                case "sqrt": Console.Write("Resultado: " + sqrt(double.Parse(comandParts[1])).ToString("0.00") + "\n"); break;
                case "music": audioManager.Enable();  break;
                default:
                    Console.WriteLine("Comando desconocido.");
                    break;
            }
        }
    }
}
