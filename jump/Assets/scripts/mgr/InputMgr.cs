using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour {
	// Use this for initialization
    public int JumpBeginTime = 0;
    public int JumpPower = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) 
        {

        }
        if (Input.GetButtonUp("Jump")) 
        {

        }
	}
}
