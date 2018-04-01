using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour {
	// Use this for initialization
    public static float JumpBeginTime = 0;
    public static float JumpPower = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) 
        {
            JumpBeginTime = Time.time;
            Debug.LogError(JumpBeginTime);
        }
        if (Input.GetButtonUp("Jump")) 
        {
            JumpPower = Time.time - JumpBeginTime;
            Debug.LogError(JumpPower);
        }
	}
}
