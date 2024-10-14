# Creación de un sistema operativo con Cosmos  
**En este repositorio podrás ver y aprender cómo crear tu propio sistema operativo utilizando Cosmos, entre otras aplicaciónes.**  
## Índice
1. Preparación del Entorno
 - 1.1 Instalación de los elementos necesarios
    - 1.1.1 Visual Studio 2022
    - 1.1.2 SDK de NET6.0
    - 1.1.3 Cosmos
    - 1.1.4 VMware Workstation Pro 17.6.0
      - 1.1.4.1 Instalación
      - 1.1.4.2 Resolución de errores
        - 1.1.4.2.1 Primera solución
        - 1.1.4.2.2 Segunda solución
        - 1.1.4.2.3 Tercera solucion
 - 1.2 Confirmación de la correcta instalación de los programas
  
## 1. Instalación de los elementos necesarios 
### 1.1 Visual Studio 2022  
Primero descargaremos Visual Studio 2022, asegurandonos de agregar las siguientes 2 cargas de trabajo para poder trabajar con **Cosmos**.  
  
![Imagen de las cargas de trabajo de Visual Studio 2022](https://github.com/user-attachments/assets/a5fb8d04-524d-4510-b916-25ac2fafd131)

Posteriormente añadiremos el componente individual **"NET 6.0 Runtime (Compatibilidad a largo plazo)"**.  
  
![Imagen de el componente individual](https://github.com/user-attachments/assets/6669a779-2fdc-48c4-9730-a9105fa04024)

### 1.2 SDK de NET6.0
A continuación, descargaremos el **SDK** de NET 6.0.  
[Link de descarga de SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)  

### 1.3 Cosmos  
Seguiremos con la instalación del mismo Cosmos, el cual descargaremos desde la página de GitHub oficial de Cosmos.  
[Link de GitHub de Cosmos](https://github.com/CosmosOS/Cosmos)  

Una vez en el GitHub de Cosmos descargaremos la última version de Cosmos y la descomprimiremos en el escritorio.  

![Descarga Cosmos](https://github.com/user-attachments/assets/0d45c25e-3d0d-46e2-b803-4f849d1d343f)  

Una vez descomprimido el fichero, instalaremos las extensiones del Visual Studio, instalando todo lo que nos proponga.  

![Extensiones Visual Studio](https://github.com/user-attachments/assets/ec3bf217-044a-4a96-9fe5-e0015328e04f)  

### 1.4 VMware Workstation Pro 17.6.0
### 1.4.1 Instalación
Finalmente, descargaremos VMware Workstation Pro 17.6.0. Programa que usaremos para virtualizar nuestro sistema operativo.  
[Link de descarga VMware](https://blogs.vmware.com/workstation/2024/05/vmware-workstation-pro-now-available-free-for-personal-use.html)  

> [!CAUTION]
> Es posible que al instalar VMware hayan errores. En el siguiente apartado habrán indicaciones para solucionar estos errores.

### 1.4.2 Resolución de errores  
> [!NOTE]
> En caso de no haber tenido ningún problema al instalar y ejecutar el programa, puede omitir este apartado.
  
![Error instalacion VMware](https://github.com/user-attachments/assets/60df2018-c099-494b-b2e5-699c5bfa9eff)

En caso de que nos salte un error al final de la instalación del programa, podemos intentar varias soluciones.  
#### 1.4.2.1 Primera solución  
La primera medida que podemos probar es simplemente ejecutar el instalador como administrador y seguir el mismo proceso.  
#### 1.4.2.2 Segunda solución
En caso de que el problema persista, abriremos una consola de Windows como administradores y ejecutaremos la siguiente línea de código:
```
net localgroup /add "Users"
```  
Si se ha insertado el comando de manera correcta, la consola debería responder con "Se ha completado el comando correctamente."  
#### 1.4.2.3 Tercera solución
En caso de que el problema aún persista, ejecutaremos los siguientes comandos como administrador en la consola de Windows:
```
net localgroup /add "Authenticated Users"
```      
```
net localgroup /add "Administrators"
```   
Si se ha ejecutado de forma correcta los comandos, la consola debería responder con "Se ha completado el comando correctamente." despues de ambos comandos.  
### 1.2 Confirmación de la correcta instalación de los programas
Si hemos seguido los pasos correctamente, al abrir Visual Studio deberíamos de poder crear un proyecto de Cosmos sin ningún problema.

![Proyecto Cosmos](https://github.com/user-attachments/assets/19e7a32f-a5f2-4e32-8ceb-73a9f68469d2)

Una vez creado el proyecto, solamente tenemos que ejecutar el programa. Al hacerlo, deberia abrirse VMware con nuestro sistema operativo.   
![Proyecto funcionando](https://github.com/user-attachments/assets/67cf54de-02a8-4001-baed-8519b0ddbc51)   
# Todo listo!
