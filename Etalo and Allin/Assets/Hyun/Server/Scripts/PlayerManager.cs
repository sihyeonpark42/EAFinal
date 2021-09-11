using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
	
	private PhotonView PV;
	public int characterValue;
	public GameObject myCharacter;
	


	void Awake()
	{

		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		Debug.Log("PlayerManager");
		if (PV.IsMine)//내 포톤 네트워크이면
		{
			Debug.Log("IsMine");
			PV.RPC("RPC_CreateCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
		}
	}


	[PunRPC]
    void RPC_CreateCharacter(int Character)
	{
		if(!PV.IsMine)
        {
			return;
        }
		Debug.Log("RPC_CreateCharacter");
		Vector3 pos = new Vector3(81, 11, 0);
		characterValue = Character;
		
        if (characterValue == 0)
        {
			Debug.Log("Create");
			myCharacter = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","Etalo0816"), pos, Quaternion.identity);
		}
        else
        {
			myCharacter = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Allin0816"), pos, Quaternion.identity);
		}


        //myCharacter = PhotonNetwork.Instantiate(PlayerInfo.PI.allCharacters[Character], pos, Quaternion.identity);

        //myCharacter = Instantiate(PlayerInfo.PI.allCharacters[Character], pos, Quaternion.identity);
        //myCharacter = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "New_Etalo"), pos, Quaternion.identity);

        //GameObject etalo = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Etalo_2"), Vector3.zero, Quaternion.identity);
        //GameObject allin = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Allin_2"), Vector3.zero, Quaternion.identity);
        //	PhotonNetwork.Instantiate(AllinPrfab.name,Vector3.zero, Quaternion.identity);

        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "New_Etalo"), pos, Quaternion.identity);

        //Instantiate(찍어낼 오브젝트, 찍어낼 위치, 찍을때 회전값)
    }

    /*	public void Die()
		{
			PhotonNetwork.Destroy(controller);
			CreateController();
		}*/
}