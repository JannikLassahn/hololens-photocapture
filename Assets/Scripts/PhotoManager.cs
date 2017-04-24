using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.VR.WSA.WebCam;

/// <summary>
/// Manages taking and saving photos.
/// </summary>
public class PhotoManager : MonoBehaviour
{
    /// <summary>
    /// Displays status information of the camera.
    /// </summary>
    public TextMesh Info;

    /// <summary>
    /// Actual camera instance.
    /// </summary>
    private PhotoCapture capture;

    /// <summary>
    /// True, if the camera is ready to take photos.
    /// </summary>
    private bool isReady = false;

    private void Start()
    {
        Assert.IsNotNull(Info, "The PhotoManager requires a text mesh.");

        Info.text = "Camera off";
        PhotoCapture.CreateAsync(true, OnPhotoCaptureCreated);
    }

    private void OnPhotoCaptureCreated(PhotoCapture captureObject)
    {
        capture = captureObject;

        Resolution resolution = PhotoCapture.SupportedResolutions.OrderByDescending(res => res.width * res.height).First();

        CameraParameters c = new CameraParameters(WebCamMode.PhotoMode);
        c.hologramOpacity = 1.0f;
        c.cameraResolutionWidth = resolution.width;
        c.cameraResolutionHeight = resolution.height;
        c.pixelFormat = CapturePixelFormat.BGRA32;

        capture.StartPhotoModeAsync(c, OnPhotoModeStarted);
    }

    private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
    {
        isReady = result.success;
        Info.text = "Camera ready";
    }


    /// <summary>
    /// Take a photo and save it to a temporary application folder.
    /// </summary>
    public void TakePhoto()
    {
        if (isReady)
        {
            string file = string.Format(@"Image_{0:yyyy-MM-dd_hh-mm-ss-tt}.jpg", DateTime.Now);
            string path = System.IO.Path.Combine(Application.persistentDataPath, file);

            capture.TakePhotoAsync(path, PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
        }
        else
        {
            Debug.LogWarning("The camera is not yet ready.");
        }
    }

    /// <summary>
    /// Stop the photo mode.
    /// </summary>
    public void StopCamera()
    {
        if (isReady)
        {
            capture.StopPhotoModeAsync(OnPhotoModeStopped);
        }
    }

    private void OnCapturedPhotoToDisk(PhotoCapture.PhotoCaptureResult result)
    {
        if (result.success)
        {
            Info.text = "saved photo";
            Debug.Log("Saved image at " + Application.persistentDataPath);
        }
        else
        {
            Info.text = "failed to save photo";
            Debug.LogWarning(string.Format("Failed to save photo to disk ({0})", result.hResult));
        }
    }

    private void OnPhotoModeStopped(PhotoCapture.PhotoCaptureResult result)
    {
        capture.Dispose();
        capture = null;
        isReady = false;

        Info.text = "Camera off";
    }

}