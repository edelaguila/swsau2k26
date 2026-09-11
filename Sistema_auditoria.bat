:: ============================================================================
:: BUILD GLOBAL - SISTEMA AUDITORIA - VISUAL STUDIO 2019 o 2022 (a elegir)
:: ORDEN DE COMPILACION:
::   1) Componente Consultas Simples
::   2) Componente Consultas
::   3) Reporteador
::   4) Navegador
::   5) Seguridad
:: ============================================================================
::
:: QUE HACE ESTE SCRIPT:
:: 1. Pregunta si quieres compilar con Visual Studio 2019 o 2022, y usa el
::    MSBuild correspondiente para compilar los proyectos C#.
:: 2. Compila cada componente en el orden solicitado, capa por capa
::    (Modelo -> Controlador -> Vista) usando /t:Rebuild /p:Configuration=Debug.
:: 3. Copia las DLLs generadas de Debug a Release para que los componentes
::    queden disponibles como referencias para el resto del sistema.
:: 4. Verifica que existan las DLLs finales de cada componente.
:: 5. Guarda toda la salida de MSBuild en logs\build_log.txt.
::
:: PARA USARLO CON OTRO PROYECTO, NORMALMENTE SOLO DEBES CAMBIAR:
::   MSBUILD_PATH    -> Si tu Visual Studio 2019/2022 no es Community o esta en otra ruta.
::   COMPONENTES_DIR -> Carpeta donde estan los componentes (se calcula sola abajo).
::
:: IMPORTANTE:
:: Las rutas que contienen espacios siempre deben ir entre comillas.
::
:: VENTANA QUE NO SE CIERRA:
:: Al hacer doble clic, Windows abre una ventana "cmd /c" que se cierra sola
:: en cuanto el script termina (o si falla antes de llegar al menu final).
:: Para evitarlo, este .bat se relanza a si mismo dentro de una ventana
:: "cmd /k", la cual NUNCA se cierra sola (ni aunque el script truene a la
:: mitad). Asi puedes leer con calma toda la salida de la compilacion y
:: cerrarla tu mismo cuando termines (escribiendo "exit" o con la X).
:: ============================================================================

@echo off
if /I not "%~1"=="RUNNING" (
    start "Compilacion Sistema Auditoria" cmd /k ""%~f0"" RUNNING
    exit /b
)

:INICIO
setlocal enabledelayedexpansion
color 0A

echo ============================================
echo COMPILACION SISTEMA AUDITORIA
echo ============================================
echo.
echo Selecciona la version de Visual Studio para compilar:
echo   [1] Visual Studio 2019
echo   [2] Visual Studio 2022
echo.

choice /c 12 /n /m "Version (1/2): "
set "VS_CHOICE=%errorlevel%"

:: --------------------------------------------------------------------------
:: 1) RUTA DE MSBUILD SEGUN LA VERSION ELEGIDA
:: --------------------------------------------------------------------------
:: IMPORTANTE: estas dos rutas tienen parentesis ("Program Files (x86)")
:: o podrian tenerlos en otra instalacion. Por eso los "set" van en lineas
:: sueltas, SIN meterlos dentro de un bloque if(...) multilinea: cmd.exe
:: cuenta mal los parentesis de una ruta cuando estan dentro de un bloque
:: de varias lineas, y el script se rompe con un error como
:: "No se esperaba \Microsoft en este momento."
:: --------------------------------------------------------------------------
set "VS_LABEL=2019"
if "%VS_CHOICE%"=="2" set "VS_LABEL=2022"

set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
if "%VS_CHOICE%"=="2" set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"

echo.
echo ============================================
echo COMPILANDO CON VISUAL STUDIO !VS_LABEL!
echo ============================================

if not exist "!MSBUILD_PATH!" (
    echo.
    echo [ERROR] No se encontro MSBuild de Visual Studio !VS_LABEL! en:
    echo   !MSBUILD_PATH!
    echo Si tienes Professional o Enterprise en vez de Community, o esta en
    echo otra ruta, corrige la linea "set MSBUILD_PATH" correspondiente arriba.
    echo.
    pause
    exit /b 1
)

