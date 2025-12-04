# VBAcoustic-for-Revit
PlugIn for Revit to export files for VBAcoustic 
This PlugIn works for Revit 2024. It is part of the project "Noise protection_FSP Bayern: Prediction method for noise and vibration protection for BIM-based building planning - completion of input data and extension to artificial intelligence methods" (https://projekte.th-rosenheim.de/en/forschungsprojekt/363-schallschutz_fsp-bayern)
from "Applied Acoustics - Laboratory for Sound Measurement" at the University of Applied Sciences in Rosenheim (https://www.th-rosenheim.de/en/die-hochschule/labore/labore-ang/applied-acoustics-laboratory-for-sound-measurement-1). This project was funded by the "Bayerisches Staatsministerium für Wissenschaft und Kunst" as part of the funding program "Programm zur Förderung der angewandten Forschung und Entwicklung an Hochschulen für angewandte Wissenschaften - Fachhochschulen".

# How to Install
This version is working with Revit 2024. 
To install the PlugIn navigate to the Addins path of Revit: C:\...\AppData\Roaming\Autodesk\Revit\Addins\2024 .
Add the files "VBAcousticPlugin.dll" and "VBAcousticPlugin.addin" to the folder.
When you start Revit 2024 a safety information will ask for permission to load the Plugin.

# How to work with the Visual Studio Project
To work with the Visual Studio Project you need to add Dependencies to the project. Within the Solution Explorer, right-click "Dependencies" and select "Add Project Reference...". Search for the files "RevitAPI.dll" and " RevitAPIUI.dll" under your Program Files 
C:\Program Files\Autodesk\Revit 2024\ .
