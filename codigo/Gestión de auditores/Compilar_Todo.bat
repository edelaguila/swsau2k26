:: ============================================================================
:: BUILD GLOBAL - COMPILA TODOS LOS PROYECTOS C# DE swsau2k26\codigo
::
:: COMO USARLO:
:: Doble clic en este archivo, desde cualquier lugar. Elige VS 2019 o 2022.
::
:: COMO ENCUENTRA LA CARPETA (funciona en la PC de cualquier usuario):
::  1) Si este .bat esta junto a la carpeta "codigo", usa esa.
::  2) Si el .bat esta DENTRO de una carpeta con proyectos (por ejemplo
::     "Gestion de auditores"), compila los .csproj de esa carpeta.
::  3) Si no, prueba C:\swsau2k26\codigo
::  4) Si no, prueba Documentos, Escritorio, Descargas y source\repos del
::     usuario que lo ejecuta (tambien las versiones dentro de OneDrive).
::  5) Si no, busca la carpeta swsau2k26 en TODO el disco C: (puede tardar).
::
:: Si tu carpeta raiz se llama distinto, cambia NOMBRE_RAIZ aqui abajo.
::
:: QUE HACE:
:: - Busca TODOS los .csproj (ignora bin, obj, packages y .vs).
:: - Compila en "pasadas": los que fallan por falta de la DLL de otro quedan
::   pendientes y se reintentan (hasta 8 pasadas). Asi se resuelve el orden.
:: - Muestra resumen [OK] / [FALTA]. Detalle en logs\build_log.txt
:: ============================================================================

@echo off
if /I not "%~1"=="RUNNING" (
    start "Compilacion de proyectos" cmd /k ""%~f0"" RUNNING
    exit /b
)

:INICIO
setlocal enabledelayedexpansion
color 0A

set "NOMBRE_RAIZ=swsau2k26"
set "ROOT_DIR=%~dp0"

echo ============================================
echo COMPILACION AUTOMATICA DE PROYECTOS C#
echo ============================================
echo.
echo Selecciona la version de Visual Studio para compilar:
echo   [1] Visual Studio 2019
echo   [2] Visual Studio 2022
echo.

choice /c 12 /n /m "Version (1/2): "
set "VS_CHOICE=%errorlevel%"

set "VS_LABEL=2019"
if "%VS_CHOICE%"=="2" set "VS_LABEL=2022"

call :BUSCAR_MSBUILD
if errorlevel 1 (
    echo.
    echo [ERROR] No se encontro MSBuild de Visual Studio !VS_LABEL!.
    echo Verifica que este instalado con la carga de trabajo de desarrollo
    echo .NET / escritorio, o prueba con la otra version.
    echo.
    pause
    exit /b 1
)

echo.
echo ============================================
echo COMPILANDO CON VISUAL STUDIO !VS_LABEL!
echo MSBuild: !MSBUILD_PATH!
echo ============================================

echo.
echo Buscando la carpeta de proyectos...
call :BUSCAR_CODIGO
if errorlevel 1 (
    echo.
    echo [ERROR] No se encontro la carpeta "!NOMBRE_RAIZ!\codigo" en este equipo.
    echo Copia este .bat junto a la carpeta "codigo" o dentro de la carpeta
    echo que contiene tus proyectos y vuelve a intentar.
    echo.
    pause
    exit /b 1
)
echo Carpeta encontrada: !CODIGO_DIR!
set "BUSCAR_DIR=!CODIGO_DIR!\"

cd /d "%ROOT_DIR%"
if not exist "logs" mkdir logs

echo ============================================ > logs\build_log.txt
echo COMPILACION INICIADA: %DATE% %TIME% >> logs\build_log.txt
echo Carpeta: !CODIGO_DIR! >> logs\build_log.txt
echo ============================================ >> logs\build_log.txt

:: --------------------------------------------------------------------------
:: 1) BUSCAR TODOS LOS .csproj
:: --------------------------------------------------------------------------
echo.
echo ============================================
echo BUSCANDO PROYECTOS (.csproj)...
echo ============================================

if exist "logs\pendientes.txt" del /f /q "logs\pendientes.txt"
if exist "logs\pendientes_nuevo.txt" del /f /q "logs\pendientes_nuevo.txt"
if exist "logs\ok.txt" del /f /q "logs\ok.txt"
if exist "logs\todos.txt" del /f /q "logs\todos.txt"

dir /s /b /a-d "!BUSCAR_DIR!*.csproj" > "logs\todos.txt" 2>nul

:: Descartar rutas dentro de bin, obj, packages y .vs
type nul > "logs\pendientes.txt"
for /f "usebackq delims=" %%c in ("logs\todos.txt") do (
    set "P=%%c"
    set "Q=!P:\bin\=!"
    set "Q=!Q:\obj\=!"
    set "Q=!Q:\packages\=!"
    set "Q=!Q:\.vs\=!"
    if "!Q!"=="!P!" echo !P!>>"logs\pendientes.txt"
)
del /f /q "logs\todos.txt"

