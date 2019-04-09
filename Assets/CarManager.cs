using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Player player;
    //La fonction Start est appelée une fois au lancement du jeu.
    void Start() 
    {
        //On demande à Unity d'appeler cette fonction dans une demie-seconde.
        Invoke("InstantiateCar", 2.5f);
    }

    void Update()
    {

        //Si la position du joueur sur l'axe Z est supérieure ou égale à 100 mètres
        if(player.transform.position.z >= 100f)
        {
            //On parcourt chaque gameobject enfant (toutes les voitures)...
            foreach(Transform car in this.transform)
            {
                //Et on replace la voiture 100 mètres en arrière.
                Vector3 position = car.transform.position;
                position.z -= 100f;
                car.transform.position = position;
            }
        }
    }

    //La fonction Update est appelée une fois par frame.    
    void InstantiateCar()
    {
        //On crée un nouveau vecteur pour stocker la position de départ de la voiture.
        Vector3 randomPosition = new Vector3();
        
        /*On choisit un nombre entier compris entre -1 et 2 (exclu);
        La valeur x du vecteur randomPosition est donc -1, 0, ou 1.

        Nos voitures pouvant avoir une valeur de -3, 0, ou 3, on multiplie cette valeur par 3. */
        randomPosition.x = Random.Range(-1,2);
        randomPosition.x *= 3;
        //On place la voiture au-dessus du sol.
        randomPosition.y = 2f;
        //On place la voiture 50 mètres devant le joueur.
        randomPosition.z = player.transform.position.z + 60f;

        //On instantie la voiture en enfant de ce gameobject, à la position choisie.
        Instantiate(carPrefab, randomPosition, Quaternion.identity, transform);

        //On choisit un délai aléatoire pour appeler la fonction InstantiateCar;
        float delay = Random.Range(2.5f,5f);
        //On demande à Unity d'appeler cette fonction dans "delay".
        Invoke("InstantiateCar", delay);
    }
}
