using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_Removal : MonoBehaviour
{
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioPlayer.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