:: --------------------------------------------------------------------------
:: 2) CARPETA DE COMPONENTES DEL PROYECTO
:: --------------------------------------------------------------------------
:: %~dp0 obtiene automaticamente la carpeta donde esta guardado este .bat
:: (la raiz del proyecto swsau2k26). Los componentes viven en codigo\componentes.
:: --------------------------------------------------------------------------
set "ROOT_DIR=%~dp0"
set "COMPONENTES_DIR=%ROOT_DIR%codigo\componentes"

cd /d "%ROOT_DIR%"
if not exist "logs" mkdir logs

:: Log limpio en cada corrida
echo ============================================ > logs\build_log.txt
echo COMPILACION INICIADA: %DATE% %TIME% >> logs\build_log.txt
echo ============================================ >> logs\build_log.txt

:: ==========================================================
:: CICLO DE COMPILACION EN EL ORDEN SOLICITADO
:: ==========================================================
echo.
echo ============================================
echo INICIANDO COMPILACION EN ORDEN
echo ============================================

:: --------------------------------------------------------------------------
:: NOTA: el codigo de cada componente va DIRECTO aqui (sin "call :Etiqueta").
:: cmd.exe tiene un bug conocido donde la PRIMERA vez que se llama una
:: etiqueta definida al final del archivo, a veces no la encuentra
:: ("El sistema no encuentra la etiqueta por lotes especificada"), aunque
:: las llamadas siguientes si funcionen. Poniendo el codigo en linea se
:: elimina ese riesgo por completo.
:: --------------------------------------------------------------------------

echo ============================================
echo COMPILANDO COMPONENTE: Consultas Simples
echo ============================================

for %%p in ("!COMPONENTES_DIR!\consultas\ComponenteConsultasSimples\Capa_Modelo_Componente_Consultas\*.csproj") do (
    "!MSBUILD_PATH!" "%%~fp" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
)

for %%p in ("!COMPONENTES_DIR!\consultas\ComponenteConsultasSimples\Capa_Controlador_Componente_Consultas\*.csproj") do (
    "!MSBUILD_PATH!" "%%~fp" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
)

for /d %%d in ("!COMPONENTES_DIR!\consultas\ComponenteConsultasSimples\Capa_Vista_Componente_Consultas_*") do (
    for %%p in ("%%~fd\*.csproj") do (
        "!MSBUILD_PATH!" "%%~fp" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
    )
)

echo ============================================
echo COMPILANDO COMPONENTE: Consultas
echo ============================================

for %%p in ("!COMPONENTES_DIR!\consultas\Componente_Consultas\Capa_Modelo_Componente_Consultas\*.csproj") do (
    "!MSBUILD_PATH!" "%%~fp" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
)

for %%p in ("!COMPONENTES_DIR!\consultas\Componente_Consultas\Capa_Controlador_Componente_Consultas\*.csproj") do (
    "!MSBUILD_PATH!" "%%~fp" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
)

for %%p in ("!COMPONENTES_DIR!\consultas\Componente_Consultas\Capa_Vista_Componente_Consultas\*.csproj") do (
    "!MSBUILD_PATH!" "%%~fp" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
)

echo ============================================
echo COMPILANDO COMPONENTE: Reporteador
echo ============================================

"!MSBUILD_PATH!" "!COMPONENTES_DIR!\reporteador\reporteador\Capa_Modelo_Reporteador\Capa_Modelo_Reporteador.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
"!MSBUILD_PATH!" "!COMPONENTES_DIR!\reporteador\reporteador\Capa_Controlador_Reporteador\Capa_Controlador_Reporteador.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
"!MSBUILD_PATH!" "!COMPONENTES_DIR!\reporteador\reporteador\Capa_Vista_Reporteador\Capa_Vista_Reporteador.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1

