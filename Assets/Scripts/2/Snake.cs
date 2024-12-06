using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace final
{
    public class Snake : MonoBehaviour
    {
        public float moveSpeed = 8f; 
        public float rotationSpeed = 180f; 
        public GameObject bodyPrefab; 
        public GameObject foodPrefab; 
        public int initialBody = 3;
        
        private List<GameObject> bodySegments = new List<GameObject>();
        private List<Vector3> positionsHistory = new List<Vector3>();
        public int gap = 10; 
        private int score = 0;
        
        public string nextSceneName;
        
        void Start()
        {
            for (int i = 0; i < initialBody; i++)
            {
                GrowSnake();
            }
            
            SpawnFood();
        }
        
        void Update()
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            
            float rotationDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotationDirection * rotationSpeed * Time.deltaTime);
            
            positionsHistory.Insert(0, transform.position);
            
            int index = 0;
            foreach (var segment in bodySegments)
            {
                Vector3 point = positionsHistory[Mathf.Clamp(index * gap, 0, positionsHistory.Count - 1)];
                Vector3 moveDirection = point - segment.transform.position;
                segment.transform.position += moveDirection * moveSpeed * Time.deltaTime;
                segment.transform.LookAt(point);
                index++;
            }
        }
        
        private void GrowSnake()
        {
            Vector3 spawnPosition = transform.position - transform.forward * gap * 0.1f;
            if (bodySegments.Count > 0)
            {
                spawnPosition = bodySegments[bodySegments.Count - 1].transform.position;
            }
            
            GameObject newSegment = Instantiate(bodyPrefab, spawnPosition, Quaternion.identity);
            
            newSegment.tag = "Body";
            bodySegments.Add(newSegment);
        }
            
        private void SpawnFood()
        {
            Vector3 randomPosition = new Vector3(Random.Range(-9, 9), 0.5f, Random.Range(-9, 9));
            Instantiate(foodPrefab, randomPosition, Quaternion.identity);
        }
            
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Food"))
            {
                Destroy(other.gameObject);
                GrowSnake();
                SpawnFood();
                score++;
            }
                    
            if (other.gameObject.CompareTag("Body"))
            {
                GameOver();
            }
        }
            
        private void GameOver()
        {
             SceneManager.LoadScene(nextSceneName);  
        }
    }
}




