:: ============================================================================
:: GRUPO 1 - MANTENIMIENTOS (MODULO 10: PROYECTOS)
:: Compilacion y ejecucion de los formularios del Grupo 1
:: VISUAL STUDIO 2019 o 2022 (a elegir)
::
:: UBICACION:
:: Este archivo va dentro de  codigo\Grupo1_Mantenimientos\
:: Las rutas se calculan a partir de donde esta el .bat, asi que funciona
:: en cualquier PC mientras se respete la estructura del repositorio.
::
:: FORMULARIOS QUE MANEJA:
::   [1] Proyectos            (app 500)  DLLs\DLL_Proyecto\Exe_PY
::   [2] Estados de Proyecto  (app 501)  Mnt\Mnt_PE\Exe_PE           (usa navegador)
::   [3] Actividades          (app 502)  Mantenimientos_Actividades_Proyectos\...\Ejecutable_Actividades
::   [4] Areas                (app 503)  Mant Areas\Ejecucion_Mant_Areas
::   [5] Recursos             (app 504)  DLLs\Mantenimiento_Recursos\Exe_Mant
::
:: DEPENDENCIAS:
:: Estados de Proyecto usa el componente Navegador, y el Navegador depende de
:: Seguridad, Consultas y Reporteador. Recursos referencia Seguridad. Por eso
:: la opcion [C] compila primero codigo\componentes y despues el Grupo 1.
:: Si ya compilaste los componentes con Sistema_auditoria.bat, usa la opcion
:: [G] para compilar solo el Grupo 1 (es mas rapido).
::
:: COMO RESUELVE EL ORDEN:
:: Igual que Sistema_auditoria.bat: intenta compilar todos los .csproj
:: pendientes en "pasadas". Los que fallan porque aun les falta la DLL de
:: otro proyecto se reintentan en la siguiente pasada (maximo 8).
::
:: PROYECTO EXCLUIDO:
:: Ejecutable_Actividades_pro (SDK net8.0-windows) se excluye: referencia
:: DLLs de .NET Framework 4.7.2 y duplica a Ejecutable_Actividades, que es
:: el ejecutable que si se usa.
::
:: VENTANA QUE NO SE CIERRA:
:: El .bat se relanza a si mismo con "cmd /k" para que puedas leer la
:: salida con calma.
:: ============================================================================

@echo off
if /I not "%~1"=="RUNNING" (
    start "Grupo 1 - Mantenimientos" cmd /k ""%~f0"" RUNNING
    exit /b
)

setlocal enabledelayedexpansion
color 0B

set "G1_DIR=%~dp0"
if "%G1_DIR:~-1%"=="\" set "G1_DIR=%G1_DIR:~0,-1%"
for %%i in ("%G1_DIR%\..") do set "CODIGO_DIR=%%~fi"
set "COMP_DIR=%CODIGO_DIR%\componentes"
set "LOG_DIR=%G1_DIR%\logs"

:: --------------------------------------------------------------------------
:: Rutas de los ejecutables (salida bin\Debug de cada proyecto)
:: --------------------------------------------------------------------------
set "EXE_1=%G1_DIR%\DLLs\DLL_Proyecto\Exe_PY\Exe_PY\bin\Debug\Exe_PY.exe"
set "EXE_2=%G1_DIR%\Mnt\Mnt_PE\Exe_PE\Exe_PE\bin\Debug\Exe_PE.exe"
set "EXE_3=%G1_DIR%\Mantenimientos_Actividades_Proyectos\Ejecutable_Actividades_pro\Ejecutable_Actividades\bin\Debug\Ejecutable_Actividades.exe"
set "EXE_4=%G1_DIR%\Mant Areas\Ejecucion_Mant_Areas\Ejecucion_Mant_Areas\bin\Debug\Ejecucion_Mant_Areas.exe"
set "EXE_5=%G1_DIR%\DLLs\Mantenimiento_Recursos\Exe_Mant\Exe_Mant\bin\Debug\Exe_Mant.exe"

set "NOM_1=Proyectos"
set "NOM_2=Estados de Proyecto"
set "NOM_3=Actividades"
set "NOM_4=Areas"
set "NOM_5=Recursos"

if not exist "%LOG_DIR%" mkdir "%LOG_DIR%"

