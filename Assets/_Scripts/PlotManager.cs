using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    public SpriteRenderer plant;
    public Sprite[] plantStages;
    public int plantStage = 0;

    public bool isPlanted;
    

    float timer = 5;

    private PlantObject selectedPlant;


    void Start()
    {

    }


    void Update()
    {


        if (selectedPlant != null)
        {
            if (timer < 0)
            {
                if (plantStage < selectedPlant.plantStages.Length - 1)
                {
                    plantStage++;
                    timer = selectedPlant.timeBtwStage;
                    UpdatePlant();
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }


    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if (isPlanted)
            {
                if (plantStage == selectedPlant.plantStages.Length - 1)
                {
                    Harvest();
                }
            }
            else
            {
                Plant();

            }
        }
        else
        {
            if (isPlanted && PlantingManager.instance.curPlant != null)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if(isPlanted == false && PlantingManager.instance.curPlant != null)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }

    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1)
            {
                Harvest();
            }
        }
        else
        {
            Plant();

        }
    }

    private void  Harvest()
    {    
        if(PlantingManager.instance.curPlant != null)
        {
            PlantingManager.instance.curPlant = null;
        }
        //todo: Havest action 
        plant.gameObject.SetActive(false);
        isPlanted = false;

       
    }

    void Plant()
    {

        if(PlantingManager.instance.curPlant != null)
        {
            isPlanted = true;
            selectedPlant = PlantingManager.instance.curPlant;

            plantStage = 0;

            plantStages = selectedPlant.plantStages;
            plant.sprite = selectedPlant.plantStages[plantStage];
            timer = 5;

            plant.gameObject.SetActive(true);
        }

    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
