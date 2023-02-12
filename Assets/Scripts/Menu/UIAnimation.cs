using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIAnimation : MonoBehaviour
{
    //public GameObject snake;
    public GameObject logo;
    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.rotateZ(snake, gameObject.transform.position.z + 0.01f, 2f).setEase(LeanTweenType.easeInOutSine).setLoopPingPong();
        LeanTween.scale(logo, new Vector3(1.4f, 1.4f, 1.4f), 1f).setEase(LeanTweenType.easeInOutBack).setLoopPingPong();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
