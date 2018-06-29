using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenuLevel
{
    public class LoadLevelAsyncBehaviour : MonoBehaviour
    {
        public int scene;
        public Slider[] progressbars;
        public GameObject button;

        public bool startLevel;

        // Use this for initialization
        void Start()
        {
            startLevel = false;
        }

        public void LoadScneAsync()
        {
            StartCoroutine(AsynchronousLoad(scene));

        }

        public void Play()
        {
            startLevel = true;
        }

        IEnumerator AsynchronousLoad(int scene)
        {
            yield return null;

            AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
            ao.allowSceneActivation = false;

            while (!ao.isDone)
            {
                // [0, 0.9] > [0, 1]
                float progress = Mathf.Clamp01(ao.progress / 0.9f);

                foreach (var bar in progressbars)
                {
                    bar.value = progress;
                }

                // Loading completed
                if (ao.progress == 0.9f)
                {
                    button.SetActive(true);
                    foreach (var bar in progressbars)
                    {
                        bar.gameObject.SetActive(false);
                    }

                    if (startLevel)
                        ao.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
