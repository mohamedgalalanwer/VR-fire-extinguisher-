using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSetting : MonoBehaviour {

    public static bool joystickConnected;

    public GameObject raycastMovement;
    public GameObject raycastIndicator;

	// Use this for initialization
	void Start () {
        print(Input.GetJoystickNames().Length);
        if (Input.GetJoystickNames().Length == 0f)
        {
            joystickConnected = false;
            raycastMovement.SetActive(true);
            raycastIndicator.SetActive(true);
            print("joystick not connected");
        }
        else
        {
            joystickConnected = true;
            raycastMovement.SetActive(false);
            raycastIndicator.SetActive(false);
            print("joystick connected");
        }
    }
}
