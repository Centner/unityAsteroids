using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float xlimit;
    public float ylimit;

    public GameObject idle;
    public GameObject running;
    public GameObject bullet;

    public float maxAngularVelocity;
    public float maxHorVelocity;
    public float maxVertVelocity;
    public float speed;
    public float turnrate;
   
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //тут мне приходится ограничивать скорость вращения самому так как юнити не имеет метода maxAngularVelocity для rigidbidy2d, со скоростью - та же история. Без ограничителя довольно быстро берется разгон до первой космической
    // в fixedupdate положил, чтобы не дергался;
    private void FixedUpdate()
    {
        //вращение
        if (rb.angularVelocity < -maxAngularVelocity) { rb.angularVelocity = -maxAngularVelocity; }
        if (rb.angularVelocity > maxAngularVelocity) { rb.angularVelocity = maxAngularVelocity; }
       // горизонтальная скорость
        if (rb.velocity.x < -maxHorVelocity) { rb.velocity = new Vector2(-maxHorVelocity, rb.velocity.y); }
        if (rb.velocity.x > maxHorVelocity) { rb.velocity = new Vector2(maxHorVelocity, rb.velocity.y); }
        // вертикальная скорость
        if (rb.velocity.y < -maxVertVelocity) { rb.velocity = new Vector2(rb.velocity.x, -maxVertVelocity); }
        if (rb.velocity.y > maxVertVelocity) { rb.velocity = new Vector2(rb.velocity.x, maxVertVelocity); }
    }
    private void Update()
    {
        // контроллер
        if (Input.GetKey(KeyCode.W))
        {
          
            rb.AddRelativeForce(new Vector2(0,speed));
           
            idle.SetActive(false);
            running.SetActive(true);
          
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector2(0, -speed));
            idle.SetActive(false);
            running.SetActive(true);
        }
        else
        {
            idle.SetActive(true);
            running.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(turnrate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-turnrate);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z+90f));
        }
        // перенос с края экрана
        // горизонтальный
        if (transform.position.x > xlimit) { transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z); }
        else if (transform.position.x < -xlimit) { transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z); }
        //вертикальный
        if (transform.position.y > ylimit) { transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); }
        else if (transform.position.y < -ylimit) { transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z); }
    }

}
