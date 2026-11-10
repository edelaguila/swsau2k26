@echo off
:: ============================================================================
:: COMPILAR TODO - SISTEMA DE AUDITORIA (swsau2k26)
::
:: Compila TODOS los proyectos C# (.csproj) que esten dentro de la carpeta
:: "codigo": las bibliotecas (DLL: capas Modelo / Controlador / Vista, los
:: componentes de seguridad, navegador, consultas, reporteador...) y los
:: proyectos ejecutables (EXE) que las usan, incluido Ejecutable_Auditoria.
::
:: PROYECTOS NUEVOS: no hay que editar nada. Cada vez que se ejecuta vuelve a
:: buscar todos los .csproj, asi que cualquier carpeta o proyecto nuevo que se
:: agregue dentro de "codigo" se compila solo, en el lugar que le toca.
::
:: COMO DECIDE EL ORDEN:
:: Lee cada .csproj y mira que DLLs de OTROS proyectos usa (las referencias
:: con HintPath ...\bin\Debug\Algo.dll y las ProjectReference). Con eso arma
:: el orden: primero lo que no depende de nadie (ej. Capa_Modelo_Seguridad),
:: despues lo que usa esas DLLs, y al final los ejecutables. Asi un EXE nunca
:: se compila con una DLL vieja de otro grupo. El orden calculado queda en
:: logs\orden_compilacion.txt
::
:: EXCLUIR PROYECTOS (opcional): crea un archivo "compilar_excluir.txt" junto
:: a este .bat y escribe una linea por proyecto o carpeta que NO quieras
:: compilar (basta una parte del nombre, ej: Planificacionprueba).
:: Las lineas que empiezan con # se ignoran.
::
:: RESULTADOS (carpeta logs):
::   resumen_compilacion.txt  -> estado de cada proyecto y sus errores
::   build_log.txt            -> salida completa de MSBuild
::   orden_compilacion.txt    -> orden usado y que DLL usa cada proyecto
::
:: Requisitos: Visual Studio 2019 / 2022 (o posterior) con ".NET desktop
:: development" y PowerShell (viene con Windows 10/11).
:: Este archivo tiene dos partes: arriba los comandos .bat y abajo, despues
:: de "##PS_INICIO", el motor en PowerShell que hace el trabajo.
:: ============================================================================

if /I not "%~1"=="RUNNING" (
    start "Compilar todo - Sistema de Auditoria" cmd /k ""%~f0"" RUNNING
    exit /b
)

:INICIO
cls
color 0A
for %%I in ("%~dp0.") do set "ROOT_DIR=%%~fI"
set "BAT_FILE=%~f0"

echo ============================================
echo  COMPILAR TODO - SISTEMA DE AUDITORIA
echo ============================================
echo.
echo Version de Visual Studio:
echo   [1] Visual Studio 2019
echo   [2] Visual Studio 2022
echo   [3] Automatico (la mas nueva instalada)
echo.
choice /c 123 /n /m "Version (1/2/3): "
set "VS_CHOICE=%errorlevel%"

echo.
echo Tipo de compilacion:
echo   [C] Completa - borra y recompila todo (recomendado)
echo   [R] Rapida   - solo lo que cambio desde la ultima vez
echo   [O] Solo mostrar el orden de compilacion, sin compilar
echo.
choice /c CRO /n /m "Opcion (C/R/O): "
set "MODO=%errorlevel%"
set "BUILD_TARGET=Rebuild"
set "SOLO_ORDEN=0"
if "%MODO%"=="2" set "BUILD_TARGET=Build"
if "%MODO%"=="3" set "SOLO_ORDEN=1"

