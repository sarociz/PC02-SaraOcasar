using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioList;
    private bool lastClickDerecho = false;

    // Update is called once per frame
    void Update()
    {
        //Get click izquierdo: play audio random de la lista
        if (Input.GetMouseButtonDown(0))
        {
            if (audioList.Length > 0)
            {
                //si el audio esta pausado, reproducirlo
                if (!audioSource.isPlaying & lastClickDerecho == true)
                {
                    audioSource.UnPause();
                }
                else
                {
                    audioSource.loop = true;
                    //recoger número de audios de la lista
                    int randomIndex = Random.Range(0, audioList.Length);
                    //recoegr un audio aleatorio de la lista
                    AudioClip selectedClip = audioList[randomIndex]; 
                    //asignar ese audio al audio source
                    audioSource.clip = selectedClip;

                    // Reproducir el audio seleccionado
                    audioSource.Play();

                    lastClickDerecho = false;
                }
            }
        }
        //Get click derecho: pausar audio
        if (Input.GetMouseButtonDown(1))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
                lastClickDerecho = true;
            }

        }
        //Get click en medio: parar audio
        if (Input.GetMouseButtonDown(2))
        {

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                lastClickDerecho = false;
            }
        }
    }
}
