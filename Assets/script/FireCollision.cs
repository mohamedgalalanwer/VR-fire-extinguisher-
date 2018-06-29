using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCollision : MonoBehaviour {
    public ParticleSystem system;
    public GameObject smoke;
   public static  int index = 0;
    public Text scoreTxt;
    Collider col;
 public GameObject water;
    private void Start()
    {
        col = GetComponent<Collider>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    GameLogic.inside = true;
    //    water.GetComponent<EllipsoidParticleEmitter>().emit = true;

    //}
    void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player"&& GameLogic.inside == true) 
        {
           
            //fire stop
            system.Stop();
            smoke.SetActive(true);
       // water.GetComponent<EllipsoidParticleEmitter>().emit = false;
            Debug.Log("fire destrroy");
      
        }
       // index = index + 1;


    }

    private void OnTriggerExit(Collider other)
    {
       
            GameLogic.inside = false;
        scoreTxt.text = "fire : " + GameLogic.score ++;
    water.GetComponent<EllipsoidParticleEmitter>().emit = false;
        //col.enabled = false;
    }
}
