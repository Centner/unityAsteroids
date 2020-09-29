using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float xlimit;
    public float ylimit;

    public float lifetimer = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(speed, 0));
    }

    private void Update()
    {
        // перенос с края экрана
        // горизонтальный
        if (transform.position.x > xlimit) { transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z); }
        else if (transform.position.x < -xlimit) { transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z); }
        //вертикальный
        if (transform.position.y > ylimit) { transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); }
        else if (transform.position.y < -ylimit) { transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); }

        lifetimer -= Time.deltaTime;
            if (lifetimer <= 0) { Destroy(gameObject); }
    }

}
