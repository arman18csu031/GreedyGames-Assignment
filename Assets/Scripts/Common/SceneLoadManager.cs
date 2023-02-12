using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneLoadManager : MonoBehaviour
{
   public delegate void timerReset();

    public static timerReset onTimeReset;
    public void Menuload(){
      SceneManager.LoadScene("Menu");
    }

    public void MenuloadMultiplayer(){
      onTimeReset();
      PhotonNetwork.Disconnect();
      SceneManager.LoadScene("Menu");
    }
    public void MainLoad(){
      SceneManager.LoadScene("Main");
    }
    public void Main2Load(){
      PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().name);
    }
    public void LobbyLoad(){
      SceneManager.LoadScene("Loading");
    }
}

