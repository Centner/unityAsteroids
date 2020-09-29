using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float shootspeed;
    public GameObject bullets;
    private float timerholder;

    public float xlimit;
    public float ylimit;


    void Start()
    {
        timerholder = shootspeed;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(speed, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag is "bullet") { Die(); Destroy(other.gameObject); }
        else if (other.tag is "Player") { Destroy(other.gameObject); }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        shootspeed -= Time.deltaTime;
        if (shootspeed<=0)
        {
            Instantiate(bullets, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            shootspeed = timerholder;
        }

        // перенос с края экрана
        // горизонтальный
        if (transform.position.x > xlimit) { transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z); }
        //else if (transform.position.x < -xlimit) { transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z); }
        //вертикальный
        if (transform.position.y > ylimit) { transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); }
        else if (transform.position.y < -ylimit) { transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); }
    }
}
