using System;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PersonCharacter))]
public class PersonControl : MonoBehaviour
{
    private PersonCharacter mCharacter;        // A reference to the ThirdPersonCharacter on the object
    private Transform mCam;                    // A reference to the main camera in the scenes transform
    private Vector3 mCamForward;               // The current forward direction of the camera
    private Vector3 mMove;
    private bool mJump;                        // the world-relative desired move direction, calculated from the camForward and user input.

    private void Start()
    {
        if (Camera.main != null)
        {
            mCam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("");
        }
        mCharacter = GetComponent<PersonCharacter>();
    }

    private void Update()
    {
        if (!mJump)
        {
            //mJump = CrossPlatformInputManager.GetButtonDown("Jump");
            //mJump = Input.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //float v = CrossPlatformInputManager.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool j = Input.GetButtonDown("Jump");
        Debug.Log(h + " " + v);
        if (mCam != null)
        {
            mCamForward = Vector3.Scale(mCam.forward, new Vector3(1, 0, 1)).normalized;
            mMove = v * mCamForward + h * mCam.right;
        }
        else
        {
            mMove = v * Vector3.forward + h * Vector3.right;
        }
#if !MOBILE_INPUT
        if (Input.GetKey(KeyCode.LeftShift)) mMove *= 0.5f;
#endif
        mCharacter.Move(mMove, j);
        //mJump = false;
    }
}
