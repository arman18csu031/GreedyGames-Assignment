using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // public Transform spawnPoint1;
    // public Transform spawnPoint2;

  public override void OnJoinedRoom() {

    Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    // if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
    //     {
    //         PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint1.position, spawnPoint1.rotation);
    //     }
    //     else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
    //     {
    //         PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint2.position, spawnPoint2.rotation);
    //         enabled = false;
    //     }
  }
}
