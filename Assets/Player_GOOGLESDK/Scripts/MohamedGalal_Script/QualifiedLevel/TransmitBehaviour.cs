using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QualifiedLevel
{
    public class TransmitBehaviour : MonoBehaviour
    {

        public string sceneName;

        // Use this for initialization
        void Start()
        {
            Invoke("_LoadScene", 10f);
        }

        private void _LoadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }
    }
}
