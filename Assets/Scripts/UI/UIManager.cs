using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager ins;
    public InputControl inputControl;
    public Pause pause;
    public DeadUI deadUI;
    public GameObject complete;
    public void LoadMainScene()
    {
        SceneManager.LoadScene(Constant.MainScene);

    }
    void Awake()
    {
        if (ins != null)
        {
            ins = null;
        }
        ins = this;
    }

  public void OnUI(bool isActive)
    {
        gameObject.SetActive(isActive);

    }
    public void OnPLayerControl(bool isActive)
    {
        inputControl.playerControl.SetActive(isActive);
    }
    public void OnDroneControl(bool isActive)
    {
        inputControl.drone.SetActive(isActive);
        inputControl.teleport.gameObject.SetActive(isActive);
    }
    public void OnPause(bool isActive)
    {
        pause.gameObject.SetActive(isActive);
    }
    public void SetScaleTime(int time)
    {
        Time.timeScale = time;
    }
    public void OnDead(bool isActive)
    {
        deadUI.gameObject.SetActive(isActive);
    }
    public void OnComplete(bool isActive)
    {
        complete.SetActive(isActive);
    }
}