echo ============================================
echo COMPILANDO COMPONENTE: Navegador
echo ============================================

"!MSBUILD_PATH!" "!COMPONENTES_DIR!\navegador\NavegadorMVC\CapaModeloNavegador\Capa_Modelo_Navegador.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
"!MSBUILD_PATH!" "!COMPONENTES_DIR!\navegador\NavegadorMVC\CapaControladorNavegador\Capa_Controlador_Navegador.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
"!MSBUILD_PATH!" "!COMPONENTES_DIR!\navegador\NavegadorMVC\CapaVistaNavegador\Capa_Vista_Navegador.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1

echo ============================================
echo COMPILANDO COMPONENTE: Seguridad
echo ============================================

"!MSBUILD_PATH!" "!COMPONENTES_DIR!\seguridad\SeguridadMVC\SeguridadMVC\CapaModelo\Capa_Modelo_Seguridad.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
"!MSBUILD_PATH!" "!COMPONENTES_DIR!\seguridad\SeguridadMVC\SeguridadMVC\CapaControlador\Capa_Controlador_Seguridad.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1
"!MSBUILD_PATH!" "!COMPONENTES_DIR!\seguridad\SeguridadMVC\SeguridadMVC\CapaVista\Capa_Vista_Seguridad.csproj" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1

echo.
echo ============================================
echo COMPILACION DE COMPONENTES FINALIZADA
echo ============================================


:: ==========================================================
:: COPIAR DLLs DE COMPONENTES (Debug -> Release)
:: ==========================================================
echo.
echo ============================================
echo COPIANDO DLLs DE DEBUG A RELEASE
echo ============================================

for /r "!COMPONENTES_DIR!" %%d in (*.dll) do (
    if exist "%%d" (
        if not exist "%%~dpd..\Release" mkdir "%%~dpd..\Release"
        copy /Y "%%d" "%%~dpd..\Release\" >nul
    )
)

echo DLLs copiadas correctamente.


:: ==========================================================
:: VERIFICAR DLLs DE CADA COMPONENTE
:: ==========================================================
echo.
echo ============================================
echo VERIFICANDO DLLs DE COMPONENTE CONSULTAS SIMPLES
echo ============================================

if exist "!COMPONENTES_DIR!\consultas\ComponenteConsultasSimples\Capa_Modelo_Componente_Consultas\bin\Debug\*.dll" (
    echo [OK] ComponenteConsultasSimples - Capa Modelo
) else (
    echo [FALTA] ComponenteConsultasSimples - Capa Modelo
)

if exist "!COMPONENTES_DIR!\consultas\ComponenteConsultasSimples\Capa_Controlador_Componente_Consultas\bin\Debug\*.dll" (
    echo [OK] ComponenteConsultasSimples - Capa Controlador
) else (
    echo [FALTA] ComponenteConsultasSimples - Capa Controlador
)

if exist "!COMPONENTES_DIR!\consultas\ComponenteConsultasSimples\Capa_Vista_Componente_Consultas_simples\bin\Debug\*.dll" (
    echo [OK] ComponenteConsultasSimples - Capa Vista
) else (
    echo [FALTA] ComponenteConsultasSimples - Capa Vista
)

echo.
echo ============================================
echo VERIFICANDO DLLs DE COMPONENTE CONSULTAS
echo ============================================

if exist "!COMPONENTES_DIR!\consultas\Componente_Consultas\Capa_Modelo_Componente_Consultas\bin\Debug\*.dll" (
    echo [OK] Componente_Consultas - Capa Modelo
) else (
    echo [FALTA] Componente_Consultas - Capa Modelo
)

if exist "!COMPONENTES_DIR!\consultas\Componente_Consultas\Capa_Controlador_Componente_Consultas\bin\Debug\*.dll" (
    echo [OK] Componente_Consultas - Capa Controlador
) else (
    echo [FALTA] Componente_Consultas - Capa Controlador
)

