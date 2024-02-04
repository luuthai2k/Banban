using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ElectricLock : MonoBehaviour
{
    public UnityEvent success;
    public string password;
    public Text passwordDisplayed;
 

    private void Start()
    {
        
    }
    public void CheckPassword(string i)
    {
      
        passwordDisplayed.text += i;
        if (passwordDisplayed.text.Length == password.Length)
        {
            if (passwordDisplayed.text == password)
            {
                Success();
            }
            else
            {
                Defeat();
            }
        }
       
    }
    public void Success()
    {
        success.Invoke();
    }
    public void Defeat()
    {
        passwordDisplayed.text = null;
    }


}
