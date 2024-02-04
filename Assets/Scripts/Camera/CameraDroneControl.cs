using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDroneControl : CameraControl
{
  
    public override void CamControl(float x, float y)
    {
        MouseVerticalValue = y;
        transform.root.rotation = Quaternion.Euler(0, transform.root.localRotation.eulerAngles.y + x * sensitivity, 0);
        transform.localRotation = Quaternion.Euler(-MouseVerticalValue * sensitivity, 0, -tilting*maxHorizontalAngle);
      
    }
}