:: --- Carpeta de proyectos -------------------------------------------------
:: Normalmente es la carpeta "codigo" junto a este .bat. Si copias el .bat
:: dentro de una carpeta que ya tiene proyectos, compila solo esa carpeta.
set "CODIGO_DIR="
if exist "%ROOT_DIR%\codigo\" set "CODIGO_DIR=%ROOT_DIR%\codigo"
if not defined CODIGO_DIR if exist "C:\swsau2k26\codigo\" set "CODIGO_DIR=C:\swsau2k26\codigo"
if not defined CODIGO_DIR set "CODIGO_DIR=%ROOT_DIR%"
set "LOGS_DIR=%ROOT_DIR%\logs"
if not exist "%LOGS_DIR%" mkdir "%LOGS_DIR%"

:: --- MSBuild ---------------------------------------------------------------
call :BUSCAR_MSBUILD
if errorlevel 1 goto SIN_MSBUILD

where powershell >nul 2>nul
if errorlevel 1 goto SIN_POWERSHELL

echo.
echo ============================================
echo  Visual Studio : %VS_LABEL%
echo  MSBuild       : %MSBUILD_PATH%
echo  Carpeta       : %CODIGO_DIR%
echo ============================================

:: --- Ejecutar el motor (la parte PowerShell al final de este archivo) -----
powershell -NoProfile -ExecutionPolicy Bypass -Command "$s=[IO.File]::ReadAllText($env:BAT_FILE); $i=$s.LastIndexOf('##PS'+'_INICIO'); if($i -lt 0){Write-Host 'No se encontro el motor PowerShell dentro del .bat' -ForegroundColor Red; exit 99}; & ([ScriptBlock]::Create($s.Substring($i))); exit $LASTEXITCODE"
set "RESULTADO=%errorlevel%"

:MENU_FINAL
echo.
echo ============================================
echo   [R] Volver a compilar
echo   [L] Abrir el resumen (logs\resumen_compilacion.txt)
echo   [S] Salir
echo ============================================
choice /c RLS /n /m "Opcion: "
if errorlevel 3 goto FIN
if errorlevel 2 goto ABRIR_LOG
goto INICIO

:ABRIR_LOG
set "ARCHIVO_LOG=resumen_compilacion.txt"
if "%SOLO_ORDEN%"=="1" set "ARCHIVO_LOG=orden_compilacion.txt"
start "" notepad "%LOGS_DIR%\%ARCHIVO_LOG%"
goto MENU_FINAL

:SIN_MSBUILD
echo.
echo [ERROR] No se encontro MSBuild de Visual Studio %VS_LABEL%.
echo Verifica que este instalado con la carga de trabajo ".NET desktop
echo development" o elige otra version (opcion 3 = automatico).
echo.
pause
goto INICIO

:SIN_POWERSHELL
echo.
echo [ERROR] No se encontro PowerShell en este equipo; es necesario para
echo calcular el orden de compilacion.
echo.
pause
goto FIN

:FIN
echo.
echo La ventana se queda abierta para que revises la salida.
echo Escribe "exit" o cierrala con la X.
exit /b 0

:: ==========================================================================
:: SUBRUTINA: localiza MSBuild.exe (Community, Professional, Enterprise o
:: BuildTools) segun la version elegida. Primero con vswhere, luego por rutas
:: estandar de instalacion.
:: ==========================================================================
:BUSCAR_MSBUILD
set "MSBUILD_PATH="
set "VS_RANGE="
set "VS_LABEL=automatica (la mas nueva)"
if "%VS_CHOICE%"=="1" set "VS_RANGE=[16.0,17.0)"
if "%VS_CHOICE%"=="1" set "VS_LABEL=2019"
if "%VS_CHOICE%"=="2" set "VS_RANGE=[17.0,18.0)"
if "%VS_CHOICE%"=="2" set "VS_LABEL=2022"
set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
if exist "%TEMP%\msb_path.txt" del /f /q "%TEMP%\msb_path.txt"
if not exist "%VSWHERE%" goto MSB_PLAN_B
if defined VS_RANGE "%VSWHERE%" -version "%VS_RANGE%" -products * -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe > "%TEMP%\msb_path.txt" 2>nul
if not defined VS_RANGE "%VSWHERE%" -products * -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe > "%TEMP%\msb_path.txt" 2>nul
if exist "%TEMP%\msb_path.txt" set /p MSBUILD_PATH=<"%TEMP%\msb_path.txt"
if defined MSBUILD_PATH if not exist "%MSBUILD_PATH%" set "MSBUILD_PATH="
if defined MSBUILD_PATH exit /b 0

