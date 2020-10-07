using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    // (0, 1.5, 3) (0, 1.5, 3) (0, 1.5, 3) (0, 1.5, 3) (0, 1.5, 3)
    // (0, 1.5, 3) (0, 1.5, 3) (0, 1.5, 3) (0, 1.5, 3) (0, 1.5, 3)
    void Start()
    {
        if(PhotonNetwork.IsMasterClient){
        Vector3 position = new Vector3(Random.Range(0, 20), (1.5f) , Random.Range(0, 20));
        PhotonNetwork.Instantiate("Player", position, Quaternion.identity);
        Cursor.visible = false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        //This player left room
        SceneManager.LoadScene("MainMenu");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
    }
}
