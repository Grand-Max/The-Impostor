using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MasterManager : MonoBehaviourPunCallbacks
{
    public int playerCount;
    private int[] impostorNums;
    private Player[] players;
    public Dictionary<string,GameObject> playerIds;
    // Start is called before the first frame update
    new void  OnEnable()
    {
        playerIds = new Dictionary<string, GameObject>();
        
        players = PhotonNetwork.PlayerList;
        playerCount = players.Length;


        if (PhotonNetwork.IsMasterClient)
        {
            impostorNums = RandomImpostor();
            SpawnPlayers();
        }
    }

    
    

    void LateUpdate()
    {
        players = PhotonNetwork.PlayerList;
        playerCount = players.Length;
    }

    int[] RandomImpostor()
    {
        if (playerCount < 6)
        {
            return new int[] { getUniquRandomNumber(1,5) };
        }
        else if (playerCount < 9)
        {
            return new int[] { getUniquRandomNumber(1,8), getUniquRandomNumber(1,8)  };
        }
        else
        {
            return new int[] { getUniquRandomNumber(1,10), getUniquRandomNumber(1,10)  };
        }

    }
    void SpawnPlayers()
    {
        
        Vector3 center = new Vector3(0, 1.5f, 0);
        for (int i = 0; i < playerCount; i++)
        {

            int a = 360 / playerCount * i;
            Vector3 pos = RandomCircle(center, 4.0f, a);
            Vector3 center2 = center - pos;
            Debug.Log("x: " + pos.x + "; y: " + pos.y);
            GameObject player = PhotonNetwork.Instantiate("Player", pos, Quaternion.LookRotation(center2));
            player.GetPhotonView().TransferOwnership(players[i]);
            
            playerIds.Add(players[i].UserId, player);
            
            for (int j = 0; j < impostorNums.Length; j++)
            {
                if (impostorNums[j] == i){
                    player.GetComponent<PhotonView>().RPC("ChangeInfo", RpcTarget.All, true, players[i].UserId);
                    
                }
            }
            player.GetComponent<PhotonView>().RPC("ChangeInfo", RpcTarget.All, false, players[i].UserId);
        }
    }
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        return pos;
    }

    int getUniquRandomNumber(int min, int max)
    {
        int num = Random.Range(min, max);
        if (impostorNums == null)
        {
            return num;
        }
        else
        {
            for (int i = 0; i < impostorNums.Length; i++)
            {
                if (impostorNums[i] == num)
                {
                    num = Random.Range(min, max);
                    i = 0;
                }
            }
            return num;
        }
    }
        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            PhotonNetwork.Destroy(playerIds[otherPlayer.UserId]);
        }

        
    


    //ENDE    
}
