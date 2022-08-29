using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{


    [SerializeField] private float speed = 10f;
    [SerializeField] private float speedGainPerSecond = 0.2f;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;
    
    void Update()
    {

        speed += speedGainPerSecond * Time.deltaTime;
        
        
        transform.Rotate(0f,steerValue*turnSpeed*Time.deltaTime,0f);
        
        transform.Translate(Vector3.forward * speed*Time.deltaTime);
        
        
    }

    public void Steer(int value)
    {
        steerValue = value;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);    
        }

        if (other.gameObject.CompareTag("DeadZone"))
        {
            SceneManager.LoadScene(0);
        }
        
    }
    
}