if exist "!COMPONENTES_DIR!\consultas\Componente_Consultas\Capa_Vista_Componente_Consultas\bin\Debug\*.dll" (
    echo [OK] Componente_Consultas - Capa Vista
) else (
    echo [FALTA] Componente_Consultas - Capa Vista
)

echo.
echo ============================================
echo VERIFICANDO DLLs DE REPORTEADOR
echo ============================================

if exist "!COMPONENTES_DIR!\reporteador\reporteador\Capa_Modelo_Reporteador\bin\Debug\Capa_Modelo_Reporteador.dll" (
    echo [OK] Reporteador - Capa Modelo
) else (
    echo [FALTA] Reporteador - Capa Modelo
)

if exist "!COMPONENTES_DIR!\reporteador\reporteador\Capa_Controlador_Reporteador\bin\Debug\Capa_Controlador_Reporteador.dll" (
    echo [OK] Reporteador - Capa Controlador
) else (
    echo [FALTA] Reporteador - Capa Controlador
)

if exist "!COMPONENTES_DIR!\reporteador\reporteador\Capa_Vista_Reporteador\bin\Debug\Capa_Vista_Reporteador.dll" (
    echo [OK] Reporteador - Capa Vista
) else (
    echo [FALTA] Reporteador - Capa Vista
)

echo.
echo ============================================
echo VERIFICANDO DLLs DE NAVEGADOR
echo ============================================

if exist "!COMPONENTES_DIR!\navegador\NavegadorMVC\CapaModeloNavegador\bin\Debug\Capa_Modelo_Navegador.dll" (
    echo [OK] Navegador - Capa Modelo
) else (
    echo [FALTA] Navegador - Capa Modelo
)

if exist "!COMPONENTES_DIR!\navegador\NavegadorMVC\CapaControladorNavegador\bin\Debug\Capa_Controlador_Navegador.dll" (
    echo [OK] Navegador - Capa Controlador
) else (
    echo [FALTA] Navegador - Capa Controlador
)

if exist "!COMPONENTES_DIR!\navegador\NavegadorMVC\CapaVistaNavegador\bin\Debug\Capa_Vista_Navegador.dll" (
    echo [OK] Navegador - Capa Vista
) else (
    echo [FALTA] Navegador - Capa Vista
)

echo.
echo ============================================
echo VERIFICANDO DLLs DE SEGURIDAD
echo ============================================

if exist "!COMPONENTES_DIR!\seguridad\SeguridadMVC\SeguridadMVC\CapaModelo\bin\Debug\Capa_Modelo_Seguridad.dll" (
    echo [OK] Seguridad - Capa Modelo
) else (
    echo [FALTA] Seguridad - Capa Modelo
)

if exist "!COMPONENTES_DIR!\seguridad\SeguridadMVC\SeguridadMVC\CapaControlador\bin\Debug\Capa_Controlador_Seguridad.dll" (
    echo [OK] Seguridad - Capa Controlador
) else (
    echo [FALTA] Seguridad - Capa Controlador
)

if exist "!COMPONENTES_DIR!\seguridad\SeguridadMVC\SeguridadMVC\CapaVista\bin\Debug\Capa_Vista_Seguridad.dll" (
    echo [OK] Seguridad - Capa Vista
) else (
    echo [FALTA] Seguridad - Capa Vista
)

echo.
echo ============================================
echo COMPILACION FINALIZADA COMPLETAMENTE
echo Log detallado en: logs\build_log.txt
echo ============================================
echo.
echo ============================================
echo Presiona una opcion:
echo [R] Recompilar
echo [S] Salir
echo ============================================

choice /c RS /n /m "Seleccion: "

if errorlevel 2 goto FIN
if errorlevel 1 goto INICIO

:FIN
echo.
echo La ventana se queda abierta. Escribe "exit" o cierrala con la X cuando termines de revisar el log.
exit /b 0