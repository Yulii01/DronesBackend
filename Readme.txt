Para el fncionamiento correcto debe tener en cuenta lo siguiente

insertar un dron api/Drones/agregar

{
"numero_serie":"123por",
"Capacidad_Bateria":43,
"estado":"cargado"
"peso_limite":123,
"peso":"crucero"
}

insertear un medicamento api/Medicamentos/agregar

{
"Nombre":"Azitromicina",
"Codigo":"AZ12",
"Cantidad":98
}

insertar un Dron con un tipo de medicamento api/DronCargado/agregar

{
"IdDrone":"123por"
"MedicamentosID":"Azitromicina"
"Cantidad" : 50
}