:: ==========================================================================
:: MENU PRINCIPAL
:: ==========================================================================
:MENU
cls
echo ============================================
echo  GRUPO 1 - MANTENIMIENTOS (MODULO 10)
echo ============================================
echo.
echo  COMPILAR
echo   [C] Compilar todo (componentes + Grupo 1)
echo   [G] Compilar solo Grupo 1
echo.
echo  ABRIR FORMULARIO
for /l %%n in (1,1,5) do (
    if exist "!EXE_%%n!" (
        echo   [%%n] !NOM_%%n!
    ) else (
        echo   [%%n] !NOM_%%n!   ^(sin compilar^)
    )
)
echo   [T] Abrir todos
echo.
echo   [S] Salir
echo ============================================
choice /c CG12345TS /n /m "Seleccion: "
set "OP=%errorlevel%"

if "%OP%"=="1" ( set "INCLUIR_COMP=SI" & goto COMPILAR )
if "%OP%"=="2" ( set "INCLUIR_COMP=NO" & goto COMPILAR )
if "%OP%"=="3" ( set "N=1" & goto ABRIR_UNO )
if "%OP%"=="4" ( set "N=2" & goto ABRIR_UNO )
if "%OP%"=="5" ( set "N=3" & goto ABRIR_UNO )
if "%OP%"=="6" ( set "N=4" & goto ABRIR_UNO )
if "%OP%"=="7" ( set "N=5" & goto ABRIR_UNO )
if "%OP%"=="8" goto ABRIR_TODOS
if "%OP%"=="9" goto FIN
goto MENU

:: ==========================================================================
:: ABRIR FORMULARIOS
:: ==========================================================================
:ABRIR_UNO
call :LANZAR !N!
echo.
pause
goto MENU

:ABRIR_TODOS
for /l %%n in (1,1,5) do call :LANZAR %%n
echo.
pause
goto MENU

:LANZAR
set "EXE=!EXE_%1!"
set "NOM=!NOM_%1!"
if not exist "!EXE!" (
    echo [FALTA] !NOM!: no existe el ejecutable. Compila primero con [C] o [G].
    echo         !EXE!
    exit /b 0
)
for %%f in ("!EXE!") do set "EXE_DIR=%%~dpf"
echo [ABRIENDO] !NOM!
start "" /D "!EXE_DIR!" "!EXE!"
exit /b 0

:: ==========================================================================
:: COMPILACION
:: ==========================================================================
:COMPILAR
echo.
echo Selecciona la version de Visual Studio para compilar:
echo   [1] Visual Studio 2019
echo   [2] Visual Studio 2022
echo.
choice /c 12 /n /m "Version (1/2): "
set "VS_CHOICE=%errorlevel%"

:: Los "set" con "Program Files (x86)" van fuera de bloques if(...) para que
:: cmd.exe no cuente mal los parentesis.
set "VS_LABEL=2019"
if "%VS_CHOICE%"=="2" set "VS_LABEL=2022"

set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
if "%VS_CHOICE%"=="2" set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"

if not exist "!MSBUILD_PATH!" (
    echo.
    echo [ERROR] No se encontro MSBuild de Visual Studio !VS_LABEL! en:
    echo   !MSBUILD_PATH!
    echo Si tienes Professional o Enterprise, o esta en otra ruta, corrige
    echo la linea "set MSBUILD_PATH" correspondiente en este .bat.
    echo.
    pause
    goto MENU
)

set "LOG=%LOG_DIR%\build_grupo1.txt"
set "PEND=%LOG_DIR%\pendientes.txt"
set "PEND_NUEVO=%LOG_DIR%\pendientes_nuevo.txt"
set "OK_LIST=%LOG_DIR%\ok.txt"

echo ============================================ > "!LOG!"
echo COMPILACION GRUPO 1 INICIADA: %DATE% %TIME% >> "!LOG!"
echo Visual Studio !VS_LABEL! >> "!LOG!"
echo ============================================ >> "!LOG!"

if exist "!PEND!" del /f /q "!PEND!"
if exist "!PEND_NUEVO!" del /f /q "!PEND_NUEVO!"
if exist "!OK_LIST!" del /f /q "!OK_LIST!"

:: --------------------------------------------------------------------------
:: 1) Lista de proyectos: componentes (opcional) + Grupo 1
:: --------------------------------------------------------------------------
echo.
echo ============================================
echo BUSCANDO PROYECTOS (.csproj)
echo ============================================

if /I "!INCLUIR_COMP!"=="SI" (
    if exist "!COMP_DIR!" (
        dir /s /b /a-d "!COMP_DIR!\*.csproj" >> "!PEND!" 2>nul
    ) else (
        echo [AVISO] No se encontro la carpeta de componentes: !COMP_DIR!
    )
)

