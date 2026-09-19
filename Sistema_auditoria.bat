:: ============================================================================
:: BUILD GLOBAL - SISTEMA AUDITORIA - VISUAL STUDIO 2019 o 2022 (a elegir)
::
:: BUSQUEDA AUTOMATICA DE PROYECTOS:
:: Este script YA NO tiene una lista fija de componentes escrita a mano.
:: Busca TODOS los archivos .csproj dentro de la carpeta "codigo" y todas
:: sus subcarpetas, sin importar el nombre que le pongas. Ejemplo: si creas
:: una carpeta nueva "Ventas" dentro de "codigo" con sus propias capas
:: Modelo/Controlador/Vista, y esa Vista referencia Capa_Vista_Seguridad y
:: Capa_Vista_Auditoria, este script la va a encontrar y compilar sola, en
:: el orden correcto, la proxima vez que lo corras. No hay que editar nada
:: aqui cuando agregues un componente nuevo.
::
:: COMO RESUELVE EL ORDEN SIN CONOCER LAS DEPENDENCIAS DE ANTEMANO:
:: En vez de adivinar que proyecto depende de cual, el script intenta
:: compilar TODOS los .csproj pendientes en una "pasada". Los que fallen
:: porque todavia les falta la DLL de otro proyecto quedan "pendientes"
:: para la siguiente pasada. Despues de cada pasada se copian las DLLs
:: nuevas (Debug -> Release) por si algun proyecto las busca ahi. Esto se
:: repite (hasta 8 veces) hasta que ya no quede nada pendiente, o hasta que
:: una pasada completa no logre compilar nada nuevo (eso ya seria un error
:: real -referencia rota, typo, etc- y se reporta al final con su ruta para
:: que revises logs\build_log.txt).
::
:: PROYECTOS "MUERTOS" O DE PRUEBA:
:: Si tienes algun .csproj viejo que ya no usas y falla al compilar, no
:: rompe nada mas: cada proyecto se intenta de forma independiente. Solo
:: apareceria como [FALTA] al final. Si quieres, puedes borrarlo o moverlo
:: fuera de "codigo" para que ni se intente.
::
:: VENTANA QUE NO SE CIERRA:
:: Al hacer doble clic, Windows abre una ventana "cmd /c" que se cierra sola
:: en cuanto el script termina (o si falla antes de llegar al menu final).
:: Para evitarlo, este .bat se relanza a si mismo dentro de una ventana
:: "cmd /k", la cual NUNCA se cierra sola. Asi puedes leer con calma toda la
:: salida de la compilacion y cerrarla tu mismo (escribiendo "exit" o con la X).
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
echo COMPILACION SISTEMA AUDITORIA (AUTO-DESCUBRIMIENTO)
echo ============================================
echo.
echo Selecciona la version de Visual Studio para compilar:
echo   [1] Visual Studio 2019
echo   [2] Visual Studio 2022
echo.

choice /c 12 /n /m "Version (1/2): "
set "VS_CHOICE=%errorlevel%"

:: --------------------------------------------------------------------------
:: RUTA DE MSBUILD SEGUN LA VERSION ELEGIDA
:: --------------------------------------------------------------------------
:: IMPORTANTE: estas rutas tienen parentesis ("Program Files (x86)"). Por
:: eso los "set" van en lineas sueltas, fuera de cualquier bloque if(...)
:: multilinea: cmd.exe cuenta mal los parentesis de una ruta cuando estan
:: dentro de un bloque de varias lineas.
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

set "ROOT_DIR=%~dp0"
set "CODIGO_DIR=%ROOT_DIR%codigo"

cd /d "%ROOT_DIR%"
if not exist "logs" mkdir logs

echo ============================================ > logs\build_log.txt
echo COMPILACION INICIADA: %DATE% %TIME% >> logs\build_log.txt
echo ============================================ >> logs\build_log.txt

if not exist "!CODIGO_DIR!" (
    echo.
    echo [ERROR] No se encontro la carpeta de codigo en: !CODIGO_DIR!
    pause
    exit /b 1
)

:: --------------------------------------------------------------------------
:: 1) BUSCAR TODOS LOS .csproj DENTRO DE "codigo" (cualquier carpeta nueva
::    que crees, con cualquier nombre, se incluye automaticamente aqui).
:: --------------------------------------------------------------------------
echo.
echo ============================================
echo BUSCANDO PROYECTOS (.csproj) EN codigo\...
echo ============================================

if exist "logs\pendientes.txt" del /f /q "logs\pendientes.txt"
if exist "logs\pendientes_nuevo.txt" del /f /q "logs\pendientes_nuevo.txt"
if exist "logs\ok.txt" del /f /q "logs\ok.txt"

