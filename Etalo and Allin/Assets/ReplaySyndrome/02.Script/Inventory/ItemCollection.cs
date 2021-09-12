using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public Item bone;
    public Item bonfire;
    public Item branch;
    public Item bullet;
    public Item cactus;
    public Item cactusfruit;
    public Item candy;
    public Item fruit;
    public Item grilledmeat;
    public Item gun;
    public Item hatchet;
    public Item log;
    public Item meat;
    public Item palmleaf;
    public Item pebble;
    public Item petal;
    public Item pickax;
    public Item poionjelly;
    public Item poisonsac;
    public Item roastedcactusfruit;
    public Item rock;
    public Item rope;
    public Item sand;
    public Item shovel;
    public Item skin;  
    public Item slime;
    public Item slingshot;
    public Item soup;
    public Item tent;
    public Item thread;
    public Item water;
    public Item waterbag;
    public Item redflower;
    public Item orangeflower;
    public Item yellowflower;
    public Item greenflower;
    public Item blueflower;
    public Item purpleflower;
    public Item oasisflower;
    public Item whiteflower;



    private Dictionary<string, Item> composedItemDict;


    public GameObject bonefireObejct;
    public GameObject tentObejct;

    private void Awake()
    {
        composedItemDict = new Dictionary<string, Item>();

        composedItemDict.Add(branch.itemName + branch.itemName + branch.itemName + branch.itemName + branch.itemName + branch.itemName + branch.itemName +
            rock.itemName + rock.itemName + rock.itemName + rock.itemName + rock.itemName, bonfire); // 모닥불 – 나뭇가지(7) + 돌(5)
        composedItemDict.Add(skin.itemName + skin.itemName +
            water.itemName + water.itemName + water.itemName + water.itemName + water.itemName +
            water.itemName + water.itemName + water.itemName + water.itemName + water.itemName,waterbag); // 물가방 - 가죽(2) + 물(10)

        composedItemDict.Add(log.itemName + log.itemName + palmleaf.itemName + palmleaf.itemName
            + rock.itemName + rock.itemName, tent); // 텐트 - 통나무(2) + 야자잎(2) + 돌(2)

        composedItemDict.Add(cactusfruit.itemName + poisonsac.itemName + poisonsac.itemName, poionjelly); // 독젤리 - 선인장과육(1) + 독주머니(2)



        composedItemDict.Add(petal.itemName + petal.itemName + slime.itemName, candy); //캔디 - 꽃잎(2) + 점액(1)

        composedItemDict.Add(branch.itemName + meat.itemName + meat.itemName, grilledmeat); // 고기구이 - 나뭇가지(1) + 고기(2)

        
        composedItemDict.Add(meat.itemName + slime.itemName + slime.itemName, soup); // 수프 - 고기(1) + 점액(2)
    }


    public Item ReturnComposedItem(string items)
    {
        if (composedItemDict.ContainsKey(items))
        {
            return composedItemDict[items];
        }

        print("없습니다.");
        return null;
    }

    public void MakePlayerItemPlaceState(string itemName)
    {
        var etalo = GameObject.FindGameObjectWithTag("Player").GetComponent<EtaloController>();

        if(itemName == "tent" )
        {

            etalo.UIReset();
            etalo.itemAssembleState = true;
            etalo.placeObject = tentObejct;
            etalo.placeObjectNum = 2;
            Cursor.lockState = CursorLockMode.Locked;

        }
        if (itemName == "bonfire")
        {
            etalo.UIReset();
            etalo.itemAssembleState = true;
            etalo.placeObject = bonefireObejct;
            etalo.placeObjectNum = 1;

            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {

        }
    }
}
