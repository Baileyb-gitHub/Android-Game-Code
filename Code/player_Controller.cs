using System.Collections;
using System.Collections.Generic;
using System.Security;   //using System.Security.Policy;
using UnityEngine;

public class player_Controller : MonoBehaviour
{
    public float moveSpeed;
    public bool invincible;
    public Rigidbody2D myRigidBody;
    public bool clickOverwrite;

    [Header("References")]
    private Game_Data gameData;
    public Level_Data levelData;
    public GameObject deathParticles;
    public GameObject deathAudio;
    public Joystick joyStick;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>();
        gameObject.GetComponent<SpriteRenderer>().material = gameData.playerSkins[gameData.skinOfChoice - 1];     // sets player material to currently saved user selection stored in game data
        clickOverwrite = GameObject.FindWithTag("Game Data").GetComponent<Game_Data>().mouseMode;
    }

    // Update is called once per frame
    void Update()
    {
      movementUpdate();   
    }


    public void movementUpdate()  // handles per frame movement based on player input
    {
        myRigidBody.AddForce(joyStick.Direction * (moveSpeed * Time.deltaTime));  
    }








    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(invincible == true)  // if player is experiencing invincible power up game loss is skipped
            {
            }
            else
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


}
