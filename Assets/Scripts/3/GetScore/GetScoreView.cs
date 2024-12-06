using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace final
{
    public class GetScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI oldScoreText;
        [SerializeField] private TextMeshProUGUI newScoreText;
        [SerializeField] private TextMeshProUGUI usernameText;
        private GetScoreController controller;


        private void Awake()
        {
            controller = GetComponent<GetScoreController>();
            controller.Execute(GameData.username, OnCallback);

        }

        private void OnCallback(GetScoreModel data)
        {
            if (data.message=="success")
            {
                oldScoreText.text = $"Old Score: {data.score}";
            }
            else
            {
                oldScoreText.text = $"Old Score: -";
            }
            newScoreText.text = $"New Score: {Food.score}";
            usernameText.text = $"Username: {GameData.username}";
        }        
    }

}