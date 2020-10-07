using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInfo : MonoBehaviourPun
{
    
    public string playerID = "0";
    public bool isImpostor = false;
    public bool isAlive = true;
    public bool isMine = false;


    [PunRPC]
    void ChangeInfo(bool impostor, string id){
        playerID = id;
        isImpostor = impostor;
        if(PhotonNetwork.LocalPlayer.UserId == playerID){
            isMine = true;
        }
    }

    
}
