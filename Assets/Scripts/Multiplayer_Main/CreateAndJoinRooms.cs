using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    public bool onRoomJoined = false;
   
   private void Start(){
    PhotonNetwork.JoinLobby();
   }
    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnCreatedRoom(){
        Debug.Log("Room Created");
        PhotonNetwork.LoadLevel("Main2");
    }

   public override void OnJoinedRoom(){
    onRoomJoined = true;
    Debug.Log("Room Joined");
    PhotonNetwork.LoadLevel("Main2");
   }   
}
