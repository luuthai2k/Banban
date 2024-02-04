using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class LoadChapter : MonoBehaviour
{
    public static LoadChapter ins;
    private string chaptername;
    public int maxindex;
    public int curentindex;
    public int selectindex;
    public AsyncOperationHandle<GameObject> chapter;
    public List<GameObject> chapterObj = new List<GameObject>();
    private void Awake()
    {
        ins = this;
    }
    public void Start()
    {
        curentindex = 1;
        DontDestroyOnLoad(this);
        LoadGameObject();
    }
    public void LoadGameObject()
    {
        chaptername = "Chapter" + curentindex;
        chapter = Addressables.LoadAssetAsync<GameObject>(chaptername);
        chapter.Completed += OnChapterLoadComplete;
    }
    private void OnChapterLoadComplete(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            chapterObj.Add(obj.Result);
            if (curentindex < maxindex)
            {
                curentindex++;
                LoadGameObject();
            }
           
        }
        else
        {

            LoadGameObject();
        }
    }
    public void SelectChapter()
    {
        selectindex = 0;
    }
    public void Loadchapter()
    {
        Instantiate(chapterObj[selectindex]);
    }

}
