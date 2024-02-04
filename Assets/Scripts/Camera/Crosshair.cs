using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public static Crosshair ins;
    public GameObject Item;
    [SerializeField]private Camera _camera;
    public float maxdis;
    Ray ray;
    private void Awake()
    {
        ins = this;
    }

    private void Update()
    {
        ray.origin = _camera.transform.position;
        ray.direction = _camera.transform.forward;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, maxdis))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer(Constant.Item))
            {
                Item = raycastHit.collider.transform.parent.gameObject;
                UIManager.ins.inputControl.OnPickUp(true);
                return;
            }
            UIManager.ins.inputControl.OnPickUp(false);
        }
        else
        {
            UIManager.ins.inputControl.OnPickUp(false);
        }

    }
}
