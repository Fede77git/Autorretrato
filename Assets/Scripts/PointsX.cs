using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsX : MonoBehaviour
{
    public int points = 0; 
    public int pointsToCheck = 200;

    public GameObject door; 

    private bool sumaArea = false;

    public TextMeshProUGUI pointText;


    void Start()
    {
        ActualizarPoints();
    }

    void ActualizarPoints()
    {
        if (pointText != null)
        {
            pointText.text = points + "/" + pointsToCheck;
        }
    }

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
        ActualizarPoints();
        
        if (points >= pointsToCheck)
        {
            
            door.SetActive(false);
            
        }
    }
}
