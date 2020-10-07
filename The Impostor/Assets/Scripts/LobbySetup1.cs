using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class LobbySetup1 : MonoBehaviourPunCallbacks
{
    bool fistTime = true;
    // Start is called before the first frame update
    void Start()
    {

         Vector3 position = new Vector3(Random.Range(0, 20), (1.5f), Random.Range(0, 20));
        GameObject go = PhotonNetwork.Instantiate("Player", position, Quaternion.identity);
    
        Cursor.visible = false; 

    }

    IEnumerator ExecuteAfterTime(float time)
 {
     yield return new WaitForSeconds(time);
 
    PhotonNetwork.LoadLevel("TestMap");
 }
    

    // Update is called once per frame
    void LateUpdate()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient && fistTime)
        {

            StartCoroutine(ExecuteAfterTime(3));
            fistTime = false;

        }
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
        
        Debug.Log("OnPlayerEnteredRoom");
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
    }
}

