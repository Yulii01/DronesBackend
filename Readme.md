ApiDrones
Aquí se muestra una app para cumplir con los requisitos establecidos en el proyecto.Se utilizan sólo métodos de get y post y los datos se guardan en tablas independientes.

Requisitos para probar la api
Ejecute el archivo ejecutable.exe.Este dará una url que deberá copiarla para utilizar los métodos get y post en la app Postman.

Funcionalidades de la api
Para insertar un nuevo dron debe utilizarse la url api/Drones/agregar e introducir un JSON con los campos necesarios Para insertar un medicamento debe utilizarse la url api/Medicamentos/agregar e introducir un JSON con los campos necesarios Para insertar un Dron que fue cargado con algún medicamento debe utilizarse la url api/DronCargado/agregar e introducir un JSON con los campos necesarios tenga en cuenta que de no existir el medicamento o el dron previamente la api mostrará un error

Para mostrar todos los drones insertados utilizamos el método hey con la url api/Drones Para saber dado un dron su capacidad de batería utilizamos el método get con la url api/Drones/di

Para mostrar la carga que tiene un Dron específico usamos api/DronCargado/di Para mostrar los drones insertados que tiene posibilidad de ser cargados api/DronCargado
