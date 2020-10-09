using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


// Player Controler for multuplayer
public class PlayerControler : MonoBehaviour
{
    public CharacterController controller;
    public GameObject myCamera;
    public float speed = 10f;
    private PhotonView photonView;
    private PlayerInfo playerInfo;
    private bool onPause = false;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        playerInfo = GetComponent<PlayerInfo>();
        controller = GetComponent<CharacterController>();

    }


    void Update()

    {
        if (!playerInfo.isMine) return;

        if(Input.GetKey(KeyCode.Escape)){
            if(onPause)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false; 
                onPause = false;
            }
            else{
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; 
                onPause = true;
            }
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        


    }

}