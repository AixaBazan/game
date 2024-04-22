using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendirse : MonoBehaviour
{
    private GameObject GM;
    void Start()
    {
        GM = GameObject.Find("GameManager");
    }

    public void Click()
    {
        if(GM.GetComponent<GameManager>().IsPlaying == false)
        {
            GM.GetComponent<GameManager>().J1CanPlay = true;
            GM.GetComponent<GameManager>().IsPlaying = true;
            Debug.Log("El jugador 1 se rindio");
        }
        else
        {
            GM.GetComponent<GameManager>().J2CanPlay = true;
            GM.GetComponent<GameManager>().IsPlaying = false;
            Debug.Log("El jugador 2 se rindio");
        }
    }
}
