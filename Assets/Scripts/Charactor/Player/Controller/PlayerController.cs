using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public CameraControl cameracontrol;
    public Animator animator;

    [Header("Ground Check")]
    public bool isGround;
    public float groundAngle;
    public Vector3 groundNormal { get; private set; }

    [Header("Movement")]
    public bool ProjectMoveOnGround;
    private Vector3 moveVelocity;

    [Header("Slope and inertia")]
    public float slopeLimit = 45;
    public float inertiaDampingTime = 0.1f;
    public float slopeStartForce = 3f;
    public float slopeAcceleration = 3f;
    [HideInInspector] public Vector3 moveInput;

    public Vector3 inertiaVelocity;

    [Header("interaction with the platform")]
    public bool platformAction;
    public Vector3 platformVelocity;

    [Header("Collision")]
    public bool applyCollision = true;
    public float pushForce = 55f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerShake();
        }
    }
    public void PlayerControl()
    {
        GroundCheck();

        if (isGround)
        {
            moveVelocity = ProjectMoveOnGround ? Vector3.ProjectOnPlane(moveInput, groundNormal) : moveInput;

            if (groundAngle < slopeLimit && inertiaVelocity != Vector3.zero) InertiaDamping();
        }

        GravityUpdate();

        Vector3 moveDirection = (moveVelocity + inertiaVelocity + platformVelocity);

        characterController.Move((moveDirection) * Time.deltaTime);
    }
    private void GravityUpdate()
    {
        if (isGround && groundAngle > slopeLimit)
        {
          
            inertiaVelocity += Vector3.ProjectOnPlane(groundNormal.normalized + (Vector3.down * (groundAngle / 30)).normalized * Mathf.Pow(slopeStartForce, slopeAcceleration), groundNormal) * Time.deltaTime;
          
        }
        else if(isGround)
        {
            inertiaVelocity.x = 0;
            inertiaVelocity.z = 0;
        }
        else if (!isGround) inertiaVelocity.y -= Mathf.Pow(3f, 3) * Time.deltaTime;
    }

    private void InertiaDamping()
    {
        var a = Vector3.zero;

        //inertia braking when the force of movement is applied
        var resistanceAngle = Vector3.Angle(Vector3.ProjectOnPlane(inertiaVelocity, groundNormal),
        Vector3.ProjectOnPlane(moveVelocity, groundNormal));

        resistanceAngle = resistanceAngle == 0 ? 90 : resistanceAngle;

        inertiaVelocity = (inertiaVelocity + moveVelocity).magnitude <= 0.1f ? Vector3.zero : Vector3.SmoothDamp(inertiaVelocity, Vector3.zero, ref a, inertiaDampingTime / (3 / (180 / resistanceAngle)));
    }

    private void GroundCheck()
    {
        if (Physics.SphereCast(transform.position, characterController.radius, Vector3.down, out RaycastHit hit, characterController.height / 2 - characterController.radius + 0.1f))
        {
            isGround = true;
            groundAngle = Vector3.Angle(Vector3.up, hit.normal);
            groundNormal = hit.normal;

            if (hit.transform.tag == "Platform")
            {
                transform.parent = hit.transform;
            }
            else
            {
                transform.parent = null;
            }
                //platformVelocity = hit.collider.attachedRigidbody == null | !platformAction ?
                // Vector3.zero : hit.collider.attachedRigidbody.velocity;

            if (Physics.BoxCast(transform.position, new Vector3(characterController.radius / 2.5f, characterController.radius / 3f, characterController.radius / 2.5f),
                        Vector3.down, out RaycastHit helpHit, transform.rotation, characterController.height / 2 - characterController.radius / 2))
            {
                groundAngle = Vector3.Angle(Vector3.up, helpHit.normal);
            }
        }
        else
        {
            platformVelocity = Vector3.zero;
            isGround = false;
        }
        animator.SetBool(Constant.OnGround, isGround);

    }
    public void PlayerShake()
    {
        cameracontrol.CameShake();
        animator.SetTrigger(Constant.IsShake);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!applyCollision) return;

        Rigidbody body = hit.collider.attachedRigidbody;

        // check rigidbody
        if (body == null || body.isKinematic) return;

        Vector3 pushDir = hit.point - (hit.point + hit.moveDirection.normalized);

        // Apply the push
        body.AddForce(pushDir * pushForce, ForceMode.Force);
    }
}
