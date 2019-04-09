using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;

    //La fonction Update est appelée une fois par frame.
    void Update()
    {
        //On récupère la position actuelle dans une variable.
        Vector3 position = transform.position;
        //On augmente la position sur l'axe Z de speed/seconde.
        position.z += speed*Time.deltaTime;
        //On assigne la variable temporaire à la position de la voiture.
        transform.position = position;
    }
}
