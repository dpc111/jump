using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class PersonCharacter : MonoBehaviour
{
    [SerializeField]
    float mJumpPower = 12f;
    [SerializeField]
    float mGroundCheckDistance = 0.1f;

    Rigidbody mRigidbody;
    Animator mAnimator;
    bool mIsGrounded;
    Vector3 mGroundNormal;
    CapsuleCollider mCapsule;


    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mRigidbody = GetComponent<Rigidbody>();
        mCapsule = GetComponent<CapsuleCollider>();
        mRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }


    public void Move(Vector3 move, bool jump)
    {
        if (move.magnitude > 1f)
        {
            move.Normalize();
        }
        transform.Translate(move * 0.1f);
        if (jump)
        {
            mRigidbody.velocity += new Vector3(0, 5, 1);
        }
    }

    void HandleGroundedMovement(bool crouch, bool jump)
    {
        if (jump && !crouch && mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
        {
            mRigidbody.velocity = new Vector3(mRigidbody.velocity.x, mJumpPower, mRigidbody.velocity.z);
            mIsGrounded = false;
            mAnimator.applyRootMotion = false;
            mGroundCheckDistance = 0.1f;
        }
    }

    void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * mGroundCheckDistance));
#endif
        if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, mGroundCheckDistance))
        {
            mGroundNormal = hitInfo.normal;
            mIsGrounded = true;
            mAnimator.applyRootMotion = true;
        }
        else
        {
            mIsGrounded = false;
            mGroundNormal = Vector3.up;
            mAnimator.applyRootMotion = false;
        }
    }
}
