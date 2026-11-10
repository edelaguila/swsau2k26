# Informes de Auditoría – Diseño de la referencia (DLL + Seguridad)

Esta versión **reemplaza exclusivamente el diseño del PDF** y añade un recurso visual genérico. Se conservan las consultas existentes, los DTO, las tres capas, el formulario y la conexión de `Capa_Modelo_Seguridad.dll`.

## Estructura

- `Capa_Modelo_Informe` → biblioteca DLL (SELECT, conexión desde Seguridad).
- `Capa_Controlador_Informe` → biblioteca DLL (DTO y procesamiento original).
- `Capa_Vista_Informe` → biblioteca DLL (formulario + `Cls_Pdf_Informe.cs`, QuestPDF).
- `Inicio_Informe` → EXE de pruebas (sin configuración de ODBC).
- `Dependencias/Capa_Modelo_Seguridad.dll` → **debes colocar tu DLL real** aquí; el ZIP no incluye dependencias privadas externas.

## Formato PDF

Basado en `Javier Cruz Informe-RiskoMC-04.pdf`:
1. **Portada** sin membrete, con proyecto, informe, auditor y fecha provenientes de la base.
2. **Índice** con números de página dinámicos y vínculos.
3. **Membrete interior** en una tabla con cuatro bloques, logo a la izquierda, título, código, fecha, versión y número de página.
4. **Checklist** con cabecera turquesa, filas azules y X cuando `Entregado = 1`.
5. **Primera revisión**, encabezados y bullets para aspectos positivos, correcciones y sugerencias; imágenes cuando sus rutas son accesibles.
6. **Resultados**, con tabla de esperado/alcanzado y gráfica de líneas generada desde `tbl_tabla_ponderacion` (peso esperado vs. calificación ponderada).
7. **Gráficas registradas**: conserva el contenido JSON que ya mostraba el proyecto original, sin interpretar formatos JSON que no están definidos.
8. **Firmas** con ELABORÓ (auditor y fecha registrados) y filas REVISÓ / APROBÓ vacías.

## Diferencias conscientes con la referencia

- El logo **RISKO** pertenece al documento de referencia, no a tu proyecto. El archivo `Capa_Vista_Informe/Assets/Logo_Informe.png` es un logo **genérico editable**. Si deseas el logo de tu institución, reemplázalo por otro PNG con el mismo nombre.
- El código se construye desde el identificador real (`INF-000123`); **no se atribuye** `MC-04` a informes que no poseen ese código.
- La tabla `tbl_informe` no registra una versión documental; se imprime `—` en ese campo.
- No existen firmas digitales de revisión o aprobación en los datos consultados, por lo que esas celdas permanecen vacías.
- El número de páginas es automático y depende de los registros e imágenes disponibles; no se fuerza un documento de exactamente 11 páginas.
- Las ponderaciones están vinculadas al proyecto, como en la consulta original; el gráfico utiliza únicamente los valores guardados y no calcula notas adicionales.

## Instalación

1. Abre `InformeAuditoriaMVC.sln` en Visual Studio 2022 con .NET 8.
2. Coloca **tu propia** `Capa_Modelo_Seguridad.dll` en `Dependencias/`. Debe ser compatible con .NET 8 y con el contrato `Capa_Modelo_Seguridad.Cls_Conexion.AbrirConexion()`.
3. Compila y restaura los NuGet `System.Data.Odbc` y `QuestPDF`.
4. Establece `Inicio_Informe` como proyecto de inicio, ejecuta y selecciona un informe.
5. Genera el PDF. Para un logo personalizado, copia el PNG a `Assets/Logo_Informe.png` en el directorio de salida del ejecutable.

### Si ya tienes el proyecto funcionando

Puedes cambiar **solo** `Capa_Vista_Informe/Cls_Pdf_Informe.cs`, y copiar el PNG a `Assets/Logo_Informe.png`. El resto de archivos son idénticos a la edición anterior salvo la inclusión/copia del recurso en `Capa_Vista_Informe.csproj`.

## Cambios exactos de esta versión

- `Capa_Vista_Informe/Cls_Pdf_Informe.cs`: reconstruido el diseño del PDF; sin cambios en el contrato público `Generar(Cls_Informe_DTO datos, string destino)`.
- `Capa_Vista_Informe/Capa_Vista_Informe.csproj`: añadido PNG del logo como contenido a copiar en salida.
- `Capa_Vista_Informe/Assets/Logo_Informe.png`: recurso nuevo de ejemplo, reemplazable.
- `README.md`: actualizadas instrucciones.

**Limitación de validación:** este entorno no tiene compilador .NET para Windows ni tu DLL de Seguridad. El código está basado en las APIs documentadas de QuestPDF 2026.9.1 pero debes compilarlo y generar un PDF con tu instalación para verificar el aspecto final.


## Corrección de maquetación (Checklist, QuestPDF)

Se corrigió `Capa_Vista_Informe/Cls_Pdf_Informe.cs` para evitar
`The provided document content contains conflicting size constraints` al
construir la sección de checklist (línea ~115 en la versión anterior).

Antes: una única tabla completa como elemento de la columna principal.
Ahora: una `Decoration` con cabecera turquesa repetible y una `Column` de filas
`Row` independientes, de modo que una lista de actividades larga pueda seguir
en la página siguiente. Mantiene numeración, columna Aspecto, marca X,
colores y fuente Lato. No trunca ni elimina actividades.

La corrección **no modifica la DLL de Seguridad, consultas, DTO, controladores,
formularios ni datos**. Si quieres actualizar tu instalación actual, reemplaza
solo `Capa_Vista_Informe/Cls_Pdf_Informe.cs` y recompila.

Nota: compilación y prueba de impresión final se realizan en Visual Studio
Windows con tu DLL de Seguridad; no disponible en este entorno.
