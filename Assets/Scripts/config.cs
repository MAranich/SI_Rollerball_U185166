using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour
{
    public int target_frame_rate = 60;
    public GameObject pickups_go;
    public GameObject collectible_prefab; 

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target_frame_rate;
    }

    private void Update()
    {
        if(pickups_go.transform.childCount <= 0)
        {
            int new_childs = (int)(10 * (Random.value * Random.value)); 
            for (int i = 0; i < new_childs; i++)
            {
                GameObject go = Instantiate(collectible_prefab, new Vector3((Random.value * 17.5f - 8.75f), 0.85f, Random.value * 17.5f - 8.75f), Random.rotation); 
                go.transform.parent = pickups_go.transform; 

            }
        }
    }
}