:MSB_PLAN_B
set "VS_BASES="
if "%VS_CHOICE%"=="1" set VS_BASES="%ProgramFiles(x86)%\Microsoft Visual Studio\2019"
if "%VS_CHOICE%"=="2" set VS_BASES="%ProgramFiles%\Microsoft Visual Studio\2022"
if "%VS_CHOICE%"=="3" set VS_BASES="%ProgramFiles%\Microsoft Visual Studio\18" "%ProgramFiles%\Microsoft Visual Studio\2022" "%ProgramFiles(x86)%\Microsoft Visual Studio\2019"
for %%b in (%VS_BASES%) do for %%e in (Community Professional Enterprise BuildTools) do if not defined MSBUILD_PATH if exist "%%~b\%%e\MSBuild\Current\Bin\MSBuild.exe" set "MSBUILD_PATH=%%~b\%%e\MSBuild\Current\Bin\MSBuild.exe"
if not defined MSBUILD_PATH exit /b 1
exit /b 0

:: ============================================================================
:: A PARTIR DE AQUI ES CODIGO POWERSHELL. El .bat nunca llega a esta parte
:: (termina antes con exit /b); la lee y ejecuta el comando powershell de
:: arriba. Si editas algo aqui, deja la linea ##PS_INICIO tal cual.
:: ============================================================================
##PS_INICIO
# ============================================================================
# MOTOR DE COMPILACION (PowerShell). Lo ejecuta el .bat de arriba; no hace
# falta tocar nada aqui para agregar proyectos nuevos.
#
# 1) Busca todos los .csproj dentro de "codigo" (ignora bin, obj, packages).
# 2) Lee cada .csproj: nombre de la DLL/EXE que genera (AssemblyName), si es
#    biblioteca o ejecutable (OutputType) y que DLLs de OTROS proyectos usa
#    (HintPath ...\bin\Debug\X.dll  y  ProjectReference).
# 3) Arma el orden: primero lo que no depende de nadie, despues lo que usa
#    esas DLLs, y asi hasta los ejecutables.
# 4) Compila uno por uno en ese orden. Si algo falla, lo reintenta al final
#    (hasta 3 rondas) por si dependia de algo que no se pudo detectar.
# 5) Muestra el resumen y deja el detalle en la carpeta logs.
# ============================================================================
$ErrorActionPreference = 'Continue'

$msbuild    = $env:MSBUILD_PATH
$codigoDir  = $env:CODIGO_DIR
$logsDir    = $env:LOGS_DIR
$rootDir    = $env:ROOT_DIR
$target     = $env:BUILD_TARGET
$soloOrden  = ($env:SOLO_ORDEN -eq '1')
if (-not $target) { $target = 'Rebuild' }
$sep = [IO.Path]::DirectorySeparatorChar

$logFile     = [IO.Path]::Combine($logsDir, 'build_log.txt')
$ordenFile   = [IO.Path]::Combine($logsDir, 'orden_compilacion.txt')
$resumenFile = [IO.Path]::Combine($logsDir, 'resumen_compilacion.txt')
$errTmp      = [IO.Path]::Combine($logsDir, '_errores_tmp.txt')
$excluirFile = [IO.Path]::Combine($rootDir, 'compilar_excluir.txt')
$utf8 = New-Object System.Text.UTF8Encoding($false)

