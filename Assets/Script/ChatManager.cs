using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

[System.Serializable]
public class ChatResponse
{
    public string response;
}

public class ChatManager : MonoBehaviour
{
    public GameObject chatUI;
    public TMP_InputField userInputField;
    public TMP_Text responseText;

    void Start()
    {
        chatUI.SetActive(true);
    }

    public void OnSendClicked()
    {
        string msg = userInputField.text;
        if (!string.IsNullOrEmpty(msg))
        {
            StartCoroutine(SendToServer(msg));
        }
    }

    IEnumerator SendToServer(string message)
    {
        WWWForm form = new WWWForm();
        form.AddField("message", message);
        string url = "http://192.168.65.198:5000/analyze"; // Use your correct IP here

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string jsonReply = www.downloadHandler.text;
            Debug.Log("Raw server response: " + jsonReply);

            ChatResponse chatRes = JsonUtility.FromJson<ChatResponse>(jsonReply);
            if (chatRes != null && !string.IsNullOrEmpty(chatRes.response))
            {
                responseText.text = chatRes.response;
            }
            else
            {
                responseText.text = "Unexpected server response.";
            }
        }
        else
        {
            Debug.LogError("UnityWebRequest Error: " + www.error);
            responseText.text = "Server error. Please try again.";
        }

        userInputField.text = "";
    }
}
