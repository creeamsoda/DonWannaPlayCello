using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] public bool isEnterable;
        public void LoadScene()
        {
            SceneManager.LoadScene(sceneName);
        }

        private void Update()
        {
            if (isEnterable)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    LoadScene();
                }
            }
        }
    }
}