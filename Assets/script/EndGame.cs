using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {



 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.Escape)) {
            Debug.Log ("Goodbye cruel world!");
            Application.Quit ();
           
        }
    }
    

}
