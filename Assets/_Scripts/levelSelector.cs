using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelSelector : MonoBehaviour
{
    [System.Serializable]
    public class LevelList
    {
       
    }
    [SerializeField] List<GameObject> listItem;

    GameObject itemTemplate;
    GameObject g;
    Button selectButton;

    [SerializeField] Transform itemScrollView;

    void Start()
    {

        InstantiateItem();
    }
    void InstantiateItem()
    {
        itemTemplate = itemScrollView.GetChild(0).GetChild(0).gameObject;


        Destroy(itemTemplate);
    }

    void OnshopClicked(int itemIndex)
    {
        selectButton = itemScrollView.GetChild(0).GetChild(itemIndex).GetChild(0).GetComponent<Button>();
       

    }
}

