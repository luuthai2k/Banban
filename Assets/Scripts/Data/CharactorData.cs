using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Charactor", menuName = "Charactor/CharactorData")]
public class CharactorData : ScriptableObject
{
  
    [Range(1, 100)]  public float speed;
     public float speedSprint;
    [Range(1, 100)] public float jumpHeight;

}
