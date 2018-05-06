# FrameworkPeruDemoVentas
Aplicación de prueba de evaluación de conocimientos para el proceso de postulación Framework Perú Mayo 2018

## Iniciando el proyecto

La siguiente aplicación de ejemplo simula una app sencilla de ventas, donde se puede crear clientes, productos y vincularlos con el registro de ventas

### Prerequisites

La aplicación fue desarrollada en Visual Studio 2017 Community Edition, la solución utiliza la versión de NetFramework 4.6.1.

### Ejecución del proyecto

Para ejecutar el proyecto es necesario realizar los siguientes pasos:

* Ejecutar el archivo FrameworkPeruDemoVentas.sln
* Verificar que los paquetes Nuget se haya restaurado, realizar un build de la app
* Abrir la Consola del Administrador de paquetes Nuget (Herramientas > Administrador de paquetes Nuget > Consola del administrador de paquetes)
* Se debe generar la base de datos, por defecto está conectado a localDB, para esto en la consola de Nuget digitar lo siguiente:
```
Update-Database
```
* Ahora podemos iniciar la aplicación, el usuario de acceso de prueba es admin / admin
* La aplicación utiliza una librería de diseño llamada MaterialSkin, en caso que deseen interactuar con sus componentes, será necesario agregar a la barra de herramientas los elementos de la dll ubicada en "\packages\MaterialSkin.Updated.0.2.2\lib\MaterialSkin.dll"

### Autor
* **Fabrizzio Chávez Tejada**
