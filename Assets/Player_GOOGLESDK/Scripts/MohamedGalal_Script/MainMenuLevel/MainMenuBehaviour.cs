using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenuLevel
{
    public class MainMenuBehaviour : MonoBehaviour
    {

        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
