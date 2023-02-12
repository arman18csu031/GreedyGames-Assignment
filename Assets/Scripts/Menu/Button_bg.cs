using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_bg : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject buttonRect;
    public bool isActive = false;
    
    public Button button;

    private void Start(){
        
        buttonRect.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {   
            buttonRect.SetActive(true);    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            if(isActive){
                buttonRect.SetActive(true);
            }
            else{
                  buttonRect.SetActive(false); 
            }       
    }
}
    


