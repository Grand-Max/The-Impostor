﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    public GameObject createBtn, joinBtn;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.NickName = "PLayer " + Random.Range(1000, 9999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.0.01";
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnected()
    {
        createBtn.SetActive(true);
        joinBtn.SetActive(true);
    }

    

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 10 } );
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnConnectedToMaster()
    {
        
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("TestMap");
    }
}