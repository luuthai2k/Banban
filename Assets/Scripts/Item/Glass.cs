using UnityEngine;
using System.Collections.Generic;

public class Glass : MonoBehaviour ,ICollisionDrone
{
	public List<GameObject> BrokenGlassGO;
	GameObject BrokenGlassInstance; 
	public bool BreakSound=true;
	public GameObject SoundEmitter; 
	public float SoundEmitterLifetime=2.0f;
	public float ShardsLifetime=3.0f; 
	public float ShardMass=0.5f;
	public Material ShardMaterial;


    public void OnConllisonDrone()
	{
		BreakIt();

    }
   
    public void BreakIt()
	{
		BrokenGlassInstance = Instantiate(BrokenGlassGO[Random.Range(0,BrokenGlassGO.Count)], transform.position, transform.rotation) as GameObject;
		BrokenGlassInstance.transform.localScale = transform.lossyScale;
		
		foreach(Transform t in BrokenGlassInstance.transform){
			t.GetComponent<Renderer>().material = ShardMaterial;
			t.GetComponent<Rigidbody>().mass=ShardMass;
		}
		
		if(BreakSound) Destroy(Instantiate(SoundEmitter, transform.position, transform.rotation) as GameObject, SoundEmitterLifetime);
		
		if(ShardsLifetime>0) Destroy(BrokenGlassInstance,ShardsLifetime);
		gameObject.SetActive(false);
	}

}
