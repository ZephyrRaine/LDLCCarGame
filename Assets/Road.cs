using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public List<GameObject> carPrefabs;
    public CarController playerCar;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnCar", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCar.transform.position.z >= 100f)
        {
            foreach(Transform t in transform)
            {
                t.position -= Vector3.forward * 100f;
            }
        }
    }

    void SpawnCar()
    {
            GameObject original = carPrefabs[Random.Range(0,carPrefabs.Count)];
            Vector3 position = playerCar.transform.position;
            position.z += 150f;
            position.x = Random.Range(-1,2)*3f;
            GameObject instance = Instantiate(original, position, Quaternion.identity);
            instance.transform.SetParent(transform);
            instance.GetComponent<Car>().speed = Random.Range(10f,50f);
            Invoke("SpawnCar", Random.Range(0.5f,1.25f));
    }
}
