using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnClickCharacterPick(int whichChracter)
    {
        Debug.Log("MenuController");
        if (PlayerInfo.PI != null)
        {
            PlayerInfo.PI.mySelectedCharacter = whichChracter;
            PlayerPrefs.SetInt("MyCharacter", whichChracter);
        }
    }
}
