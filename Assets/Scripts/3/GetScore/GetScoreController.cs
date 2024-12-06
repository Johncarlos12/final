using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace final
{
    public class GetScoreController : MonoBehaviour
    {
        public void Execute(string username, Action<GetScoreModel> OnCallback)
        {
            StartCoroutine(SendRequest(username, OnCallback));
        }

        IEnumerator SendRequest(string username, Action<GetScoreModel> OnCallback)
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/programacion/final/get_score.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ProtocolError ||
                    www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log("Error!");
                }
                else
                {
                    OnCallback?.Invoke(JsonUtility.FromJson<GetScoreModel>(www.downloadHandler.text));
                }
            }
        }
    }
}