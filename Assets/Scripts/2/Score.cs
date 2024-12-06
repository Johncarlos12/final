using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace final
{
    public class Score : MonoBehaviour
    {
        public TMP_Text scoreText;

        void Update()
        {
            scoreText.text = "Score: " + Food.score;
        }
    }
}
