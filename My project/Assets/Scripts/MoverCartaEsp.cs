using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCartaEsp : MonoBehaviour
{
    private GameObject Zona;
    public GameObject Carta;

    public CartasEspeciales CartaInfo;
    private GameObject GM;
    public void Clickear()
    {
        GM = GameObject.Find("GameManager");

        if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaClima && CartaInfo.faccion == CartasEspeciales.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("zonaClima");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck1.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaClima && CartaInfo.faccion == CartasEspeciales.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("zonaClima");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck2.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoM1)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("AumentoMelee1");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck1.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
            
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoR1)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("AumentoRanged1");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck1.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoS1)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("AumentoSiege1");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck1.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoM2)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("AumentoMelee2");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck2.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoR2)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("AumentoRanged2");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck2.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
        else if(CartaInfo.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoS2)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && CartaInfo.CartaJugada == false)
            {
            Zona = GameObject.Find("AumentoSiege2");
            Carta.transform.SetParent(Zona.transform, false);
            CartaInfo.CartaJugada=true;
            //deck2.GetComponent<Draw>().CardsInHand.Remove(Carta);
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
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
    }
}
