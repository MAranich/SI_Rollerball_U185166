using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBhbr : MonoBehaviour
{
    public float rotation_speed_rads_s = 355/226; //pi/2
    public float levitating_speed = 1.5f; 
    private Vector3 displ;
    public static CanvasBhvr canvas; 

    private void Start()
    {
        displ = transform.position;
        canvas = GameObject.Find("Canvas").GetComponent<CanvasBhvr>(); 
    }
    void Update()
    {
        transform.Rotate(new Vector3(0.7071f, 0.7071f, 0), rotation_speed_rads_s * Time.deltaTime * Mathf.Rad2Deg);
        transform.position = displ + new Vector3(0, 0.25f * Mathf.Sin(Time.time * levitating_speed), 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas.add_points(1); 
        Destroy(gameObject);
    }

}
