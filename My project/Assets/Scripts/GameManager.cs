using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsPlaying = false; //Si esta en false es el turno del jugador 1, si esta en true es el turno del jugador 2
    public bool J1CanPlay = false; // Mientras este en false, el jugador 1 puede jugar
    public bool J2CanPlay = false; // Mientras este en false, el jugador 2 puede jugar
    // booleanos q indican si se puede o no cambiar una carta(solo es posible al iniciar el juego)
    public bool Change1 = false; //Este booleno indica si se puede cambiar la carta del jugador 1 (si esta en false se puede)
    public bool Change2 = false; //Este booleno indica si se puede cambiar la carta del jugador 2 (si esta en false se puede)
    public List<GameObject> SenuelosJugados = new List<GameObject>();  
    public int CantCartasCambiadas1 = 0; //Lleva la cuenta d cuantas cartas se ha cambiado el jugador 1
    public int CantCartasCambiadas2 = 0; //Lleva la cuenta de cuantas cartas ha cambiado el jugador 2
    GameObject deck1;
    GameObject deck2;
    GameObject Counter1;
    GameObject Counter2;
    GameObject Cementerio1;
    GameObject Cementerio2;
    int RG1 = 0; //Este entero lleva la cuenta de las rondas ganadas del jugador 1
    public TMP_Text RondasGanadas1;
    int RG2 = 0; //Este entero lleva la cuenta de las rondas ganadas por el jugador 2
    public TMP_Text RondasGanadas2;
    GameObject Metodos; //Este es un EmptyGameObject q contiene al script efectos, a traves de el puedo acceder a unos metodos q necesito gestionar aqui
    void Start()
    {
        deck1 = GameObject.Find("Deck1");
        deck2 = GameObject.Find("Deck2");
        Counter1 = GameObject.Find("ContadorPlayer1");
        Counter2 = GameObject.Find("ContadorPlayer2");
        Metodos = GameObject.Find("metodos");
        Cementerio1 = GameObject.Find("Cementery1");
        Cementerio2 = GameObject.Find("Cementery2");
    }

    void Update()
    {
        if(J1CanPlay == true && J2CanPlay == true)
        {
            EndRound();
        }
        if(J1CanPlay == true && deck2.GetComponent<Draw>().CardsInHand.Count == 0)
        {
            EndRound();
        }
        if(J2CanPlay == true && deck1.GetComponent<Draw>().CardsInHand.Count == 0)
        {
            EndRound();
        }
        if(deck1.GetComponent<Draw>().CardsInHand.Count == 0 && deck2.GetComponent<Draw>().CardsInHand.Count == 0)
        {
            EndRound();
        }
        
    }
    public void EndRound() //Metodo para indicar que se acabo la ronda
    {
        //Todas las cartas del campo van al cementerio
        Metodos.GetComponent<Efectos>().EliminarCartas();
        Metodos.GetComponent<Efectos>().EliminarCartasAum();
        Metodos.GetComponent<Efectos>().EliminarCartasClima();
        foreach (GameObject Carta in SenuelosJugados)
        {
            if(Carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
            {
                Carta.transform.SetParent(Cementerio1.transform, false);
                Cementerio1.GetComponent<Cementery>().DeadCards.Add(Carta);
                Carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada = false;
            }
            else if(Carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Demons)
            {
                Carta.transform.SetParent(Cementerio2.transform, false);
                Cementerio2.GetComponent<Cementery>().DeadCards.Add(Carta);
                Carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada = false;
            }
        }
        //Se define quien gano
        if(Counter1.GetComponent<Contador>().Sum > Counter2.GetComponent<Contador>().Sum)
        {
            Debug.Log("El jugador 1 gano la ronda");
            RG1 ++ ;
        }
        else if(Counter1.GetComponent<Contador>().Sum < Counter2.GetComponent<Contador>().Sum)
        {
            Debug.Log("El jugador 2 gano la ronda");
            RG2 ++ ;
        }
        else if(Counter1.GetComponent<Contador>().Sum == Counter2.GetComponent<Contador>().Sum)
        {
            Debug.Log("Empate!");
            RG1 ++ ;
            RG2 ++ ;
        }
        RondasGanadas1.text = RG1.ToString();
        RondasGanadas2.text = RG2.ToString();
        Checkeador();
    }
    public void Checkeador()
    {
        if((RG1 == 0 && RG2  == 1) || (RG1 == 1 && RG2 == 0) || (RG1 == 1 && RG2 == 1))
        {
            NewRound();
        }
        else if((RG1 == 2 && RG2 == 0) || (RG1 == 2 && RG2 == 1))
        { 
            Player1Win();
        }
        else if((RG1 == 0 && RG2 == 2) || (RG1 == 1 && RG2 == 2))
        {
            Player2Win();
        }
    }
    public void NewRound()
    {
        Debug.Log("Se inicio una nueva ronda");
        
        //El jugador 1 roba dos cartas
        for (int i = 0; i < 2; i++)
        {
            deck1.GetComponent<Draw>().OnClick();
        }
        //Si la mano tiene mas de 10 cartas, se envian al cementerio las cartas sobrantes
        int n = deck1.GetComponent<Draw>().CardsInHand.Count;
        if(n > 10)
        {
            List <GameObject> CardsToRemove = new List<GameObject>();
            for (int i = n -1 ; i >= 10; i--)
            {
                CardsToRemove.Add(deck1.GetComponent<Draw>().CardsInHand[i]);
            }
            foreach (GameObject card in CardsToRemove)
            {
                card.transform.SetParent(Cementerio1.transform, false);
                Cementerio1.GetComponent<Cementery>().DeadCards.Add(card);
                deck1.GetComponent<Draw>().CardsInHand.Remove(card);
            }
        }
        //El jugador 2 roba dos cartas
        for (int i = 0; i < 2; i++)
        {
            deck2.GetComponent<Draw>().OnClick();
        }
        //Si la mano tiene mas de 10 cartas, se envian al cementerio las cartas sobrantes
        int s = deck2.GetComponent<Draw>().CardsInHand.Count;
        if(s > 10)
        {
            List <GameObject> CardsToRemove = new List<GameObject>();
            for (int i = s -1 ; i >= 10; i--)
            {
                CardsToRemove.Add(deck2.GetComponent<Draw>().CardsInHand[i]);
            }
            foreach (GameObject card in CardsToRemove)
            {
                card.transform.SetParent(Cementerio2.transform, false);
                Cementerio2.GetComponent<Cementery>().DeadCards.Add(card);
                deck2.GetComponent<Draw>().CardsInHand.Remove(card);
            }
        }

        //Actualizar los booleanos de los turnos para la nueva ronda 
        J1CanPlay = false;
        J2CanPlay = false;
        if(RG1 == 0 && RG2  == 1)
        {
            IsPlaying = true;
        } 
        else if(RG1 == 1 && RG2 == 0)
        {
            IsPlaying = false;
        }  
        else if(RG1 == 1 && RG2 == 1)
        {
            IsPlaying = false;
        }  
    }
    public void Player1Win()
    {
        SceneManager.LoadScene("Player1");
    }
    public void Player2Win()
    {
        SceneManager.LoadScene("Player2");
    }
}
