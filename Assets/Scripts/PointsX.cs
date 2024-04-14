using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsX : MonoBehaviour
{
    public int points = 0; 
    public int pointsToCheck = 200;

    public GameObject door; 

    private bool sumaArea = false;
    
    void Update()
    {
        
        if (sumaArea && Input.GetKeyDown(KeyCode.F))
        {
            Suma(); 
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            sumaArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            sumaArea = false;
        }
    }
    
    void Suma()
    {
        points++;
        Debug.Log("Puntos: " + points);

        
        if (points >= pointsToCheck)
        {
            
            door.SetActive(false);
            
        }
    }
}
