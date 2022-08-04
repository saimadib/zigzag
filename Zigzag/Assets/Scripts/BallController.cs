using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particle;
    [SerializeField]
    private float speed = 5;
    bool started;
    bool gameover;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        started = false;
        gameover = false;
       
        
    }

    // Update is called once per frame
    void Update()

    {
        if(started==false)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                gamemanager.instance.start();
             
            }
        }

       if(! Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameover = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<camerafollow>().gameover = true;
            GameObject.Find("platform spawing").GetComponent<platformspawn>().gameover = true;
            gamemanager.instance.end();
            speed = 5;
            
        }

        else if(Input.GetMouseButtonDown(0) && !gameover)
        {
            swithdirection();
        }
        

    }
    void swithdirection()
    {
        if(rb.velocity.z>0)
        {
            rb.velocity=new Vector3(speed,0,0);
            speed = speed + 0.1f;
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
            speed = speed + 0.1f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="diamond")
        {
            GameObject part = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 2f);
        }
    }
    
    

}
