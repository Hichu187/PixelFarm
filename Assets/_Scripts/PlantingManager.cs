using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingManager : MonoBehaviour
{
    public static PlantingManager instance;

    private void Awake()
    {
        instance = this;
        PlantObject[] obj = Resources.LoadAll<PlantObject>("Scriptable_Object/");
        plants.AddRange(obj);

    }

    public List<PlantObject> plants;

    public PlantObject curPlant;
    public int curPlantID;
    void Start()
    {
        
    }


    void Update()
    {

    }
}
