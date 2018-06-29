using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndPrint());
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1")|| Input.GetButtonDown("Interact"))
        {
            SceneManager.LoadScene("exemple");

        }
    }
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(45f);
        SceneManager.LoadScene("exemple");

       
    }
}