function Rel([string]$p) {
    if ($p.StartsWith($codigoDir, [StringComparison]::OrdinalIgnoreCase)) {
        return $p.Substring($codigoDir.Length).TrimStart('\', '/')
    }
    return $p
}
function Ruta([string]$base, [string]$rel) {
    $rel = $rel -replace '[\\/]', [string]$sep
    try { return [IO.Path]::GetFullPath([IO.Path]::Combine($base, $rel)) } catch { return $null }
}

# ---------------------------------------------------------------------------
# 1) Buscar proyectos
# ---------------------------------------------------------------------------
$excluir = @()
if (Test-Path -LiteralPath $excluirFile) {
    $excluir = @(Get-Content -LiteralPath $excluirFile -Encoding UTF8 |
        ForEach-Object { $_.Trim() } | Where-Object { $_ -and -not $_.StartsWith('#') })
}

$ignorarCarpetas = @('bin', 'obj', 'packages', 'node_modules', '.vs', '.git')
$archivos = Get-ChildItem -LiteralPath $codigoDir -Recurse -File -Filter '*.csproj' -ErrorAction SilentlyContinue |
    Where-Object {
        $partes = $_.FullName.Substring($codigoDir.Length) -split '[\\/]'
        -not ($partes | Where-Object { $ignorarCarpetas -contains $_.ToLower() })
    } | Sort-Object FullName

$proyectos = New-Object System.Collections.Generic.List[object]
$excluidos = New-Object System.Collections.Generic.List[string]
foreach ($f in $archivos) {
    $rel = Rel $f.FullName
    $skip = $false
    foreach ($e in $excluir) { if ($rel -like "*$e*") { $skip = $true } }
    if ($skip) { $excluidos.Add($rel); continue }

    $p = [pscustomobject]@{
        Path = $f.FullName; Dir = $f.DirectoryName; Rel = $rel
        Assembly = [IO.Path]::GetFileNameWithoutExtension($f.Name)
        Tipo = 'DLL'; Sdk = $false; PkgConfig = $false; Valido = $true
        RefNombres = New-Object System.Collections.Generic.List[string]
        RefProyectos = New-Object System.Collections.Generic.List[string]
        Deps = New-Object System.Collections.Generic.List[object]
        Estado = ''; Errores = @(); Avisos = New-Object System.Collections.Generic.List[string]; Segundos = 0
    }
    try {
        $xml = New-Object System.Xml.XmlDocument
        $xml.Load($f.FullName)
        $root = $xml.DocumentElement
        if ($root.GetAttribute('Sdk')) { $p.Sdk = $true }
        $n = $xml.SelectSingleNode("//*[local-name()='AssemblyName']")
        if ($n -and $n.InnerText.Trim() -and $n.InnerText -notmatch '\$\(') { $p.Assembly = $n.InnerText.Trim() }
        $n = $xml.SelectSingleNode("//*[local-name()='OutputType']")
        if ($n -and $n.InnerText.Trim() -match '^(WinExe|Exe)$') { $p.Tipo = 'EXE' }
        foreach ($r in $xml.SelectNodes("//*[local-name()='Reference']")) {
            $hint = $r.SelectSingleNode("*[local-name()='HintPath']")
            if ($hint -and $hint.InnerText.Trim()) {
                $nombre = [IO.Path]::GetFileNameWithoutExtension(($hint.InnerText.Trim() -replace '[\\/]', '/').Split('/')[-1])
            } else {
                $nombre = ($r.GetAttribute('Include') -split ',')[0].Trim()
            }
            if ($nombre) { $p.RefNombres.Add($nombre) }
        }
        foreach ($r in $xml.SelectNodes("//*[local-name()='ProjectReference']")) {
            $full = Ruta $f.DirectoryName $r.GetAttribute('Include')
            if ($full) { $p.RefProyectos.Add($full) }
        }
    } catch {
        $p.Valido = $false
        $p.Avisos.Add('El .csproj no se pudo leer (XML danado): ' + $_.Exception.Message)
    }
    if (Test-Path -LiteralPath ([IO.Path]::Combine($f.DirectoryName, 'packages.config'))) { $p.PkgConfig = $true }
    $proyectos.Add($p)
}

if ($proyectos.Count -eq 0) {
    Write-Host '[ERROR] No se encontro ningun .csproj dentro de' $codigoDir -ForegroundColor Red
    exit 1
}

# ---------------------------------------------------------------------------
# 2) Resolver dependencias (quien usa la DLL de quien)
# ---------------------------------------------------------------------------
$porAssembly = @{}
$porRuta = @{}
foreach ($p in $proyectos) {
    $k = $p.Assembly.ToLower()
    if (-not $porAssembly.ContainsKey($k)) { $porAssembly[$k] = New-Object System.Collections.Generic.List[object] }
    $porAssembly[$k].Add($p)
    $porRuta[$p.Path.ToLower()] = $p
}
$duplicados = @($porAssembly.Keys | Where-Object { $porAssembly[$_].Count -gt 1 })

foreach ($p in $proyectos) {
    foreach ($nombre in $p.RefNombres) {
        $k = $nombre.ToLower()
        if ($porAssembly.ContainsKey($k)) {
            foreach ($d in $porAssembly[$k]) { if ($d -ne $p -and -not $p.Deps.Contains($d)) { $p.Deps.Add($d) } }
        }
    }
    foreach ($ruta in $p.RefProyectos) {
        $k = $ruta.ToLower()
        if ($porRuta.ContainsKey($k)) {
            $d = $porRuta[$k]
            if ($d -ne $p -and -not $p.Deps.Contains($d)) { $p.Deps.Add($d) }
        }
    }
}

# ---------------------------------------------------------------------------
# 3) Orden de compilacion (orden topologico). Entre los que estan listos al
#    mismo tiempo van primero las bibliotecas (DLL) y luego los ejecutables.
# ---------------------------------------------------------------------------
# Nivel = largo de la cadena de dependencias (0 = no usa DLLs de otros proyectos)
$nivel = @{}
function Nivel($p, $visitando) {
    if ($nivel.ContainsKey($p.Path)) { return $nivel[$p.Path] }
    if ($visitando.ContainsKey($p.Path)) { return 0 }
    $visitando[$p.Path] = $true
    $max = 0
    foreach ($d in $p.Deps) { $n = (Nivel $d $visitando) + 1; if ($n -gt $max) { $max = $n } }
    $visitando.Remove($p.Path)
    $nivel[$p.Path] = $max
    return $max
}
foreach ($p in $proyectos) { [void](Nivel $p @{}) }

$orden = New-Object System.Collections.Generic.List[object]
$hecho = @{}
$ciclos = New-Object System.Collections.Generic.List[string]
$clave = @(
    @{ Expression = { if ($_.Tipo -eq 'DLL') { 0 } else { 1 } } },
    @{ Expression = { $nivel[$_.Path] } },
    'Rel'
)
while ($orden.Count -lt $proyectos.Count) {
    $resto = @($proyectos | Where-Object { -not $hecho.ContainsKey($_.Path) })
    $listos = @($resto | Where-Object { -not ($_.Deps | Where-Object { -not $hecho.ContainsKey($_.Path) }) })
    if ($listos.Count -gt 0) {
        # De los que ya tienen todas sus dependencias listas: primero DLL, luego EXE
        $elegido = $listos | Sort-Object $clave | Select-Object -First 1
    } else {
        # Dependencia circular: se toma el que tenga menos pendientes y se avisa
        $elegido = $resto | Sort-Object @{ Expression = { @($_.Deps | Where-Object { -not $hecho.ContainsKey($_.Path) }).Count } }, Rel | Select-Object -First 1
        $ciclos.Add($elegido.Rel)
        $elegido.Avisos.Add('Dependencia circular detectada: se compilo antes que alguna de sus dependencias.')
    }
    $orden.Add($elegido); $hecho[$elegido.Path] = $true
}

$lineas = New-Object System.Collections.Generic.List[string]
$lineas.Add('ORDEN DE COMPILACION CALCULADO - ' + (Get-Date).ToString('yyyy-MM-dd HH:mm:ss'))
$lineas.Add('Carpeta: ' + $codigoDir)
$lineas.Add('')
$i = 0
foreach ($p in $orden) {
    $i++
    $lineas.Add(('{0,3}. [{1}] {2}   ({3})' -f $i, $p.Tipo, $p.Rel, $p.Assembly))
    foreach ($d in $p.Deps) { $lineas.Add('          usa: ' + $d.Assembly) }
}
if ($excluidos.Count -gt 0) {
    $lineas.Add(''); $lineas.Add('EXCLUIDOS (por compilar_excluir.txt):')
    foreach ($e in $excluidos) { $lineas.Add('   ' + $e) }
}
[IO.File]::WriteAllLines($ordenFile, $lineas.ToArray(), $utf8)

$nDll = @($orden | Where-Object { $_.Tipo -eq 'DLL' }).Count
$nExe = $orden.Count - $nDll
Write-Host ''
Write-Host ('Proyectos encontrados: {0}  ({1} bibliotecas DLL, {2} ejecutables EXE)' -f $orden.Count, $nDll, $nExe)
if ($excluidos.Count -gt 0) { Write-Host ('Excluidos por compilar_excluir.txt: {0}' -f $excluidos.Count) -ForegroundColor DarkYellow }
foreach ($k in $duplicados) {
    Write-Host ('[AVISO] Hay {0} proyectos que generan la misma DLL "{1}":' -f $porAssembly[$k].Count, $porAssembly[$k][0].Assembly) -ForegroundColor Yellow
    foreach ($d in $porAssembly[$k]) { Write-Host ('          ' + $d.Rel) -ForegroundColor Yellow }
}
Write-Host 'Orden calculado guardado en logs\orden_compilacion.txt'

if ($soloOrden) { exit 0 }

# ---------------------------------------------------------------------------
# 4) Compilar
# ---------------------------------------------------------------------------
$enc = "COMPILACION INICIADA: " + (Get-Date).ToString('yyyy-MM-dd HH:mm:ss') + "`r`nMSBuild: $msbuild`r`nModo: $target`r`nCarpeta: $codigoDir`r`n"
[IO.File]::WriteAllText($logFile, $enc, $utf8)

function Compilar($p, [int]$num, [int]$total, [string]$ronda) {
    $sw = [Diagnostics.Stopwatch]::StartNew()
    $tag = '[' + $p.Tipo + ']'
    Write-Host ('{0,3}/{1} {2} {3} ' -f $num, $total, $tag, $p.Rel) -NoNewline
    [IO.File]::AppendAllText($logFile, "`r`n==================================================`r`n$ronda - $($p.Rel)`r`n==================================================`r`n", $utf8)

    # SolutionDir = carpeta del .sln mas cercano (igual que cuando se abre en Visual Studio)
    $sol = $p.Dir
    $d = $p.Dir
    while ($d -and $d.Length -ge $codigoDir.Length) {
        if (Get-ChildItem -LiteralPath $d -Filter '*.sln' -File -ErrorAction SilentlyContinue | Select-Object -First 1) { $sol = $d; break }
        $d = [IO.Path]::GetDirectoryName($d)
    }
    $env:SolutionDir = $sol.TrimEnd('\', '/') + [string]$sep

    if ($p.Sdk -or $p.PkgConfig) {
        & $msbuild $p.Path '/t:Restore' '/p:RestorePackagesConfig=true' '/nologo' '/nr:false' '/noconsolelogger' "/flp:LogFile=$logFile;Append;Encoding=UTF-8;Verbosity=minimal" | Out-Null
    }
    if (Test-Path -LiteralPath $errTmp) { Remove-Item -LiteralPath $errTmp -Force }
    & $msbuild $p.Path "/t:$target" '/p:Configuration=Debug' '/p:BuildProjectReferences=false' '/nologo' '/nr:false' '/noconsolelogger' `
        "/flp:LogFile=$logFile;Append;Encoding=UTF-8;Verbosity=normal" "/flp1:LogFile=$errTmp;ErrorsOnly;Encoding=UTF-8" | Out-Null
    $ok = ($LASTEXITCODE -eq 0)
    $sw.Stop()
    $p.Segundos = [math]::Round($sw.Elapsed.TotalSeconds, 1)

    if ($ok) {
        $p.Estado = 'OK'; $p.Errores = @()
        $malas = @($p.Deps | Where-Object { $_.Estado -eq 'FALLA' })
        if ($malas.Count -gt 0) {
            $p.Estado = 'OK*'
            $p.Avisos.Add('Compilo usando la version ANTERIOR de: ' + (($malas | ForEach-Object { $_.Assembly }) -join ', ') + ' (esa no compilo ahora).')
            Write-Host ('OK* ({0}s)' -f $p.Segundos) -ForegroundColor Yellow
        } else {
            Write-Host ('OK ({0}s)' -f $p.Segundos) -ForegroundColor Green
        }
    } else {
        $p.Estado = 'FALLA'
        $errs = @()
        if (Test-Path -LiteralPath $errTmp) {
            $errs = @(Get-Content -LiteralPath $errTmp -Encoding UTF8 | Where-Object { $_.Trim() } |
                ForEach-Object { (($_ -replace '\s*\[[^\]]+\.csproj\]\s*$', '').Replace($codigoDir + [string]$sep, '')).Trim() } |
                Select-Object -Unique)
        }
        if ($errs.Count -eq 0) { $errs = @('Sin detalle de error; revisa logs\build_log.txt') }
        $p.Errores = $errs
        Write-Host ('FALLA ({0}s)' -f $p.Segundos) -ForegroundColor Red
    }
    return $ok
}

$inicio = Get-Date
Write-Host ''
Write-Host '============================================'
Write-Host ('COMPILANDO EN ORDEN ({0})' -f $target)
Write-Host '============================================'
$num = 0
foreach ($p in $orden) {
    $num++
    if (-not $p.Valido) { $p.Estado = 'FALLA'; $p.Errores = @($p.Avisos[0]); Write-Host ('{0,3}/{1} [{2}] {3} FALLA (csproj ilegible)' -f $num, $orden.Count, $p.Tipo, $p.Rel) -ForegroundColor Red; continue }
    [void](Compilar $p $num $orden.Count 'RONDA 1')
}

# Reintentos: solo los que fallaron, mientras se siga avanzando (max 3 rondas)
for ($ronda = 2; $ronda -le 4; $ronda++) {
    $fallidos = @($orden | Where-Object { $_.Estado -eq 'FALLA' -and $_.Valido })
    if ($fallidos.Count -eq 0) { break }
    Write-Host ''
    Write-Host ('--- Reintento {0}: {1} proyecto(s) que fallaron ---' -f ($ronda - 1), $fallidos.Count) -ForegroundColor DarkYellow
    $avance = 0; $num = 0
    foreach ($p in $fallidos) {
        $num++
        if (Compilar $p $num $fallidos.Count ('RONDA ' + $ronda)) { $avance++ }
    }
    if ($avance -eq 0) { break }
}

# ---------------------------------------------------------------------------
# 5) Resumen
# ---------------------------------------------------------------------------
$dur = (Get-Date) - $inicio
$okList    = @($orden | Where-Object { $_.Estado -eq 'OK' })
$okAviso   = @($orden | Where-Object { $_.Estado -eq 'OK*' })
$fallaList = @($orden | Where-Object { $_.Estado -eq 'FALLA' })

$res = New-Object System.Collections.Generic.List[string]
$res.Add('RESUMEN DE COMPILACION - ' + (Get-Date).ToString('yyyy-MM-dd HH:mm:ss'))
$res.Add(('Total: {0}   OK: {1}   OK con aviso: {2}   Fallaron: {3}   Tiempo: {4:mm\:ss}' -f $orden.Count, $okList.Count, $okAviso.Count, $fallaList.Count, $dur))
$res.Add('')
foreach ($p in $orden) { $res.Add(('[{0,-5}] [{1}] {2}' -f $p.Estado, $p.Tipo, $p.Rel)) }

Write-Host ''
Write-Host '============================================'
Write-Host 'RESUMEN FINAL'
Write-Host '============================================'
Write-Host ('Total: {0}   ' -f $orden.Count) -NoNewline
Write-Host ('OK: {0}   ' -f ($okList.Count + $okAviso.Count)) -ForegroundColor Green -NoNewline
Write-Host ('Fallaron: {0}   ' -f $fallaList.Count) -ForegroundColor $(if ($fallaList.Count) { 'Red' } else { 'Green' }) -NoNewline
Write-Host ('Tiempo: {0:mm\:ss}' -f $dur)

foreach ($t in @('DLL', 'EXE')) {
    $deTipo = @($orden | Where-Object { $_.Tipo -eq $t })
    $bien = @($deTipo | Where-Object { $_.Estado -like 'OK*' }).Count
    $nombreTipo = if ($t -eq 'DLL') { 'Bibliotecas (DLL)' } else { 'Ejecutables (EXE)' }
    Write-Host ('  {0,-18}: {1} de {2} compilados' -f $nombreTipo, $bien, $deTipo.Count) -ForegroundColor $(if ($bien -eq $deTipo.Count) { 'Green' } else { 'Yellow' })
}

if ($okAviso.Count -gt 0) {
    Write-Host ''
    Write-Host 'Compilaron, pero con una DLL vieja (arregla primero la que fallo):' -ForegroundColor Yellow
    $res.Add(''); $res.Add('COMPILARON CON AVISO:')
    foreach ($p in $okAviso) {
        Write-Host ('  [OK*] ' + $p.Rel) -ForegroundColor Yellow
        foreach ($a in $p.Avisos) { Write-Host ('        ' + $a) -ForegroundColor DarkYellow; $res.Add('  ' + $p.Rel + ' -> ' + $a) }
    }
}

if ($fallaList.Count -gt 0) {
    Write-Host ''
    Write-Host 'NO COMPILARON:' -ForegroundColor Red
    $res.Add(''); $res.Add('NO COMPILARON:')
    foreach ($p in $fallaList) {
        Write-Host ('  [FALLA] [{0}] {1}' -f $p.Tipo, $p.Rel) -ForegroundColor Red
        $res.Add('  ' + $p.Rel)
        $mostrar = @($p.Errores | Select-Object -First 3)
        foreach ($e in $mostrar) { Write-Host ('        ' + $e) -ForegroundColor DarkRed }
        if ($p.Errores.Count -gt 3) { Write-Host ('        ... y {0} error(es) mas' -f ($p.Errores.Count - 3)) -ForegroundColor DarkRed }
        foreach ($e in $p.Errores) { $res.Add('      ' + $e) }
    }
    Write-Host ''
    Write-Host 'Detalle completo en logs\build_log.txt' -ForegroundColor DarkYellow
} else {
    Write-Host ''
    Write-Host 'Todos los proyectos compilaron correctamente.' -ForegroundColor Green
}
if ($ciclos.Count -gt 0) {
    Write-Host ''
    Write-Host '[AVISO] Se detectaron dependencias circulares en:' -ForegroundColor Yellow
    foreach ($c in $ciclos) { Write-Host ('  ' + $c) -ForegroundColor Yellow }
}
[IO.File]::WriteAllLines($resumenFile, $res.ToArray(), $utf8)
if (Test-Path -LiteralPath $errTmp) { Remove-Item -LiteralPath $errTmp -Force }
exit $fallaList.Count
