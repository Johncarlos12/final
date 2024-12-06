using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace final
{
    public class GetRankingView : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private GameObject dataContainerPrefab;
        private GetRankingController controller;

        private void Awake()
        {
            controller = GetComponent<GetRankingController>();
        }

        public void Execute()
        {
            controller.Execute(OnCallback);
        }

        private void OnCallback(UserDataModel userDataModel)
        {
            foreach(Transform t in container.GetComponentInChildren<Transform>()) 
            { 
                if(t!=container.transform)
                {
                    Destroy(t.gameObject);
                }
            }

            foreach(UserModel userModel in userDataModel.data)
            {
                GameObject obj = Instantiate(dataContainerPrefab, container.transform);
                obj.GetComponent<DataContainer>().SetData($"{userModel.username} - {userModel.score}");
            }
        }
    }

}