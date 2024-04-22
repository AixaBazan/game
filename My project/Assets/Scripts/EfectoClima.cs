using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoClima : MonoBehaviour
{
    GameObject M1;
    GameObject R1;
    GameObject S1;
    GameObject M2;
    GameObject R2;
    GameObject S2;
    GameObject GM;
    void Start()
    {
        M1 = GameObject.Find("Melee1");
        R1 = GameObject.Find("Ranged1");
        S1 = GameObject.Find("Siege1");
        M2 = GameObject.Find("Melee2");
        R2 = GameObject.Find("Ranged2");
        S2 = GameObject.Find("Siege2");   
        GM = GameObject.Find("GameManager");
    }
    public void Clima(GameObject carta) //Con el ID d la carta le senalo la zona q va a afectar
    {
        if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 24)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Reduccion(M1.GetComponent<ZonaCM>().CardsInZone, M2.GetComponent<ZonaCM>().CardsInZone);
                M1.GetComponent<ZonaCM>().ClimaPlayer1On = true;
                M2.GetComponent<ZonaCM>().ClimaPlayer1On = true;  
            }
            else
            {
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
           
        }
        else if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 34)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Reduccion(M1.GetComponent<ZonaCM>().CardsInZone, M2.GetComponent<ZonaCM>().CardsInZone);
                M1.GetComponent<ZonaCM>().ClimaPlayer2On = true;
                M2.GetComponent<ZonaCM>().ClimaPlayer2On = true;  
            }
            else
            {
                Debug.Log("No es tu turno o la carta ya esta jugada");
            }
        }
        else if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 25)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false  && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Reduccion(R1.GetComponent<ZonaCM>().CardsInZone, R2.GetComponent<ZonaCM>().CardsInZone);
                R1.GetComponent<ZonaCM>().ClimaPlayer1On = true;
                R2.GetComponent<ZonaCM>().ClimaPlayer1On = true;  
            }
            else
            {
                Debug.Log("No es tu turno");
            }      
        }
        else if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 35)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true  && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Reduccion(R1.GetComponent<ZonaCM>().CardsInZone, R2.GetComponent<ZonaCM>().CardsInZone);
                R1.GetComponent<ZonaCM>().ClimaPlayer2On = true;
                R2.GetComponent<ZonaCM>().ClimaPlayer2On = true;  
            }
            else
            {
                Debug.Log("No es tu turno");
            }        
        }
        else if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 26)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false  && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Reduccion(S1.GetComponent<ZonaCM>().CardsInZone, S2.GetComponent<ZonaCM>().CardsInZone);
                S1.GetComponent<ZonaCM>().ClimaPlayer1On = true;
                S2.GetComponent<ZonaCM>().ClimaPlayer1On = true;  
            }
            else
            {
                Debug.Log("No es tu turno");
            }  
        }
        else if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 36)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true  && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Reduccion(S1.GetComponent<ZonaCM>().CardsInZone, S2.GetComponent<ZonaCM>().CardsInZone);
                S1.GetComponent<ZonaCM>().ClimaPlayer2On = true;
                S2.GetComponent<ZonaCM>().ClimaPlayer2On = true;  
            }
            else
            {
                Debug.Log("No es tu turno");
            }
        }
    }
    public void Reduccion(List<GameObject> Lista1, List<GameObject> Lista2) //Este metodo disminuye en 2 el poder de las cartas de plata de las listas requeridas
    {
        foreach (GameObject Carta in Lista1)
        {
            if(Carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                Carta.GetComponent<CardDisplay>().card.PuntosDePoder -= 2;
                Debug.Log( Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }  
            else
            {
                Debug.Log(Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }
        }
        foreach (GameObject Carta in Lista2)
        {
            if(Carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                Carta.GetComponent<CardDisplay>().card.PuntosDePoder -= 2;
                Debug.Log( Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }  
            else
            {
                Debug.Log(Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }
        }
    }
}
