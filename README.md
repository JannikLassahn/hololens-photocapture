# HoloLens PhotoCapture Sample #

## What is this repository for? ##

This is a sample application for using Unity's PhotoCapture API in combination with HoloLens. Most noticeably, there should be holograms visible in the final image.

The ```PhotoManager```, responsible for taking and saving images, is being controlled by the following voice commands:

* **Take photo:** Takes a photo an saves it
* **Stop camera:**  Stops the camera.

The current status of the camera is visible in the lower right corner.

### Behaviour in Unity Editor ###
The photo is saved to *%userprofile%\AppData\Local\Packages\PRODUCT_NAME\LocalState* 
(according to the [documentation](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html)).

### Behaviour on HoloLens ###
The photo is saved to the camera roll and should be visible in the Photos app on HoloLens as well as the Mixed Reality Tab in the Windows Device Portal.
If an error occurs during saving to camera roll the photo is saved to *LocalAppData\hololens-photocapture_VERSION_x86_ID\LocalState*.

## Requirements ##

* Visual Studio 2015 Update 3
* Unity 5.5.2f1 (used for this project) with Windows Store support
* at least Windows SDK 10.0.10240.0

## Build ##

* HoloToolkit > Configure > Apply HoloLens Project Settings
* HoloToolkit > Build Window > Build Visual Studio SLN 

**OR**

+ Unity > File > Build settings
	* Switch to Platform to *Windows Store*
	* SDK: Universal 10 
	* Target device: Any device
	* UWP Build Type: D3D
	* UWP SDK: Latest
	* C# Unity Projects: check
* Build

## Troubleshooting ##

#### The image is not saved to camera roll ####
Make sure you have *PicturesLibrary* selected in Unity under Edit > Project settings > Player > Publishing settings > Capabilites.
Also make sure that in the generated Visual Studio Solution all the specified capabilites are correct. These can be found in the package.appxmanifest under the Capabilites tab.