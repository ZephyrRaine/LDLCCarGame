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

        //Si la touche Gauche est pressée et qu'on est pas déjà à -3...
        if(Input.GetKeyDown(KeyCode.LeftArrow) && position.x > -3)
        {
            //...on diminue la position horizontale de 3
            position.x -= 3;
        }
        //Si la touche Droite est pressée et qu'on est pas déjà à 3...
        else if(Input.GetKeyDown(KeyCode.RightArrow) && position.x < 3)
        {
            //...on augmente la position horizontale de 3.
            position.x += 3;
        }

        //On assigne la variable temporaire à la position de la voiture.
        transform.position = position;
    }
}