dir /s /b /a-d "!CODIGO_DIR!\*.csproj" > "logs\pendientes.txt" 2>nul

set /a TOTAL_PROYECTOS=0
for /f "usebackq delims=" %%c in ("logs\pendientes.txt") do set /a TOTAL_PROYECTOS+=1

echo Proyectos encontrados: !TOTAL_PROYECTOS!
echo Proyectos encontrados: !TOTAL_PROYECTOS! >> logs\build_log.txt

if !TOTAL_PROYECTOS! EQU 0 (
    echo.
    echo [ERROR] No se encontro ningun .csproj dentro de !CODIGO_DIR!
    pause
    exit /b 1
)

:: --------------------------------------------------------------------------
:: 2) COMPILAR EN "PASADAS" HASTA QUE NO QUEDEN PENDIENTES
:: --------------------------------------------------------------------------
set /a MAX_PASADAS=8
set /a PASADA=0

:PASADA_LOOP
set /a PASADA+=1
set /a COMPILADOS_EN_PASADA=0
set /a PENDIENTES_EN_PASADA=0

echo.
echo ============================================
echo PASADA !PASADA! DE COMPILACION
echo ============================================

if exist "logs\pendientes_nuevo.txt" del /f /q "logs\pendientes_nuevo.txt"

for /f "usebackq delims=" %%p in ("logs\pendientes.txt") do (
    set "PROYECTO=%%p"
    set "ES_SDK=NO"
    findstr /I /C:"Microsoft.NET.Sdk" "!PROYECTO!" >nul 2>&1
    if !errorlevel! EQU 0 set "ES_SDK=SI"

    echo. >> logs\build_log.txt
    echo -------------------------------------------- >> logs\build_log.txt
    echo PASADA !PASADA! - Compilando: !PROYECTO! >> logs\build_log.txt
    echo -------------------------------------------- >> logs\build_log.txt

    if "!ES_SDK!"=="SI" (
        "!MSBUILD_PATH!" "!PROYECTO!" /t:Restore /p:Configuration=Debug >> logs\build_log.txt 2>&1
    )

    "!MSBUILD_PATH!" "!PROYECTO!" /t:Rebuild /p:Configuration=Debug >> logs\build_log.txt 2>&1

    if !errorlevel! EQU 0 (
        echo   [OK] !PROYECTO!
        echo !PROYECTO! >> logs\ok.txt
        set /a COMPILADOS_EN_PASADA+=1
    ) else (
        echo   [pendiente] !PROYECTO!
        echo !PROYECTO! >> logs\pendientes_nuevo.txt
        set /a PENDIENTES_EN_PASADA+=1
    )
)

:: Reflejar DLLs nuevas de Debug a Release antes de la siguiente pasada,
:: por si algun proyecto busca la referencia en la carpeta Release.
for /r "!CODIGO_DIR!" %%d in (*.dll) do (
    if exist "%%d" (
        if not exist "%%~dpd..\Release" mkdir "%%~dpd..\Release" >nul 2>&1
        copy /Y "%%d" "%%~dpd..\Release\" >nul 2>&1
    )
)

echo.
echo Pasada !PASADA!: !COMPILADOS_EN_PASADA! compilados, !PENDIENTES_EN_PASADA! pendientes.

if exist "logs\pendientes_nuevo.txt" (
    move /y "logs\pendientes_nuevo.txt" "logs\pendientes.txt" >nul
) else (
    if exist "logs\pendientes.txt" del /f /q "logs\pendientes.txt"
)

if !PENDIENTES_EN_PASADA! EQU 0 goto PASADAS_FIN
if !COMPILADOS_EN_PASADA! EQU 0 goto PASADAS_FIN
if !PASADA! GEQ !MAX_PASADAS! goto PASADAS_FIN
goto PASADA_LOOP

:PASADAS_FIN

echo.
echo ============================================
echo COMPILACION FINALIZADA TRAS !PASADA! PASADA-S
echo ============================================

:: ==========================================================
:: RESUMEN FINAL - lo que SI compilo y lo que quedo pendiente
:: ==========================================================
echo.
echo ============================================
echo RESUMEN FINAL DE COMPILACION
echo ============================================
echo.

if exist "logs\ok.txt" (
    for /f "usebackq delims=" %%o in ("logs\ok.txt") do echo [OK] %%o
)

echo.

if exist "logs\pendientes.txt" (
    echo Los siguientes proyectos NO se lograron compilar:
    echo.
    for /f "usebackq delims=" %%f in ("logs\pendientes.txt") do echo [FALTA] %%f
    echo.
    echo Revisa logs\build_log.txt para ver el error exacto de cada uno.
) else (
    echo Todos los proyectos encontrados en codigo\ se compilaron correctamente.
)

echo.
echo ============================================
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