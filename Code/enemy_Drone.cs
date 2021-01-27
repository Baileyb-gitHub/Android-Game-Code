using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Drone : MonoBehaviour
{

    public float moveSpeed;
    public int destructionScore;

    [Header("Tracking")]
    public float distToPlayer;
    public float myVelocity;

    [Header("References")]
    public GameObject player;
    public Level_Data level_Data;
    public Rigidbody2D myRigidBody;
    public GameObject deathParticles;
    public GameObject deathAudio;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        level_Data = GameObject.FindWithTag("Level Data").GetComponent<Level_Data>();

        myVelocity = 8;

        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.right = player.transform.position - transform.position;
       
        myRigidBody.AddForce(transform.right * (moveSpeed * Time.deltaTime));

       // myRigidBody.AddForce(player.transform.position * (moveSpeed * Time.deltaTime));



        distToPlayer = Vector3.Distance( transform.position , player.transform.position);


        myVelocity = myRigidBody.velocity.magnitude;


    //    myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 8);  // temp clamp

        /*
        if(distToPlayer < 3) 
        {
           myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 5);
            Debug.Log("clamped to 4");
        }

        else if (distToPlayer < 6) 
        {
          myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 8);
            Debug.Log("clamped to 5");
        }

        else if (distToPlayer < 8)
        {
            myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 12);
            Debug.Log("clamped to 4");
        }

        else if (distToPlayer < 10)
        {
            myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 14);
            Debug.Log("clamped to 1");
        }

        else 
        {
            myRigidBody.velocity = Vector3.ClampMagnitude(myRigidBody.velocity, 20);
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
           // level_Data.enemyDeath();
         //   level_Data.addScore(destructionScore);
            GameObject newParticles = Instantiate(deathParticles, transform.position, Quaternion.identity);
            newParticles.GetComponent<ParticleSystemRenderer>().material = gameObject.GetComponent<SpriteRenderer>().material;
            Instantiate(deathAudio, transform.position, Quaternion.identity);
            level_Data.enemyDeath();
            level_Data.addScore(destructionScore);
            Destroy(gameObject);
        }
    }

}
