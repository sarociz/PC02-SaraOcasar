using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject play;
    public GameObject pause;
    public GameObject stop;
    public VideoClip[] videoList;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //recoger posición del ratón
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //hacer un raycast con la posición del ratón
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //si ha colisionado copn algo
            if (hit.collider != null)
            {
                //si ha colisionado con el objeto play
                if (hit.collider.gameObject == play)
                {
                    //recoger el número de videos en la lista
                    int randomIndex = Random.Range(0, videoList.Length);
                    //seleccionar un video aleatorio de la lista
                    VideoClip selectedClip = videoList[randomIndex];
                   //asignar el video seleccionado al video player
                    video.clip = selectedClip;

                    //reproducir el video
                    video.Play();

                }
                //si ha colisionado con el objeto pause
                else if (hit.collider.gameObject == pause)
                {
                    //reprodudir el video si se ha pausado
                    if (!video.isPlaying)
                    {
                        video.Play();
                    }
                    //pausar el video
                    else
                    {
                        video.Pause();
                    }
                }
                //si ha colisionado con el objeto stop
                else if (hit.collider.gameObject == stop)
                {
                    //parar el video
                    video.Stop();
                }



            }



        }
    }
}
