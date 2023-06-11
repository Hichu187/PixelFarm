using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Planting_Scrollview_UI : MonoBehaviour
{
    public GameObject content;
    public List<PlantObject> crops;

    GameObject itemTemplate;
    GameObject obj_btn;
    Button selectButton;
    [SerializeField] Transform itemScrollView;

    bool open;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void Start()
    {
        crops = PlantingManager.instance.plants;
        InstantiateItem();
    }

    void InstantiateItem()
    {
        itemTemplate = itemScrollView.GetChild(0).GetChild(0).gameObject;

        for (int i = 0; i < crops.Count; i++)
        {
            obj_btn = Instantiate(itemTemplate, itemScrollView.GetChild(0));
            obj_btn.transform.GetChild(0).GetComponent<Image>().sprite = crops[i].plantStages[crops[i].plantStages.Length -1];

            selectButton = obj_btn.GetComponent<Button>();

            selectButton.AddEventLisntener(i, OnshopClicked);
        }

        Destroy(itemTemplate);
    }

    void OnshopClicked(int itemIndex)
    {
        selectButton = obj_btn.GetComponent<Button>();
        PlantingManager.instance.curPlant = crops[itemIndex];
    }

    public void Open_Close_Scrollview()
    {
        if(open == false)
        {
            open = true;
            this.GetComponent<Animator>().SetBool("isOpen", open);
        }
        else
        {
            open = false;
            this.GetComponent<Animator>().SetBool("isOpen", open);
        }
    }
}
