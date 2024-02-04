using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public CameraControl cameracontrol;
    public float speed;
    public float speedSprint;
    private float currenspeed;
    public CharacterController characterController;
    private bool isActive;
    public Animator animator;
    private InputControl inputControl;
    Vector3 moveDirection;
    private Transform cameraTransform;
    public float max_AngleZ = 20;

    private void Start()
    {
        currenspeed = speed;
        isActive = PlayerPrefs.GetInt("IsDroneActive") > 0;
        inputControl = UIManager.ins.inputControl;
        cameraTransform = cameracontrol.transform;
    }
   
    public void SetActiveDrone(bool isActive)
    {
        animator.enabled = true;
        animator.SetTrigger("isActive");
        isActive = true;


    }
    public void DroneControl()
    {
      
#if UNITY_EDITOR
        moveDirection = cameraTransform.forward * Input.GetAxis(Constant.Vertical) + transform.right * Input.GetAxis(Constant.Horizontal);
        cameracontrol.tilting = Mathf.SmoothStep(cameracontrol.tilting,Input.GetAxis(Constant.Horizontal),0.1f);

#else
		moveDirection = cameraTransform.forward * inputControl.joystick.Vertical + transform.right * inputControl.joystick.Horizontal;
        cameracontrol.tilting = Mathf.SmoothStep(cameracontrol.tilting,inputControl.joystick.Horizontal,2);
#endif
        characterController.Move(moveDirection * currenspeed * Time.deltaTime);
        
    }
    public void StartControl()
    {
        characterController.enabled = true;
    }
  public void FinishControl()
    {
        characterController.enabled = false;
        StartCoroutine(ReturnToBalance());
    }
    IEnumerator ReturnToBalance()
    {
        float time = 0;
        Quaternion balanceAngle = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        while (time < 1)
        {
            time += Time.deltaTime;
            cameraTransform.localRotation = Quaternion.Lerp(cameraTransform.localRotation, balanceAngle, time);
            yield return null;
        }
        yield break;

    }
     IEnumerator CouroutineStartEngine( Vector3 _target,float _time)
    {
        float time = 0;
        Vector3 pos = transform.position;
        while (time < _time)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(pos, _target, time / _time);
            yield return null;
        }
        inputControl.canControlDrone = true;
    }
    public void StartEngine( float _time)
    {
        animator.SetTrigger(Constant.isActive);
        StartCoroutine(CouroutineStartEngine(PointManager.ins.droneTargetStartPoint.position, _time));
    }


}