for /f "delims=" %%c in ('dir /s /b /a-d "%G1_DIR%\*.csproj" 2^>nul ^| findstr /V /I /C:"Ejecutable_Actividades_pro.csproj"') do (
    echo %%c>> "!PEND!"
)

set /a TOTAL=0
if exist "!PEND!" for /f "usebackq delims=" %%c in ("!PEND!") do set /a TOTAL+=1

echo Proyectos encontrados: !TOTAL!
echo Proyectos encontrados: !TOTAL! >> "!LOG!"

if !TOTAL! EQU 0 (
    echo [ERROR] No se encontro ningun .csproj.
    pause
    goto MENU
)

if /I "!INCLUIR_COMP!"=="NO" (
    if not exist "!COMP_DIR!\navegador\NavegadorMVC\CapaVistaNavegador\bin\Debug\Capa_Vista_Navegador.dll" (
        echo.
        echo [AVISO] No se encontro la DLL del Navegador compilada.
        echo         Estados de Proyecto no va a compilar hasta que compiles los
        echo         componentes ^(opcion [C] o Sistema_auditoria.bat^).
    )
)

:: --------------------------------------------------------------------------
:: 2) Compilar por pasadas
:: --------------------------------------------------------------------------
set /a MAX_PASADAS=8
set /a PASADA=0

:PASADA_LOOP
set /a PASADA+=1
set /a COMP_PASADA=0
set /a PEND_PASADA=0

echo.
echo ============================================
echo PASADA !PASADA!
echo ============================================

if exist "!PEND_NUEVO!" del /f /q "!PEND_NUEVO!"

for /f "usebackq delims=" %%p in ("!PEND!") do (
    set "PROYECTO=%%p"
    set "ES_SDK=NO"
    findstr /I /C:"Microsoft.NET.Sdk" "!PROYECTO!" >nul 2>&1
    if !errorlevel! EQU 0 set "ES_SDK=SI"

    echo. >> "!LOG!"
    echo -------------------------------------------- >> "!LOG!"
    echo PASADA !PASADA! - !PROYECTO! >> "!LOG!"
    echo -------------------------------------------- >> "!LOG!"

    if "!ES_SDK!"=="SI" (
        "!MSBUILD_PATH!" "!PROYECTO!" /t:Restore /p:Configuration=Debug /nologo /v:minimal >> "!LOG!" 2>&1
    )

    "!MSBUILD_PATH!" "!PROYECTO!" /t:Build /p:Configuration=Debug /nologo /v:minimal >> "!LOG!" 2>&1

    if !errorlevel! EQU 0 (
        echo   [OK] %%~np
        echo !PROYECTO!>> "!OK_LIST!"
        set /a COMP_PASADA+=1
    ) else (
        echo   [pendiente] %%~np
        echo !PROYECTO!>> "!PEND_NUEVO!"
        set /a PEND_PASADA+=1
    )
)

echo.
echo Pasada !PASADA!: !COMP_PASADA! compilados, !PEND_PASADA! pendientes.

if exist "!PEND_NUEVO!" (
    move /y "!PEND_NUEVO!" "!PEND!" >nul
) else (
    if exist "!PEND!" del /f /q "!PEND!"
)

if !PEND_PASADA! EQU 0 goto PASADAS_FIN
if !COMP_PASADA! EQU 0 goto PASADAS_FIN
if !PASADA! GEQ !MAX_PASADAS! goto PASADAS_FIN
goto PASADA_LOOP

:PASADAS_FIN
echo.
echo ============================================
echo RESUMEN
echo ============================================
echo.

if exist "!PEND!" (
    echo No se lograron compilar:
    for /f "usebackq delims=" %%f in ("!PEND!") do echo   [FALTA] %%f
    echo.
    echo Revisa el error exacto en: !LOG!
) else (
    echo Todos los proyectos se compilaron correctamente.
)

echo.
echo Ejecutables del Grupo 1:
for /l %%n in (1,1,5) do (
    if exist "!EXE_%%n!" (
        echo   [OK]    !NOM_%%n!
    ) else (
        echo   [FALTA] !NOM_%%n!
    )
)
echo.
echo Log: !LOG!
echo.
pause
goto MENU

:FIN
echo.
echo La ventana se queda abierta. Escribe "exit" o cierrala con la X.
endlocal
exit /b 0
