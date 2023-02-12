using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Button_bg b1, b2;

    public void B1(){
        b1.isActive = true;
        b2.isActive = false;
        
        
        b2.buttonRect.gameObject.SetActive(false);
       
    }
    public void B2(){
        b1.isActive = false;
        b2.isActive = true;
        
        b1.buttonRect.gameObject.SetActive(false);
        
    }
}
