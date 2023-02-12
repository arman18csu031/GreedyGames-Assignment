using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class Timer : MonoBehaviour
{
    public float gameDuration = 90f;
    public TMP_Text timerText;

    private float startTime;

    private bool isPaused = false;
    public void OnEnable(){
        SceneLoadManager.onTimeReset += ResetTimer;
    }

    public void OnDisable(){
        SceneLoadManager.onTimeReset -= ResetTimer;
    }


    private void Start()
    {
        Utils.instance.timerPaused += PauseTimer;
        ResetTimer();
        
        if (PhotonNetwork.IsMasterClient)
        {
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
            if (playerCount == 2)
            {
                startTime = Time.time;
            }
        }
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if(isPaused){
                return;
            }
            float elapsedTime = Time.time - startTime;
            float timeLeft = gameDuration - elapsedTime;
           

            timerText.text = timeLeft.ToString("0.00");

            if (timeLeft <= 0)
            {
                
                enabled = false;
                PhotonNetwork.DestroyAll();
                Utils.instance.gamePopup.Invoke();
            }
        }
    }

    public void PauseTimer()
    {
        isPaused = true;
    }
    public void ResetTimer(){
            startTime = Time.time;
    }      
}
