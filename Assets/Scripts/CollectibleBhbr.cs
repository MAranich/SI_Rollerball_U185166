using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBhbr : MonoBehaviour
{
    public float rotation_speed_rads_s = 355/226; //pi/2
    public float levitating_speed = 1.5f; //pi/2
    public Vector3 displ;

    private void Start()
    {
        displ = transform.position;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0.7071f, 0.7071f, 0), rotation_speed_rads_s * Time.deltaTime * Mathf.Rad2Deg);
        transform.position = displ + new Vector3(0, 0.25f * Mathf.Sin(Time.time * levitating_speed), 0);
        
    }
}
