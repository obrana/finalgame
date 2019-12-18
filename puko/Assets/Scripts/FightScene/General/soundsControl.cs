using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsControl : MonoBehaviour
{

    public static soundsControl Instance { set; get; }
    public AudioSource fightsound;
    public AudioSource clickSound;
    public AudioSource pikachuStartSound;
    public AudioSource charizardStartSound;
    public AudioSource flamethrowerSound;
    public AudioSource goPokeballSound;
    public AudioSource tackleSound;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void ClickSound()
    {
        clickSound.Play();
    }
}
