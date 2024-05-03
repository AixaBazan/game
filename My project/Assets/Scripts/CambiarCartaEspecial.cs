using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarCartaEspecial : MonoBehaviour
{
    public GameObject Card;
    GameObject GM;
    GameObject deck1;
    GameObject deck2;

    public void Change()
    {   
        GM = GameObject.Find("GameManager"); 
        deck1 = GameObject.Find("Deck1");
        deck2 = GameObject.Find("Deck2");
        if(Input.GetMouseButtonUp(1))
        {
        if(Card.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
            {
                if(GM.GetComponent<GameManager>().Change1 == false)
                {
                deck1.GetComponent<Draw>().OnClick();
                deck1.GetComponent<Draw>().CardsInDeck.Add(Card);
                deck1.GetComponent<Draw>().CardsInHand.Remove(Card);
                Card.SetActive(false);
                
                GM.GetComponent<GameManager>().CantCartasCambiadas1 ++;
                if(GM.GetComponent<GameManager>().CantCartasCambiadas1 >= 2)
                {
                    GM.GetComponent<GameManager>().Change1 = true;
                }
                }
                else
                {
                    Debug.Log("No se puede cambiar la carta");
                }
            }
        else if(Card.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().Change2 == false)
            {
            deck2.GetComponent<Draw>().OnClick();
            deck2.GetComponent<Draw>().CardsInDeck.Add(Card);
            deck2.GetComponent<Draw>().CardsInHand.Remove(Card);
            Card.SetActive(false);
            
            GM.GetComponent<GameManager>().CantCartasCambiadas2 ++;
            if(GM.GetComponent<GameManager>().CantCartasCambiadas2 >= 2)
            {
                GM.GetComponent<GameManager>().Change2 = true;
            }
            }
            else
            {
                Debug.Log("No se puede cambiar la carta");
            }
        }
    } 
    }
}