set /a TOTAL_PROYECTOS=0
for /f "usebackq delims=" %%c in ("logs\pendientes.txt") do set /a TOTAL_PROYECTOS+=1

echo Proyectos encontrados: !TOTAL_PROYECTOS!
echo Proyectos encontrados: !TOTAL_PROYECTOS! >> logs\build_log.txt

if !TOTAL_PROYECTOS! EQU 0 (
    echo.
    echo [ERROR] No se encontro ningun .csproj dentro de !BUSCAR_DIR!
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
        echo !PROYECTO!>>logs\ok.txt
        set /a COMPILADOS_EN_PASADA+=1
    ) else (
        echo   [pendiente] !PROYECTO!
        echo !PROYECTO!>>logs\pendientes_nuevo.txt
        set /a PENDIENTES_EN_PASADA+=1
    )
)

:: Reflejar DLLs nuevas de Debug a Release antes de la siguiente pasada,
:: por si algun proyecto busca la referencia en la carpeta Release.
for /r "!BUSCAR_DIR!" %%d in (*.dll) do (
    if exist "%%d" (
        echo %%~dpd | findstr /I /C:"\Debug\" >nul
        if not errorlevel 1 (
            if not exist "%%~dpd..\Release" mkdir "%%~dpd..\Release" >nul 2>&1
            copy /Y "%%d" "%%~dpd..\Release\" >nul 2>&1
        )
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
    echo Todos los proyectos encontrados se compilaron correctamente.
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

:: ==========================================================
:: SUBRUTINA: localiza MSBuild.exe (Community, Professional,
:: Enterprise o BuildTools) segun la version elegida.
:: ==========================================================
:BUSCAR_MSBUILD
set "MSBUILD_PATH="
set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
set "VS_RANGE=[16.0,17.0)"
if "%VS_CHOICE%"=="2" set "VS_RANGE=[17.0,18.0)"
:: vswhere guarda el resultado en un archivo temporal (evita problemas con los
:: parentesis de "Program Files (x86)")
if exist "%TEMP%\msb_path.txt" del /f /q "%TEMP%\msb_path.txt"
if exist "%VSWHERE%" "%VSWHERE%" -version "%VS_RANGE%" -products * -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe > "%TEMP%\msb_path.txt" 2>nul
if exist "%TEMP%\msb_path.txt" set /p MSBUILD_PATH=<"%TEMP%\msb_path.txt"
if defined MSBUILD_PATH if not exist "%MSBUILD_PATH%" set "MSBUILD_PATH="
if defined MSBUILD_PATH exit /b 0

:: Plan B: rutas estandar de instalacion
set "VS_BASE=%ProgramFiles(x86)%\Microsoft Visual Studio\2019"
if "%VS_CHOICE%"=="2" set "VS_BASE=%ProgramFiles%\Microsoft Visual Studio\2022"
for %%e in (Community Professional Enterprise BuildTools) do if not defined MSBUILD_PATH if exist "%VS_BASE%\%%e\MSBuild\Current\Bin\MSBuild.exe" set "MSBUILD_PATH=%VS_BASE%\%%e\MSBuild\Current\Bin\MSBuild.exe"
if not defined MSBUILD_PATH exit /b 1
exit /b 0

:: ==========================================================
:: SUBRUTINA: localiza la carpeta de proyectos en cualquier PC
:: ==========================================================
:BUSCAR_CODIGO
set "CODIGO_DIR="
if exist "%ROOT_DIR%codigo\" set "CODIGO_DIR=%ROOT_DIR%codigo"
if defined CODIGO_DIR exit /b 0

:: Si el .bat esta dentro de una carpeta que ya tiene proyectos (ej. Gestion de auditores)
for /f "usebackq delims=" %%x in (`dir /s /b /a-d "%ROOT_DIR%*.csproj" 2^>nul`) do if not defined CODIGO_DIR set "CODIGO_DIR=%ROOT_DIR:~0,-1%"
if defined CODIGO_DIR exit /b 0

if exist "C:\%NOMBRE_RAIZ%\codigo\" set "CODIGO_DIR=C:\%NOMBRE_RAIZ%\codigo"
if defined CODIGO_DIR exit /b 0

for %%b in ("%USERPROFILE%\Documents" "%USERPROFILE%\Desktop" "%USERPROFILE%\Downloads" "%USERPROFILE%\source\repos" "%USERPROFILE%\OneDrive\Documents" "%USERPROFILE%\OneDrive\Desktop") do if not defined CODIGO_DIR if exist "%%~b\%NOMBRE_RAIZ%\codigo\" set "CODIGO_DIR=%%~b\%NOMBRE_RAIZ%\codigo"
if defined CODIGO_DIR exit /b 0

echo No esta en las ubicaciones comunes. Buscando en todo el disco C: ...
for /f "usebackq delims=" %%r in (`dir /s /b /ad "C:\%NOMBRE_RAIZ%" 2^>nul`) do if not defined CODIGO_DIR if exist "%%r\codigo\" set "CODIGO_DIR=%%r\codigo"
if not defined CODIGO_DIR exit /b 1
exit /b 0
