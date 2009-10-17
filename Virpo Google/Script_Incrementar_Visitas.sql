--Chequear que la tabla a incrementar el campo visitas tenga el campo visitas, si no esta
--agregarlo (nombre del campo: visitas, tipo de dato: int).
--Cuando se reutilize este UPDATE, cambiar el nombre de la tabla, y no olvidarse el WHERE.
--Este UPDATE debe recibir por parámetro el valor del id a modificar, en este ejemplo 7.

UPDATE Proyecto SET visitas = visitas + 1 WHERE id = 7