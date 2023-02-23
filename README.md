# Murray

Este proyecto es un sistema cliente-servidor que utiliza C# como lenguaje de programación y SQL Server como gestor de bases de datos, y ha sido desarrollado a lo largo de las asignaturas de Base de Datos 1 y Base de Datos 2. 

Este proyecto es un sistema cliente-servidor desarrollado en C# y SQL Server que ha sido mejorado continuamente durante las asignaturas de Base de Datos 1 y Base de Datos 2. El sistema se ha estructurado modularmente para lograr una arquitectura más clara y organizada, y se ha separado en los siguientes módulos: Common, Connection, Models y Murray.

El módulo Common contiene funcionalidades que son comunes a todo el sistema, mientras que el módulo Connection se encarga de establecer la conexión con la base de datos. El módulo Models define los modelos de datos que se utilizan en el sistema, y el módulo Murray contiene la lógica de negocio específica del proyecto. La conexión a la base de datos también se realiza a través de procedimientos almacenados.

Además, el sistema cuenta con un Data Warehouse estructurado en el modelo de estrella, compuesto por las tablas DIMFECHA, DIMCLIENTE, DIMEMPLEADO, DIMPRODUCTO y FACTVENTASPRODUCTOS. El modelo de estrella es un tipo de diseño de Data Warehouse que utiliza una tabla de hechos central que se relaciona con varias tablas de dimensiones, lo que permite una fácil navegación y análisis de los datos.

Se han elaborado procedimientos almacenados para cada una de las tablas de la base de datos, incluyendo el CRUD de varias tablas, como Categoría, Compra, Contacto Jurídico, Departamento, Detalle de Compra, Detalle de Venta, Empleado, Garantías, Histórico de Producto, Municipio, Producto, Proveedor, Usuario y Venta.

Por último, el sistema cuenta con un Dashboard en Power BI que permite visualizar de forma interactiva la información del Data Warehouse. En resumen, el proyecto ha sido diseñado y mejorado de manera rigurosa y estructurada para lograr una alta calidad en la arquitectura, el manejo de datos y la interfaz de usuario.

=============================================================== Diagrama de la base de datos ==========================================================================
![image](https://user-images.githubusercontent.com/80351751/220812098-01eeca01-b820-447b-aed8-e346cc82c1ef.png)
=======================================================================================================================================================================

===========================================================Diagrama de la base de datos (Enfoque a las Compras) =======================================================
![image](https://user-images.githubusercontent.com/80351751/220812369-13a1dce9-b0ad-4f6a-89bf-5bd6272f213b.png)
=======================================================================================================================================================================

===========================================================Diagrama de la base de datos (Enfoque a los Contactos) =====================================================
![image](https://user-images.githubusercontent.com/80351751/220812423-fc361d32-2a4f-405f-b6fb-978e1bb459b8.png)
=======================================================================================================================================================================

===========================================================Diagrama de la base de datos (Enfoque al Inventario) =======================================================
![image](https://user-images.githubusercontent.com/80351751/220812527-3ff9f5f3-1d67-4300-8ee7-3ed315fa004c.png)
=======================================================================================================================================================================

===========================================================Diagrama de la base de datos (Enfoque a las Ventas) ========================================================
![image](https://user-images.githubusercontent.com/80351751/220812609-69bd5ca4-6b11-4e64-824b-9c1e1b48523e.png)
=======================================================================================================================================================================

===========================================================Diagrama de estrella del DataWarehouse =====================================================================
![image](https://user-images.githubusercontent.com/80351751/220812734-bf009129-fd05-4460-89ee-2ad3f86e5806.png)
=======================================================================================================================================================================

=======================================================Capturas de pantallas del Dashboard en Power BI=================================================================
![image](https://user-images.githubusercontent.com/80351751/220813123-3cb4ba1c-8d35-41b0-8c77-2b9596dd747e.png)

![image](https://user-images.githubusercontent.com/80351751/220813174-9167bd3b-c0ce-4af9-9215-d9d9210ad4ff.png)
=======================================================================================================================================================================

============================================================== Vistas de la aplicacion Desktop =======================================================================
Login de usuario
![image](https://user-images.githubusercontent.com/80351751/220813369-3ca2373d-05a5-4895-9807-414440b5412f.png)

Login usuario con datos ingresados y contraseña oculta
![image](https://user-images.githubusercontent.com/80351751/220813440-eab79cb5-6671-4747-b893-4e66bb0cf29d.png)

Interfaz de inicio
![image](https://user-images.githubusercontent.com/80351751/220813491-ad951b86-e976-4065-af32-dcc58777bc02.png)

Apartado de Contactos
![image](https://user-images.githubusercontent.com/80351751/220813519-34099bbb-873d-434d-abff-9c7578906917.png)

Apartado de Nuevo Contacto
![image](https://user-images.githubusercontent.com/80351751/220813553-d3f91571-f5ec-4d0e-b2f6-c13a05ac53a3.png)

Apartado de Edicion de Contacto
![image](https://user-images.githubusercontent.com/80351751/220813602-88072e9f-55e3-4b48-b7e6-378df3fee846.png)

Apartado de Ventas
![image](https://user-images.githubusercontent.com/80351751/220813613-02d22e42-7b63-494f-9855-83bc9c996ab7.png)

Apartado de Nueva Venta
![image](https://user-images.githubusercontent.com/80351751/220813701-68aa39b0-c35e-4fff-a3c9-b3e189cc24ee.png)

Modificacion de Venta
![image](https://user-images.githubusercontent.com/80351751/220813788-eef960fb-68ea-4a1d-bb4c-5b80cca6fe22.png)

Apartado de Compra
![image](https://user-images.githubusercontent.com/80351751/220813817-1f55ae05-abb6-4115-ac36-7ec48629ae61.png)

Nueva Compra
![image](https://user-images.githubusercontent.com/80351751/220813842-4f2ea356-4b52-44a4-8428-82bf07fddc45.png)

Modificacion de Compra
![image](https://user-images.githubusercontent.com/80351751/220813863-4f664dbf-6193-44a8-be83-456ac5841a4a.png)

Apartado de Productos
![image](https://user-images.githubusercontent.com/80351751/220813890-c3e7483f-8baa-4868-8d9d-446344bc92df.png)

Modificacion de Producto
![image](https://user-images.githubusercontent.com/80351751/220813915-83e73bb8-dbba-49ac-8425-82cabccb7d3d.png)

Nuevo producto
![image](https://user-images.githubusercontent.com/80351751/220813942-3e1bc2ab-9703-4746-be25-c11059d3a190.png)

Apartado de Usuarios
![image](https://user-images.githubusercontent.com/80351751/220813970-c956e15f-b45a-48e0-9d1a-222f5cedc0e6.png)

Modificacion de datos de Usuario
![image](https://user-images.githubusercontent.com/80351751/220814013-0d86db42-5fe2-4eae-9e7b-6e522efbcf7f.png)
=======================================================================================================================================================================
