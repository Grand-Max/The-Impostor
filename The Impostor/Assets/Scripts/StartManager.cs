using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject cameraTemp;
    public bool foundMe = false;
    void Start()
    {
        if(PhotonNetwork.IsMasterClient){
            gameManager.SetActive(true);
        }
        
    }
    
    void Update(){
         
        if (foundMe) return;
        
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (var item in gameObjects)
        {
            

            if (item.GetComponent<PlayerInfo>().playerID == PhotonNetwork.LocalPlayer.UserId){
                foundMe = true;
                item.transform.GetChild(1).gameObject.SetActive(true);
                item.GetComponent<PlayerControler>().enabled = true;

            }
        }
    }

    
}
