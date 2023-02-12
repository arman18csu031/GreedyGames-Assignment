using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Utils : MonoBehaviour
{
    public static Utils instance;
    public UnityAction gamePopup;
    public UnityAction score;
   // public UnityAction foodSpawn;
    public UnityAction timerPaused;
   
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
}
