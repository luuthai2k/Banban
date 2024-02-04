using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickButton : Item
{
    public NineButtonLock nineButtonLock;
    public MeshRenderer meshRenderer;
    public Collider m_collider;
    public Transform buttonTransform;
    public float range;
    private Material originalMaterial;
    public Material prepareMaterial;
    public Material correctMaterial;
    public Material errorMaterial;
    public bool canselect;
    private void Start()
    {
        originalMaterial = meshRenderer.material;
    }
    public void Prepare()
    {
        meshRenderer.material = prepareMaterial;
        StartCoroutine(CouroutinePrepare());
    }
    IEnumerator CouroutinePrepare()
    {
        yield return new WaitForSeconds(1);
        meshRenderer.material = originalMaterial;
    }
    public override void Select()
    {
        nineButtonLock.CheckLock(id);
       
    }
    public void Correct()
    {
        meshRenderer.material = correctMaterial;
        buttonTransform.DOLocalMoveZ(range, 0.5f)
           .OnComplete(() =>
           {

               buttonTransform.DOLocalMoveZ(0, 0.5f)
                .OnComplete(() =>
                {

                    meshRenderer.material = originalMaterial;
                });
           });
    }
    public void Error()
    {
        meshRenderer.material = errorMaterial;
        buttonTransform.DOLocalMoveZ(range,0.5f)
           .OnComplete(() =>
           {

               buttonTransform.DOLocalMoveZ(0, 0.5f)
                .OnComplete(() =>
                {

                    meshRenderer.material = originalMaterial;
                });
           });

    }
    public virtual void OnActive(bool isActive)
    {
        m_collider.enabled = isActive;
    }

}
