using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script contiene la funcion de cambiar las cartas al inicio del juego
public class CambiarCarta : MonoBehaviour
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

        if(Input.GetMouseButtonUp(1))  //Chequea si el click se hizo con el click derecho
        {
        if(Card.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies) //Chequea si es una carta del jugador 1
            {
                if(GM.GetComponent<GameManager>().Change1 == false) // Chequea si el jugador 1 puede cambiar la carta
                {
                deck1.GetComponent<Draw>().OnClick(); //Llama al metodo q saca una carta del deck
                deck1.GetComponent<Draw>().CardsInDeck.Add(Card); // Agrega la carta clickeada al deck nuevamente
                deck1.GetComponent<Draw>().CardsInHand.Remove(Card); // Quita la carta clickeada de la lisa de la mano
                Card.SetActive(false); //Quita el GameObject de la escena (Quita la carta en lo visual)
                
                GM.GetComponent<GameManager>().CantCartasCambiadas1 ++; //Chequea si se han cambiado mas d dos cartas
                if(GM.GetComponent<GameManager>().CantCartasCambiadas1 >= 2)
                {
                    GM.GetComponent<GameManager>().Change1 = true; //Se cambiaron mas de 2 entonces pone el booleano q perminte que se cambien las 
                    //cartas de jugador 1 en true para q no pueda cambiar mas
                }
                }
                else
                {
                    Debug.Log("No se puede cambiar la carta"); //No se puede cambiar otra carta
                }
            }
            //Prox se chequea lo mismo pero con el jugador 2
        else if(Card.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Demons)
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
