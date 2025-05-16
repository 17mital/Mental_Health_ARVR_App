using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GestureReceiver : MonoBehaviour
{
    public string serverUrl = "http://localhost:5000/gesture";
    public Animator butterflyAnimator;

    void Start()
    {
        StartCoroutine(CheckGestureLoop());
    }

    IEnumerator CheckGestureLoop()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get(serverUrl);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                string json = www.downloadHandler.text;
                if (json.Contains("open_palm"))
                {
                    Debug.Log("Open palm detected!");
                    butterflyAnimator.SetBool("isFlying", true);
                }
                else if (json.Contains("closed_palm"))
                {
                    Debug.Log("Closed palm detected!");
                    butterflyAnimator.SetBool("isFlying", false);
                }
                else
                {
                    butterflyAnimator.SetBool("isFlying", false); // default to idle
                }
            }

            yield return new WaitForSeconds(0.5f); // Check every 0.5 sec
        }
    }
}
