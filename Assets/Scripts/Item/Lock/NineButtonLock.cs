using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NineButtonLock : MonoBehaviour
{
    public UnityEvent success;
    public List<ClickButton> clickButtons = new List<ClickButton>();
    public List<int> turns = new List<int>();
    public int currentTurn;
    public int totalButton;
    public string password;
    public string passwordEnter;
    List<int> indexs = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    List<int> currentindex = new List<int>();
    void Start()
    {
        InitPuzzle();
    }
   
   public void InitPuzzle()
    {
        OnActive(false);
        totalButton = turns[currentTurn];
        currentTurn++;
        currentindex = indexs;
        StartCoroutine(CouroutineInitPuzzle());

    }
    IEnumerator CouroutineInitPuzzle()
    {
        yield return new WaitForSeconds(2f);
        int index = Random.Range(0, currentindex.Count);
        password += currentindex[index];
        clickButtons[currentindex[index]].Prepare();
        currentindex.RemoveAt(index);
        totalButton--;
        if (totalButton == 0)
        {
            yield return new WaitForSeconds(2f);
            OnActive(true);
            yield break;
        }
        StartCoroutine(CouroutineInitPuzzle());
    }
    public void CheckLock(int index)
    {
        if (index.ToString() == password[0].ToString())
        {
            clickButtons[index].Correct();
            password =password.Substring(1);
            if (password == null)
            {
                currentTurn++;
                if (currentTurn == turns.Count)
                {
                    success.Invoke();
                }
            }
            
        }
        else
        {
            Error();
        }
    }
    public void OnActive(bool isActive)
    {
        for(int i = 0; i < clickButtons.Count; i++)
        {
            clickButtons[i].OnActive(isActive);
        }
    }
    public void Error()
    {
        for (int i = 0; i < clickButtons.Count; i++)
        {
            clickButtons[i].Error();
        }
    }
}
