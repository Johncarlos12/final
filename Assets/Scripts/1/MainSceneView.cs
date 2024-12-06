using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace final
{
    public class MainSceneView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField usernameInputField;
        [SerializeField] private Button nivel1Button; // Botón para Nivel 1
        [SerializeField] private Button nivel2Button; // Botón para Nivel 2

        [SerializeField] private string nivel1SceneName; // Nombre de la escena para Nivel 1
        [SerializeField] private string nivel2SceneName; // Nombre de la escena para Nivel 2

        private void Awake()
        {
            nivel1Button.onClick.AddListener(() => LoadScene(nivel1SceneName));
            nivel2Button.onClick.AddListener(() => LoadScene(nivel2SceneName));
        }

        private void LoadScene(string sceneName)
        {
            if (usernameInputField.text.Length > 0)
            {
                GameData.username = usernameInputField.text; // Guardar nombre de usuario
                SceneManager.LoadScene(sceneName); // Cambiar a la escena seleccionada
            }
        }
    }
}
