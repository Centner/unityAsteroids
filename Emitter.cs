using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public float timer;
    public GameObject alien;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(alien, transform);
            timer = 30f;
        }
    }
}
