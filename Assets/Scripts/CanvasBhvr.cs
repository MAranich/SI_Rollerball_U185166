using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasBhvr : MonoBehaviour
{
    private TMP_Text points_text;
    private int point_count = 0; 

    void Start()
    {
        points_text = transform.GetChild(0).GetComponent<TMP_Text>();
        print(points_text); 
        point_count = 0;
    }

    public void add_points(int n)
    {
        point_count += n;
        points_text.text = string.Format("Points: {0}", point_count); 
    }

}
