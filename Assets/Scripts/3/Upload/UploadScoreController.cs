using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace final
{
    public class UploadScoreController : MonoBehaviour
    {
        public void Execute(string username, int score ,Action<MessageModel> OnCallback)
        {
            StartCoroutine(SendRequest(username, score, OnCallback));
        }

        IEnumerator SendRequest(string username, int score, Action<MessageModel> OnCallback)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("score", score);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/programacion/final/upload_score.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ProtocolError ||
                    www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error!");
                }
                else
                {
                    OnCallback?.Invoke(JsonUtility.FromJson<MessageModel>(www.downloadHandler.text));
                }
            }
        }
    }

}