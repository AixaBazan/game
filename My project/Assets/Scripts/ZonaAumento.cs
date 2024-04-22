using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaAumento : MonoBehaviour
{
    public List<GameObject> CardsInZone = new List<GameObject>();
    GameObject carta;
    GameObject Cementerio1;
    GameObject Cementerio2;
    GameObject deck1;
    GameObject deck2;

    void Start()
    {
        Cementerio1 = GameObject.Find("Cementery1");
        Cementerio2 = GameObject.Find("Cementery2");
        deck1 = GameObject.Find("Deck1");
        deck2 = GameObject.Find("Deck2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        carta = collision.gameObject;
        CardsInZone.Add(carta);
        if(carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
        {
            deck1.GetComponent<Draw>().CardsInHand.Remove(carta);
        }
        else
        {
            deck2.GetComponent<Draw>().CardsInHand.Remove(carta);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        carta = collision.gameObject;
        carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada = false;
        if(carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
        {
            Cementerio1.GetComponent<Cementery>().DeadCards.Add(carta);
        }
        else 
        {
             Cementerio2.GetComponent<Cementery>().DeadCards.Add(carta);
        }
        CardsInZone.Remove(carta);
    }
    
}
