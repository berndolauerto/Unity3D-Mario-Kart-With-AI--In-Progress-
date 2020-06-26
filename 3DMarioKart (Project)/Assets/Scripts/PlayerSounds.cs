﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player playerscript;
    private ItemManager item_script;
    public AudioSource kartSound;
    public AudioSource kartIdle;

    public AudioSource[] effectSounds;  //0. driftsound steering //1. driftspark
    public AudioSource[] Mario_Boost_Sounds;
    public AudioSource[] MarioStarSounds;
    public AudioSource[] BulletSounds;
    public AudioSource Mario_Glider;

    [HideInInspector]
    public int sound_count = 0;
    [HideInInspector]
    public int star_count_sound = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerscript = GetComponent<Player>();
        item_script = GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        kart_sounds();
        if (sound_count == Mario_Boost_Sounds.Length)
            sound_count = 0;

    }

    void kart_sounds()
    {
        if (playerscript.currentspeed < 10 && playerscript.currentspeed >=-10)
        {
            if (!kartIdle.isPlaying)
            {
                kartIdle.Play();
            }
        }
        if (playerscript.currentspeed < -10)
        {
            kartIdle.Stop();
        }


        if (playerscript.currentspeed >= 5 && !playerscript.GLIDER_FLY && !item_script.isBullet)
        {
            if (!kartSound.isPlaying)
            {
                kartSound.Play();
            }

            //speed variations affect the time the kart sound is on
            if (playerscript.currentspeed > 5 && playerscript.currentspeed <= 10)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 1f, 3 * Time.deltaTime);
                kartIdle.Stop();

            }
            if (playerscript.currentspeed > 10 && playerscript.currentspeed <= 20)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 1.5f, 4 * Time.deltaTime);
                kartIdle.Stop();

            }
            else if (playerscript.currentspeed > 20 && playerscript.currentspeed < 30)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 2.5f, 4 * Time.deltaTime);
                kartIdle.Stop();

            }
            else if (playerscript.currentspeed >= 30 && playerscript.currentspeed < 40)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 4, 4 * Time.deltaTime);
                kartIdle.Stop();

            }
            else if (playerscript.currentspeed >= 40 && playerscript.currentspeed < 50)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 5, 4 * Time.deltaTime);
                kartIdle.Stop();

            }
            else if (playerscript.currentspeed >= 50 && playerscript.currentspeed < 60)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 6, 4 * Time.deltaTime);
                kartIdle.Stop();

            }
            else if (playerscript.currentspeed >= 60 && playerscript.currentspeed < 70)
            {
                kartSound.time = Mathf.Lerp(kartSound.time, 7, 4 * Time.deltaTime);
                kartIdle.Stop();

            }


            //pitch
            if (!playerscript.Boost)
            {
                kartSound.pitch = Mathf.Lerp(kartSound.pitch, 1f, 5f * Time.deltaTime);
            }
            else
            {
                kartSound.pitch = Mathf.Lerp(kartSound.pitch, 1.3f, 5f * Time.deltaTime);
            }
        }
        if (playerscript.currentspeed < 10 || item_script.isBullet)
        {
            kartSound.Stop();
        }
        if (playerscript.GLIDER_FLY)
        {
            kartSound.volume = 0.3f;
        }
        else
        {
            kartSound.volume = 0.45f;
        }
    }
    
    public bool Check_if_playing()  //this method returns a bool, and checks if any mario sounds are already playing, so if-statements can decide whether to or not to play a new sound
    {
        for(int i = 0; i < Mario_Boost_Sounds.Length; i++)
        {
            if (Mario_Boost_Sounds[i].isPlaying)
                return false;
        }
        return true;

    }

}
