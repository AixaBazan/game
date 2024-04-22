using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverCarta : MonoBehaviour
{
    GameObject Zona;
    public GameObject Cartica;
    public CardUnity CartaInfo;
    GameObject GM;
    public void Clickear()
    {
        GM = GameObject.Find("GameManager");

        if(CartaInfo.ataque == CardUnity.TipoDeAtaque.Melee && CartaInfo.faccion == CardUnity.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("Melee1");
            Cartica.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada = true;
          
            if (GM.GetComponent<GameManager>().J2CanPlay == false)
            {
                GM.GetComponent<GameManager>().IsPlaying = true;
            }
            else
            {
                GM.GetComponent<GameManager>().IsPlaying = false;
            }
            }
            else
            {
                Debug.Log("No es tu turno o esta carta esta en el campo");
            }   
        }
        else if(CartaInfo.ataque == CardUnity.TipoDeAtaque.Ranged && CartaInfo.faccion == CardUnity.Faccion.Fairies )
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("Ranged1");
            Cartica.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada = true;
            
            if (GM.GetComponent<GameManager>().J2CanPlay == false)
            {
                GM.GetComponent<GameManager>().IsPlaying = true;
            }
            else
            {
                GM.GetComponent<GameManager>().IsPlaying = false;
            }
            }
            else
            {
                Debug.Log("No es tu turno o esta carta ya esta en el campo");
            }
        }
        else if(CartaInfo.ataque == CardUnity.TipoDeAtaque.Siege && CartaInfo.faccion == CardUnity.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("Siege1");
            Cartica.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada = true;
            
            if (GM.GetComponent<GameManager>().J2CanPlay == false)
            {
                GM.GetComponent<GameManager>().IsPlaying = true;
            }
            else
            {
                GM.GetComponent<GameManager>().IsPlaying = false;
            }
            }
            else
            {
                Debug.Log("No es tu turno o esta carta ya esta en el campo");
            }
        }
        else if(CartaInfo.ataque == CardUnity.TipoDeAtaque.Melee && CartaInfo.faccion == CardUnity.Faccion.Demons )
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("Melee2");
            Cartica.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada = true;
            
            if (GM.GetComponent<GameManager>().J1CanPlay == false)
            {
                GM.GetComponent<GameManager>().IsPlaying = false;
            }
            else
            {
                GM.GetComponent<GameManager>().IsPlaying = true;
            }
            }
            else
            {
                Debug.Log("No es tu turno o esta carta ya esta en el campo");
            }
        }
        else if(CartaInfo.ataque == CardUnity.TipoDeAtaque.Ranged && CartaInfo.faccion == CardUnity.Faccion.Demons )
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("Ranged2");
            Cartica.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada = true;
            
            if (GM.GetComponent<GameManager>().J1CanPlay == false)
            {
                GM.GetComponent<GameManager>().IsPlaying = false;
            }
            else
            {
                GM.GetComponent<GameManager>().IsPlaying = true;
            }
            }
            else
            {
                Debug.Log("No es tu turno o esta carta ya esta en el campo");
            }
        }
        else if(CartaInfo.ataque == CardUnity.TipoDeAtaque.Siege && CartaInfo.faccion == CardUnity.Faccion.Demons )
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("Siege2");
            Cartica.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada = true;
            
            if (GM.GetComponent<GameManager>().J1CanPlay == false)
            {
                GM.GetComponent<GameManager>().IsPlaying = false;
            }
            else
            {
                GM.GetComponent<GameManager>().IsPlaying = true;
            }
            }
            else
            {
                Debug.Log("No es tu turno o esta carta ya esta en el campo");
            }
        }
    }
}


