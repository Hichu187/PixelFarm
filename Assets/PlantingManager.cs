using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingManager : MonoBehaviour
{
    public static PlantingManager instance;

    private void Awake()
    {
        instance = this;
    }

    public List<PlantObject> plants;

    public PlantObject curPlant;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curPlant = plants[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curPlant = plants[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curPlant = plants[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curPlant = plants[3];
        }

    }
}
