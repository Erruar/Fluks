@echo off
Title Disable Crap & Color 9F
setlocal ENABLEDELAYEDEXPANSION

:: CHECK FOR ADMIN PRIVILEGES
dism >nul 2>&1 || (echo This must be run as Administrator to continue. && pause && exit /b 1)

@echo off
echo.
echo Removing Crap
schtasks /Delete /TN "Microsoft\Windows\Defrag\ScheduledDefrag" /F
schtasks /Delete /TN "Microsoft\Windows\MemoryDiagnostic\RunFullMemoryDiagnostic" /F
schtasks /Delete /TN "Microsoft\Windows\MemoryDiagnostic\ProcessMemoryDiagnosticEvents" /F

@echo off 

powershell -Command "& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('Crap Removed', 'Fluks', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}"

cls
exit

