@echo off

if exist "s:\source\repos\Gestures\GesturesApp\Properties\AssemblyInfo.cs.backup" (


ren "s:\source\repos\Gestures\GesturesApp\Properties\AssemblyInfo.cs.backup" "AssemblyInfo.cs"
echo "Restored AssemblyInfo from backup"

) else (

  echo "File 's:\source\repos\Gestures\GesturesApp\Properties\AssemblyInfo.cs.backup' does not exist."

)


if exist "s:\source\repos\Gestures\GesturesApp\Properties\Settings.settings.backup" (

 ren "s:\source\repos\Gestures\GesturesApp\Properties\Settings.settings.backup" "Settings.settings"
echo "Restored Settings from backup"

) else (

  echo "File 's:\source\repos\Gestures\GesturesApp\Properties\Settings.settings.backup' does not exist."

)
