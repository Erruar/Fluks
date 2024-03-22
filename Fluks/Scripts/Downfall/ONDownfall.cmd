@echo off
Title Enable Downfall & Color 9F
setlocal ENABLEDELAYEDEXPANSION

:: CHECK FOR ADMIN PRIVILEGES
dism >nul 2>&1 || (echo This must be run as Administrator to continue. && pause && exit /b 1)

@echo off
echo.
echo Enabling Downfall
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management" /v FeatureSettingsOverride /t REG_DWORD /d 00000003 /f

@echo off 

powershell -Command "& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('Mitigation Enabled', 'Fluks', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}"

cls
exit