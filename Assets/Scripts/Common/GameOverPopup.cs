using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPopup : MonoBehaviour
{
    public Canvas canvas;
    public GameObject gameOverScreen;
     public float animationTime = 1f;

    public TMP_Text txt;
    private int score;
     private void Start(){
        Utils.instance.gamePopup += PopUp;
        Utils.instance.score += Scoring;
     }
    void PopUp()
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector3 canvasCenter = canvasRect.TransformPoint(canvasRect.rect.center);
        LeanTween.move(gameOverScreen, canvasCenter, animationTime).setEase(LeanTweenType.easeInOutQuad);
    }
    void Scoring(){
        score += 1;
        txt.text = score.ToString();
    }
}
