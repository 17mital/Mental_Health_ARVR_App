using UnityEngine;
using UnityEngine.UI;

public class CameraFeed : MonoBehaviour
{
    public RawImage rawImageDisplay;
    private WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // Use the first front-facing camera
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                webcamTexture = new WebCamTexture(devices[i].name);
                break;
            }
        }

        if (webcamTexture == null)
        {
            webcamTexture = new WebCamTexture(); // fallback
        }

        rawImageDisplay.texture = webcamTexture;
        rawImageDisplay.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    public Texture2D CaptureFrame()
    {
        Texture2D tex = new Texture2D(webcamTexture.width, webcamTexture.height);
        tex.SetPixels(webcamTexture.GetPixels());
        tex.Apply();
        return tex;
    }
}
