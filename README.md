# HoloLens PhotoCapture Sample #


### What is this repository for? ###

This is a sample application for using Unity's PhotoCapture API in combination with HoloLens. Most noticeably, there should be holograms visible in the final image.

The *PhotoManager*, responsible for taking and saving images is being controlled by the following voice commands:

**Take photo:** Takes a photo an saves it.

**Stop camera:**  Stops the camera.

The current status of the camera is visible in the lower right corner.

### Requirements ###

* Visual Studio 2015 Update 3
* Unity 5.5.2f1 (used for this project) with Windows Store support
* at least Windows SDK 10.0.10240.0

### Build ###

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