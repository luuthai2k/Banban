using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene(Constant.MainScene);

    }
    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene(Constant.GamePlay);
    }
}
