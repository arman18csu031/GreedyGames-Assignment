using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
         Debug.Log("blah");
        LoadLobbyScene();
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }
}
