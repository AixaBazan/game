using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ZonaCM : MonoBehaviour
{
    public List<GameObject> CardsInZone = new List<GameObject>();
    public GameObject carta;
    public int contador;
    public TMP_Text ContadorParcial;
    GameObject Cementerio1;
    GameObject Cementerio2;
    GameObject deck1;
    GameObject deck2;
    public bool ClimaPlayer1On = false;
    public bool ClimaPlayer2On = false;
    void Start()
    {
        Cementerio1 = GameObject.Find("Cementery1");
        Cementerio2 = GameObject.Find("Cementery2");
        deck1 = GameObject.Find("Deck1");
        deck2 = GameObject.Find("Deck2");
    }
    void Update()
    {
        ContadorParcial.text = contador.ToString();
        UpdateCounter();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        carta = collision.gameObject;
        carta.GetComponent<CardDisplay>().card.CambiadaPorSenuelo = false;
        CardsInZone.Add(carta);
        if(carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies)
        {
            deck1.GetComponent<Draw>().CardsInHand.Remove(carta);
        }
        else
        {
            deck2.GetComponent<Draw>().CardsInHand.Remove(carta);
        }
        if(ClimaPlayer1On == true && carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
        {
            carta.GetComponent<CardDisplay>().card.PuntosDePoder -= 2;
            Debug.Log(carta.GetComponent<CardDisplay>().card.nombre + ":" + carta.GetComponent<CardDisplay>().card.PuntosDePoder);
        }
        if(ClimaPlayer2On == true  && carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
        {
            carta.GetComponent<CardDisplay>().card.PuntosDePoder -= 2;
            Debug.Log(carta.GetComponent<CardDisplay>().card.nombre + ":" + carta.GetComponent<CardDisplay>().card.PuntosDePoder);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        carta = collision.gameObject;
        carta.GetComponent<CardDisplay>().card.PuntosDePoder = carta.GetComponent<CardDisplay>().card.PoderOriginal;
        carta.GetComponent<CardDisplay>().card.CartaJugada = false;
        if(carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies && carta.GetComponent<CardDisplay>().card.CambiadaPorSenuelo == false)
        {
            Cementerio1.GetComponent<Cementery>().DeadCards.Add(carta);
        }
        else if(carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Demons && carta.GetComponent<CardDisplay>().card.CambiadaPorSenuelo == false)
        {
             Cementerio2.GetComponent<Cementery>().DeadCards.Add(carta);
        }
        CardsInZone.Remove(carta);
        Debug.Log("Se elimino una carta");
    }
    public int UpdateCounter()
    {
        contador = 0;
        foreach (GameObject Carta in CardsInZone)
        {
            contador += Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
        }
        return contador;
    }
}
