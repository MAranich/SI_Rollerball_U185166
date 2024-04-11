using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; 
    public bool is_on_floor = true;
    public float max_speed = 6; // m/s
    [SerializeField] private Vector3 input_dir = Vector3.zero;

    private float acceleration = 0.15f; 
    private float acceleration_stop = 0.4f; 
    private int acceleration_aplications_per_sec = 40;
    private float friction;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //v = inc * f / (1 - f); inc = 1

        //v = inc * 1 / (1/f - 1); 
        //1 / (1/f - 1) = v / inc; 
        //1/f - 1 = inc / v; 
        //1/f = inc / v + 1; 
        //f = 1 / (inc / v + 1); 
        friction = 1 / (1 / max_speed + 1);

        print(string.Format("Max speed: {0}\tActual Max Speed: {1}", max_speed, friction / (1 - friction)));
        //if the 2 numbers coincide, everything is fine
    }

    void Update()
    {

        bool has_pressed_ws = false; 
        if(Input.GetKey(KeyCode.W)) {
            input_dir += Vector3.right * acceleration;
            has_pressed_ws = true;
        }
        if(Input.GetKey(KeyCode.S)) {
            input_dir += -Vector3.right * acceleration;
            has_pressed_ws = true;
        }

        bool has_pressed_ad = false; 
        if(Input.GetKey(KeyCode.A)) {
            input_dir += Vector3.forward * acceleration;
            has_pressed_ad = true; 
        }
        if(Input.GetKey(KeyCode.D)) {
            input_dir += -Vector3.forward * acceleration;
            has_pressed_ad = true;
        }



        input_dir = new Vector3(Mathf.Clamp(input_dir.x, -1, 1), Mathf.Clamp(input_dir.y, -1, 1), Mathf.Clamp(input_dir.z, -1, 1)); 
        
        rb.velocity = rb.velocity + input_dir.normalized;
        if (is_on_floor) {
            rb.velocity = rb.velocity * friction;
        }

        if (!has_pressed_ws) {
            input_dir.x *= Mathf.Pow(acceleration_stop, acceleration_aplications_per_sec * Time.deltaTime); 
        }
        if(!has_pressed_ad) {
            input_dir.z *= Mathf.Pow(acceleration_stop, acceleration_aplications_per_sec * Time.deltaTime); ;
        }

    }
}
