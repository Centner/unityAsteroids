using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float xlimit;
    public float ylimit;
    public GameObject enemyholder;
    public int size;
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed);
        rb.AddTorque(Random.Range(-1f, 1f));
    }
    public void Die()
    {
        if (size == 2)
        {
            Instantiate(enemyholder, transform.position, Quaternion.identity);
            Instantiate(enemyholder, transform.position, Quaternion.identity);
            Instantiate(enemyholder, transform.position, Quaternion.identity);
            Debug.Log("spawned");
            Destroy(gameObject);
        }
        else { Destroy(gameObject); }
     }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag is "bullet") { Die(); Destroy(other.gameObject); }
        else if (other.tag is "Player") { Destroy(other.gameObject); }
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
    }
}
