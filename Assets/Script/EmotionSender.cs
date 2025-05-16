using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class EmotionSender : MonoBehaviour
{
    public CameraFeed cameraFeed;

    [Serializable]
    public class ImageData { public string image; }

    [Serializable]
    public class EmotionResponse { public string emotion; }

    public IEnumerator SendToPython(Action<string> callback)
    {
        Texture2D frame = cameraFeed.CaptureFrame();
        byte[] imageBytes = frame.EncodeToPNG();
        string base64 = Convert.ToBase64String(imageBytes);
        ImageData img = new ImageData { image = base64 };

        string json = JsonUtility.ToJson(img);
        UnityWebRequest request = new UnityWebRequest("http://127.0.0.1:5000/detect_emotion", "POST");
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            EmotionResponse response = JsonUtility.FromJson<EmotionResponse>(request.downloadHandler.text);
            callback?.Invoke(response.emotion);
        }
        else
        {
            Debug.LogError("Emotion detection error: " + request.error);
            callback?.Invoke("Error");
        }
    }
}
