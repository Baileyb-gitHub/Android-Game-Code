using System.Collections;
using System.Collections.Generic;
using System.Security;   //using System.Security.Policy;
using UnityEngine;

public class player_Controller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRigidBody;
    public bool clickOverwrite;

    [Header("References")]
    public Level_Data levelData;
    public GameObject deathParticles;
    public GameObject deathAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>().playerMaterial;     // sets player material to currently saved user selection stored in game data
    }

    // Update is called once per frame
    void Update()
    {
      movementUpdate();   
    }


    public void movementUpdate()  // handles per frame movement based on player input
    {
        Vector3 touchposition = transform.position;

        if (clickOverwrite == true)   // bool overide for testing, allowing clicking instead of touch for pc testing
        {
            touchposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0)) 
            {
                Debug.Log("Player Mouse Input");
                 touchposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
           
        }
        else 
        {
            Touch touch = Input.GetTouch(0);
             touchposition = Camera.main.ScreenToWorldPoint(touch.position);

        }

        touchposition.z = transform.position.z;
        transform.right = touchposition - transform.position;
        myRigidBody.AddForce(transform.right * (moveSpeed * Time.deltaTime));


      //  myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 6f);  // temp clamp
    }








    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            levelData.gameLost();
            GameObject particles = Instantiate(deathParticles, transform.position, Quaternion.identity);

            particles.GetComponent<Renderer>().material = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().material;                    // sets the colour of death particles to match player material
            particles.GetComponent<ParticleSystemRenderer>().material = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>().material;     // sets the colour of death particles to match player material

            Instantiate(deathAudio, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
