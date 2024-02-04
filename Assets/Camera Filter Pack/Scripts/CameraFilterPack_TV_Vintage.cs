///////////////////////////////////////////
//  CameraFilterPack - by VETASOFT 2020 ///
///////////////////////////////////////////

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu ("Camera Filter Pack/TV/Vintage")]
public class CameraFilterPack_TV_Vintage : MonoBehaviour {
#region Variables
public Shader SCShader;
private float TimeX = 1.0f;
[Range(1, 10)]
public float Distortion = 1.0f;
private Material SCMaterial;


#endregion

#region Properties
Material material
{
get
{
if(SCMaterial == null)
{
SCMaterial = new Material(SCShader);
SCMaterial.hideFlags = HideFlags.HideAndDontSave;	
}
return SCMaterial;
}
}
#endregion
void Start () 
{

SCShader = Shader.Find("CameraFilterPack/TV_Vintage");

if(!SystemInfo.supportsImageEffects)
{
enabled = false;
return;
}
}

void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
{
if(SCShader != null)
{
TimeX+=Time.deltaTime;
if (TimeX>100)  TimeX=0;
material.SetFloat("_TimeX", TimeX);
material.SetFloat("_Distortion", Distortion);

Graphics.Blit(sourceTexture, destTexture, material);

}
else
{
Graphics.Blit(sourceTexture, destTexture);	
}


}

// Update is called once per frame
void Update () 
{

#if UNITY_EDITOR
if (Application.isPlaying!=true)
{
SCShader = Shader.Find("CameraFilterPack/TV_Vintage");

}
#endif

}

void OnDisable ()
{
if(SCMaterial)
{
DestroyImmediate(SCMaterial);
//RenderTexture.ReleaseTemporary(intermediateRT);
}

}


}