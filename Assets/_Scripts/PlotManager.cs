using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    public SpriteRenderer plant;
    public Sprite[] plantStages;
    public int plantStage = 0;

    bool isPlanted;
    

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

    void Harvest()
    {
        isPlanted = false;

        plant.gameObject.SetActive(false);
    }

    void Plant()
    {
        isPlanted = true;

        selectedPlant = PlantingManager.instance.curPlant;

        plantStage = 0;
        plantStages = selectedPlant.plantStages;
        plant.sprite = selectedPlant.plantStages[plantStage];
        timer = 5;

        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = plantStages[plantStage];
    }
}
