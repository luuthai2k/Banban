using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player ins;
    public ControlState controlState;
    public PlayerInput playerInput;
    private InputControl inputControl;
    private CameraControllerManager cameraController;
    public PlayerController playerController;
    public DroneController droneController;
    public Transform handTransform;
    public bool canControl;
    private void Awake()
    {
        if (ins != null)
        {
            ins = null;
        }
        ins = this;
    }
    void Start()
    {
        canControl = true;
        CheckInputControl();
        CheckCameraController();
    }
    private void OnEnable()
    {
        canControl = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!canControl) return;
        HandleState();
        switch (controlState)
        {
            case ControlState.PlayerControl:
                playerController.PlayerControl();
                break;
            case ControlState.DroneControl:
                droneController.DroneControl();
                break;
        }
#if UNITY_EDITOR
        HandleInput();
#endif

    }
    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F)&&inputControl.pickUp.gameObject.activeSelf)
        {
            inputControl.pickUp.PickUpItem();
        }
    }
    void CheckInputControl()
    {
        inputControl = UIManager.ins.inputControl;
    }
    void CheckCameraController()
    {
        cameraController = GameManager.ins.cameraController;
    }
    public void HandleState()
    {
        if (inputControl == null)
        {
            CheckInputControl();
            return;
        }
        if (inputControl.isDrone)
        {
            ChangeState(ControlState.DroneControl);
        }
        else
        {
            ChangeState(ControlState.PlayerControl);
        }
    }
    public void ChangeState(ControlState _controlState)
    {
        if (controlState == _controlState) return;
        if (inputControl == null)
        {
            CheckInputControl();
        }
        if (_controlState == ControlState.PlayerControl)
        {
            inputControl.playerControl.SetActive(true);
            droneController.FinishControl();
            ChangeCameraControl(playerController.cameracontrol);
        }
        else
        {
            droneController.StartControl();
            inputControl.playerControl.SetActive(false);
            ChangeCameraControl(droneController.cameracontrol);
        }
        controlState = _controlState;

    }
    void ChangeCameraControl(CameraControl _cameraControl)
    {
        if (cameraController == null)
        {
            CheckCameraController();
        }
        cameraController.ChangeCamera(_cameraControl);
    }
    public void IsDie()
    {
        canControl = true;
        UIManager.ins.OnDead(true);
    }



   
}
