using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarController : MonoBehaviour
{
    Car car;
    
    public TMP_Text speedText;
    public TMP_Text scoreText;

    float score;
    float startSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<Car>();
        car.speed = startSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Car")
        {
            score = Mathf.Max(score-30f,0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3f)
        {
            transform.position -= Vector3.right *3;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3f)
        {
            transform.position += Vector3.right *3;
        }   

        score += Time.deltaTime*2f;
        
        car.speed = startSpeed+(10f*(((int)score/10)+1f));

        speedText.text = ((int)car.speed).ToString();
        scoreText.text = ((int)score).ToString();
    }
}
