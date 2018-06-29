using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public GameObject water;
    public static bool inside;
    public static int score;
    public GameObject cong;
   
  //  public static int ins;

    //
    void Start () {

        score = 0;
      //  water.GetComponent<EllipsoidParticleEmitter>().emit = false;
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Interact"))
        {
            inside = true;
            water.GetComponent<EllipsoidParticleEmitter>().emit = true;


            Debug.Log("  inside = true;");


        }

        if (Input.GetButtonUp("Fire1") || Input.GetButtonDown("Interact"))
        {

            water.GetComponent<EllipsoidParticleEmitter>().emit = false;


            }
            if (score>=18)
        {
            cong.SetActive(true);
            StartCoroutine(WaitAndPrint());
        }


    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(15f);
        Application.Quit();
        //print("WaitAndPrint " + Time.time);
    }
}
