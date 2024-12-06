using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

namespace final
{
    public class Food : MonoBehaviour
    {
        public int value = 10; 
        public static int score = 0; 
        public string nextSceneName; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Snake"))
            {
                score += value;

                if (score >= 100)
                {
                    ChangeScene(); 
                }
            }
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}




