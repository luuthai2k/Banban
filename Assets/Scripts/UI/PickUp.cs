using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject CrosshairSensor;
    private Crosshair crosshair;
    private void Start()
    {
        gameObject.SetActive(false);
        crosshair = Crosshair.ins;
    }
    private void OnEnable()
    {
        CrosshairSensor.SetActive(true);
    }
    public void PickUpItem()
    {
        crosshair.Item.GetComponent<Item>().Select();
    }
    private void OnDisable()
    {
        CrosshairSensor.SetActive(false);
    }
}
