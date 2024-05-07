using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Efectos : MonoBehaviour
{
    public bool PoderActivado1 = false; //Este booleano comprueba si la carta lider del jugador 1 ya activo su efecto
    public bool PoderActivado2 = false; //Este booleano comprueba si la carta lider del jugador 2 ya activo su efecto 
    GameObject Hand1;
    GameObject deck1;
    GameObject Hand2;
    GameObject deck2;
    GameObject M1;
    GameObject R1;
    GameObject S1;
    GameObject M2;
    GameObject R2;
    GameObject S2;
    GameObject GM;
    GameObject Cementerio1;
    GameObject Cementerio2;
    GameObject zonaAumento;
    GameObject ZonaClima;
    List<GameObject> Melee_1 = new List<GameObject>();
    List<GameObject> Ranged_1 = new List<GameObject>();
    List<GameObject> Siege_1 = new List<GameObject>();
    List<GameObject> Melee_2 = new List<GameObject>();
    List<GameObject> Ranged_2 = new List<GameObject>();
    List<GameObject> Siege_2 = new List<GameObject>();
    List<GameObject> ClimasJugados = new List<GameObject>();
    GameObject other;
    int indice;

    void Start()
    {
        Hand1 = GameObject.Find("hand1");
        deck1 = GameObject.Find("Deck1");
        Hand2 = GameObject.Find("hand2");
        deck2 = GameObject.Find("Deck2");
        M1 = GameObject.Find("Melee1");
        R1 = GameObject.Find("Ranged1");
        S1 = GameObject.Find("Siege1");
        M2 = GameObject.Find("Melee2");
        R2 = GameObject.Find("Ranged2");
        S2 = GameObject.Find("Siege2");
        GM = GameObject.Find("GameManager");
        Cementerio1 = GameObject.Find("Cementery1");
        Cementerio2 = GameObject.Find("Cementery2");
        zonaAumento = GameObject.Find("ZonaAumento");
        ZonaClima = GameObject.Find("zonaClima");
        Melee_1 = M1.GetComponent<ZonaCM>().CardsInZone;
        Ranged_1 = R1.GetComponent<ZonaCM>().CardsInZone;
        Siege_1 = S1.GetComponent<ZonaCM>().CardsInZone;
        Melee_2 = M2.GetComponent<ZonaCM>().CardsInZone;
        Ranged_2 = R2.GetComponent<ZonaCM>().CardsInZone;
        Siege_2 = S2.GetComponent<ZonaCM>().CardsInZone;
        ClimasJugados = ZonaClima.GetComponent<ZonaClima>().CardsInZone;
    }

    //A continuacion aparecen los metodos que uso cuando se acaba la ronda
    public void EliminarCartas() //Este metodo envia todas las cartas de unidad del campo al cementerio, para ello se recorre cada lista
    {
        foreach (GameObject carta in Melee_1)
        {
            carta.transform.SetParent(Cementerio1.transform, false);
        }
        foreach (GameObject carta in Ranged_1)
        {
            carta.transform.SetParent(Cementerio1.transform, false);
        }
        foreach (GameObject carta in Siege_1)
        {
            carta.transform.SetParent(Cementerio1.transform, false);
        }
        foreach (GameObject carta in Melee_2)
        {
            carta.transform.SetParent(Cementerio2.transform, false);
        }
        foreach (GameObject carta in Ranged_2)
        {
            carta.transform.SetParent(Cementerio2.transform, false);
        }
        foreach (GameObject carta in Siege_2)
        {
            carta.transform.SetParent(Cementerio2.transform, false);
        }
    }
    public void EliminarCartasAum() //Este metodo envia al cementerio todas las cartas aumento que se encuentren en el campo
    {
        foreach (GameObject carta in zonaAumento.GetComponent<ZonaAumento>().CardsInZone)
        {
            //Verifico de que faccion es cada carta para enviarla a su respectivo cementerio
            if(carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
            {
                carta.transform.SetParent(Cementerio1.transform, false);
            }
            else 
            {
                carta.transform.SetParent(Cementerio2.transform, false);
            }
        }
    }

    public void EliminarCartasClima() //Este metodo envia al cementerio todas las cartas clima que se encuentren en el campo
    {
        foreach (GameObject carta in ClimasJugados)
        {
            //Verifico de que faccion es cada carta para enviarla a su respectivo cementerio
            if(carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
            {
                carta.transform.SetParent(Cementerio1.transform, false);
            }
            else 
            {
                carta.transform.SetParent(Cementerio2.transform, false);
            }
        }
    }

    //A continuacion aparecen los efectos de cada carta lider
    public void Leader1() //Este metodo activa la habilidad de la carta lider del deck "Fairies"
    {
        if(GM.GetComponent<GameManager>().IsPlaying == false)
        {
            if(PoderActivado1 == false)
            {
                GM.GetComponent<GameManager>().Change1 = true;
                Debug.Log("La carta lider 1 activo su habilidad");
                HL1();
                GM.GetComponent<GameManager>().IsPlaying = true;
                PoderActivado1 = true;
            }
            else
            {
                Debug.Log("La carta Lider ya activo su efecto");
            }
        }
        else
        {
            Debug.Log("No es el turno de jugador 1");
        }
    }
    public void HL1() //Habilidad lider 1: elimina la carta de mayor poder de cada fila del campo enemigo
    {
        List <GameObject> CartasMayorPoder = new List<GameObject>();
        int MayorPoder = 0;
        GameObject CartaMelee = null;
        int MayorPoder1 = 0;
        GameObject CartaRanged = null;
        int MayorPoder2 = 0;
        GameObject CartaSiege = null;
        
        foreach (GameObject Carta in Melee_2)
        {
            if(Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder)
            {
                MayorPoder = Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMelee = Carta;
            }
        }
        foreach (GameObject Carta in Ranged_2)
        {
            if(Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder1)
            {
                MayorPoder1 = Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaRanged = Carta;
            }
        }
        foreach (GameObject Carta in Siege_2)
        {
            if(Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder2)
            {
                MayorPoder2 = Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaSiege = Carta;
            }
        }
        if(CartaRanged != null)
        {
            CartasMayorPoder.Add(CartaRanged);
        }
        if(CartaSiege != null)
        {
            CartasMayorPoder.Add(CartaSiege);
        }
        if(CartaMelee != null)
        {
            CartasMayorPoder.Add(CartaMelee);
        }
        Debug.Log(CartasMayorPoder.Count);
        foreach(GameObject Carta in CartasMayorPoder)
        {
            Carta.transform.SetParent(Cementerio1.transform, false);
        }   
    } 
    public void HL2() // Habilidad lider 2: iguala a 10 el poder d las cartas de su campo
    {
        foreach (GameObject Carta in Melee_2)
        {
            Carta.GetComponent<CardDisplay>().card.PuntosDePoder = 10;
            Debug.Log( Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
        }
        foreach (GameObject Carta in Ranged_2)
        {
            Carta.GetComponent<CardDisplay>().card.PuntosDePoder = 10;
            Debug.Log( Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
        } 
        foreach (GameObject Carta in Siege_2)
        {
            Carta.GetComponent<CardDisplay>().card.PuntosDePoder = 10;
            Debug.Log( Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
        } 
    }

    public void Leader2() //Este metodo activa la habilidad de la carta lider del deck "Demons"
    {
        if(GM.GetComponent<GameManager>().IsPlaying == true)
        {
            if (PoderActivado2 == false)
            {
                GM.GetComponent<GameManager>().Change1 = true;
                Debug.Log("La carta lider 2 activo su habilidad");
                HL2();
                GM.GetComponent<GameManager>().IsPlaying = false;
                PoderActivado2 = true;
            }
            else
            {
                Debug.Log("La carta lider ya activo su efecto");
            }   
        }
        else
        {
            Debug.Log("No es el turno del jugador 2");
        }
    }

    //A continuacion se muestran los efectos de las cartas especiales
    public void Señuelo(GameObject senuelo) // Efecto de la carta senuelo
    {
        if(senuelo.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && senuelo.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                GameObject CartaACambiar = FCMP(Melee_1, Ranged_1, Siege_1);
                if(CartaACambiar != null)
                {
                    if(CartaACambiar.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Melee)
                    {
                        senuelo.transform.SetParent(M1.transform, false);
                    }
                    else if(CartaACambiar.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Ranged)
                    {
                        senuelo.transform.SetParent(R1.transform, false);
                    }
                    else if(CartaACambiar.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Siege)
                    {
                        senuelo.transform.SetParent(S1.transform, false);
                    }
                    CartaACambiar.transform.SetParent(Hand1.transform,false);
                    GM.GetComponent<GameManager>().SenuelosJugados.Add(senuelo);
                    deck1.GetComponent<Draw>().CardsInHand.Remove(senuelo);
                    deck1.GetComponent<Draw>().CardsInHand.Add(CartaACambiar);
                    senuelo.GetComponent<CartaEspecialDisplay>().card.CartaJugada = true;
                    CartaACambiar.GetComponent<CardDisplay>().card.CambiadaPorSenuelo = true;
                    GM.GetComponent<GameManager>().IsPlaying = true;
                }
                else
                {
                    Debug.Log("No hay cartas para sustituir disponibles");
                }
            }
            else
            {
                Debug.Log("La carta ya esta jugada o no es tu turno");
            }
        }
        else if(senuelo.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && senuelo.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                GameObject CartaACambiar = FCMP(Melee_2, Ranged_2, Siege_2);
                if(CartaACambiar != null)
                {
                    if(CartaACambiar.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Melee)
                {
                    senuelo.transform.SetParent(M2.transform, false);
                }
                else if(CartaACambiar.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Ranged)
                {
                    senuelo.transform.SetParent(R2.transform, false);
                }
                else if(CartaACambiar.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Siege)
                {
                    senuelo.transform.SetParent(S2.transform, false);
                }
                CartaACambiar.transform.SetParent(Hand2.transform,false);
                GM.GetComponent<GameManager>().SenuelosJugados.Add(senuelo);
                deck2.GetComponent<Draw>().CardsInHand.Remove(senuelo);
                deck2.GetComponent<Draw>().CardsInHand.Add(CartaACambiar);
                senuelo.GetComponent<CartaEspecialDisplay>().card.CartaJugada = true;
                CartaACambiar.GetComponent<CardDisplay>().card.CambiadaPorSenuelo = true;
                GM.GetComponent<GameManager>().IsPlaying = false;
                }
                else
                {
                    Debug.Log("No hay cartas para sustituir disponibles");
                }
            } 
            else
            {
                Debug.Log("La carta ya esta jugada o no es tu turno");
            }
        }  
    }
    public GameObject FCMP(List<GameObject> Melee, List<GameObject> Ranged, List<GameObject> Siege)//Metodo para encontrar la carta con mayor poder de plata del campo
    {
        int MayorPoder = 0;
        foreach (GameObject Carta in Melee)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder && Carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                MayorPoder = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                other = Carta;
            }
        }
        foreach (GameObject Carta in Ranged )
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder && Carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                MayorPoder = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                other = Carta;
            }
        }
        foreach (GameObject Carta in Siege)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder && Carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                MayorPoder = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                other = Carta;
            }
        }
        return other;
    }
    public void CartaDespeje(GameObject carta) // aqui chequeo q el efecto de la carta despeje se active solo cuando se pueda
    {
        if(carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Despeje();
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }
        if(carta.GetComponent<CartaEspecialDisplay>().card.faccion == CartasEspeciales.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && carta.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Despeje();
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }
    }
    public void Despeje() //Este es el metodo que activa el efecto de las cartas especiales tipo despeje
    {
        foreach (GameObject carta in ClimasJugados) //Revisa en la lista de los climas jugados cuales estan, para asi eliminar su efecto
        {
            if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 24)
            {
                SubirPoder(Melee_1);
                SubirPoder(Melee_2);
            }
            if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 34)
            {
                SubirPoder(Melee_1);
                SubirPoder(Melee_2);
            }
            if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 25)
            {
                SubirPoder(Ranged_1);
                SubirPoder(Ranged_2);
            }
            if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 35)
            {
                SubirPoder(Ranged_1);
                SubirPoder(Ranged_2);
            }
            if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 26)
            {
                SubirPoder(Siege_1);
                SubirPoder(Siege_2);
            }
            if(carta.GetComponent<CartaEspecialDisplay>().card.ID == 36)
            {
                SubirPoder(Siege_1);
                SubirPoder(Siege_2);
            }
        }
        EliminarCartasClima();
    }
    public void SubirPoder(List<GameObject> Lista)
    {
        foreach (GameObject carta in Lista)
        {
            if(carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                carta.GetComponent<CardDisplay>().card.PuntosDePoder += 2;
                Debug.Log( carta.GetComponent<CardDisplay>().card.nombre + "," + carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }
            else
            {
                Debug.Log( carta.GetComponent<CardDisplay>().card.nombre + "," + carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }  
        }
    }
    public void AumentoPorZona(GameObject other) //Este metodo es el q le paso a cada carta de aumento para q verifique d q zona es
    //y aplique el efecto Aumento
    {
        if(other.GetComponent<CartaEspecialDisplay>().card.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoM1)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && other.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Aumento(Melee_1);
            }
            else
            {
                Debug.Log("No se puede activar el efecto pq no es tu turno");
            } 
        }
        else if(other.GetComponent<CartaEspecialDisplay>().card.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoR1)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && other.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Aumento(Ranged_1);
            }
            else
            {
                Debug.Log("No se puede activar el efecto pq no es tu turno");
            }
        }
        else if(other.GetComponent<CartaEspecialDisplay>().card.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoS1)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && other.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Aumento(Siege_1);
            }
            else
            {
                Debug.Log("No se puede activar el efecto pq no es tu turno");
            }
        }
        else if(other.GetComponent<CartaEspecialDisplay>().card.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoM2)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && other.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Aumento(Melee_2);
            }
            else
            {
                Debug.Log("No se puede activar el efecto pq no es tu turno");
            }
        }
        else if(other.GetComponent<CartaEspecialDisplay>().card.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoR2)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && other.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Aumento(Ranged_2);
            }
            else
            {
                Debug.Log("No se puede activar el efecto pq no es tu turno");
            }    
        }
        if(other.GetComponent<CartaEspecialDisplay>().card.zone == CartasEspeciales.ZonaDeJuego.ZonaAumentoS2)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && other.GetComponent<CartaEspecialDisplay>().card.CartaJugada == false)
            {
                Aumento(Siege_2);
            }
            else
            {
                Debug.Log("No se puede activar el efecto pq no es tu turno");
            }   
        }
    }
    
    public void Aumento(List<GameObject> Lista) //Este metodo aumenta en 2 el poder de las cartas de plata de una lista
    {
        foreach (GameObject Carta in Lista)
        {
            if(Carta.GetComponent<CardDisplay>().card.categoria == CardUnity.Clasificacion.Plata)
            {
                Carta.GetComponent<CardDisplay>().card.PuntosDePoder += 2;
                Debug.Log( Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }  
            else
            {
                Debug.Log(Carta.GetComponent<CardDisplay>().card.nombre + "," + Carta.GetComponent<CardDisplay>().card.PuntosDePoder);
            }
        }
    }

    // A continuacion se muestran los efectos de las cartas de unidad
    public void Stole(GameObject carta) //Este metodo activa el efecto de robar una carta del deck
    {
        if(carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies)
        {
        if(GM.GetComponent<GameManager>().IsPlaying == false && carta.GetComponent<CardDisplay>().card.CartaJugada == false)
        {
        deck1.GetComponent<Draw>().OnClick();
        }
        else
        {
            Debug.Log("No se puede activar el efecto");
        }
        }
        else
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
            deck2.GetComponent<Draw>().OnClick();
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }   
    }
    public void Delete(GameObject Carta)  //Este metodo activa el efecto de eliminar la carta con mayor poder del rival
    {
         if(Carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                if((Melee_2.Count == 0) && (Ranged_2.Count == 0) && (Siege_2.Count == 0))
                {
                    return;
                }
                else
                {
                    BCCMP(Melee_2, Ranged_2, Siege_2).transform.SetParent(Cementerio2.transform, false);
                }   
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }  
        }
        else if(Carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                if((Melee_1.Count == 0) && (Ranged_1.Count == 0) && (Siege_1.Count == 0))
                {
                    return;
                }
                else
                {
                    BCCMP(Melee_1, Ranged_1, Siege_1).transform.SetParent(Cementerio1.transform, false);
                }
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }
    }

    public void DeleteMenorP(GameObject Carta)  //Este metodo activa el efecto de eliminar la carta con menor poder del rival
    {
        if(Carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                if((Melee_2.Count == 0) && (Ranged_2.Count == 0) && (Siege_2.Count == 0))
                {
                    return;
                }
                else
                {
                    bccmp(Melee_2, Ranged_2, Siege_2).transform.SetParent(Cementerio2.transform, false);
                }
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }  
        }
        else if(Carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                if((Melee_1.Count == 0) && (Ranged_1.Count == 0) && (Siege_1.Count == 0))
                {
                    return;
                }
                else
                {
                    bccmp(Melee_1, Ranged_1, Siege_1).transform.SetParent(Cementerio1.transform, false);
                }   
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }
    }
    public void Clean(GameObject Carta) //Este metodo activa el efecto de limpiar la fila del campo del rival(no vacia) con menos unidades
    //(Metodo disponible para cartas del deck 2)
    {
        if(GM.GetComponent<GameManager>().IsPlaying == true && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
        {
        List<GameObject> cartasParaDestruir = new List<GameObject>();

        if(BFNV() == 0)
        {
            cartasParaDestruir.AddRange(Melee_1);
        }
        else if(BFNV() == 1)
        {
            cartasParaDestruir.AddRange(Ranged_1);
        }
        else if(BFNV() == 2)
        {
            cartasParaDestruir.AddRange(Siege_1);
        }
        foreach (GameObject carta in cartasParaDestruir)
        {
            carta.transform.SetParent(Cementerio1.transform, false);
        }
        }
        else
        {
            Debug.Log("No se puede activar el efecto");
        }
    }

    public int BFNV() //Este metodo busca la fila no vacia con menos unidades del campo del jugador 1
    {
        int[] Cuenta = new int[3];
        int MenorCant = 20; 
        Cuenta[0] = Melee_1.Count;
        Cuenta[1] = Ranged_1.Count;
        Cuenta[2] = Siege_1.Count;
        for (int i = 0; i < Cuenta.Length; i++)
        {
            if(Cuenta[i] < MenorCant && Cuenta[i] != 0)
            {
                MenorCant = Cuenta[i];
                indice = i;
            }
        }
        return indice;
    }


    public GameObject bccmp(List<GameObject> Melee, List<GameObject> Ranged, List<GameObject> Siege) //Este metodo busca la carta con menor poder del campo del rival
    { 
        List<GameObject> CartaMenorPoder = new List<GameObject>();
        int MenorPoder = 100;
        int MenorPoder1 = 100;
        int MenorPoder2 = 100;
        int MenorPoder3 = 100;
        
        foreach (GameObject Carta in Melee)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder < MenorPoder)
            {
                MenorPoder = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMenorPoder.Add(Carta);
            }
        }
        foreach (GameObject Carta in Ranged)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder < MenorPoder1)
            {
                MenorPoder1 = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMenorPoder.Add(Carta);
            }
        }
        foreach (GameObject Carta in Siege)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder < MenorPoder2)
            {
                MenorPoder2 = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMenorPoder.Add(Carta);
            }
        }
        
        for (int i = 0; i < CartaMenorPoder.Count; i++)
        { 
            if((int)CartaMenorPoder[i].GetComponent<CardDisplay>().card.PuntosDePoder < MenorPoder3)
            {
                MenorPoder3 = (int)CartaMenorPoder[i].GetComponent<CardDisplay>().card.PuntosDePoder;
                other = CartaMenorPoder[i];
            }
        }

    return other;
    }
    public GameObject BCCMP(List<GameObject> Melee, List<GameObject> Ranged, List<GameObject> Siege) //Este metodo busca la carta con mayor poder del campo del rival
    {
        List <GameObject> CartaMayorPoder = new List<GameObject>();
        int MayorPoder = 0;
        int MayorPoder1 = 0;
        int MayorPoder2 = 0;
        int MP = 0;
        
        foreach (GameObject Carta in Melee)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder)
            {
                MayorPoder = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMayorPoder.Add(Carta);
            }
        }
        foreach (GameObject Carta in Ranged)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder1)
            {
                MayorPoder1 = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMayorPoder.Add(Carta);
            }
        }
        foreach (GameObject Carta in Siege)
        {
            if((int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder > MayorPoder2)
            {
                MayorPoder2 = (int)Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
                CartaMayorPoder.Add(Carta);
            }
        }
        
        for (int i = 0; i < CartaMayorPoder.Count; i++)
        { 
            if((int)CartaMayorPoder[i].GetComponent<CardDisplay>().card.PuntosDePoder > MP)
            {
                MP = (int)CartaMayorPoder[i].GetComponent<CardDisplay>().card.PuntosDePoder;
                other = CartaMayorPoder[i];
            }
        }

    return other;
    }

    //Este metodo chequea cuando se puede activar el efecto promedio
    // y se lo asigna a la carta segun su faccion
    public void AsignacionPoderPromedio(GameObject Carta)
    {
        if(Carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                promedio(Melee_1, Ranged_1, Siege_1);
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }  
        }
        else if(Carta.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && Carta.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                promedio(Melee_2, Ranged_2, Siege_2);
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }
    }
    //Este efecto calcula el promedio de poder entre todas las cartas del campo propio
    //Luego iguala el poder de todas las cartas a ese promedio.
    public void promedio(List<GameObject> Melee, List<GameObject> Ranged, List<GameObject> Siege) 
    {
        if(Melee.Count != 0 || Ranged.Count != 0 || Siege.Count != 0)
        {
        int suma = 0;
        int cantCartas = Melee.Count + Ranged.Count + Siege.Count;
        foreach (GameObject Carta in Melee)
        {
            suma += Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
        }
        foreach (GameObject Carta in Ranged)
        {
            suma += Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
        }
        foreach (GameObject Carta in Siege)
        {
         suma += Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
        }
        int promedio = suma / cantCartas;
        Debug.Log(promedio);
        foreach (GameObject Carta in Melee)
        {
            Carta.GetComponent<CardDisplay>().card.PuntosDePoder = promedio;
        }
        foreach (GameObject Carta in Ranged)
        {
            Carta.GetComponent<CardDisplay>().card.PuntosDePoder = promedio;
        }
        foreach (GameObject Carta in Siege)
        {
        Carta.GetComponent<CardDisplay>().card.PuntosDePoder = promedio;
        }
        }
        else
        {
            return;
        }
    } 

    //Este metodo chequea cuando se puede activar el efecto mult
    // y se lo asigna a la carta segun su faccion
    public void AsignacionPoderMult()
    {
        if(this.gameObject.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Fairies)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == false && this.gameObject.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                Mult(this.gameObject, Melee_1, Ranged_1, Siege_1);
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }  
        }
        else if(this.gameObject.GetComponent<CardDisplay>().card.faccion == CardUnity.Faccion.Demons)
        {
            if(GM.GetComponent<GameManager>().IsPlaying == true && this.gameObject.GetComponent<CardDisplay>().card.CartaJugada == false)
            {
                Mult(this.gameObject, Melee_2, Ranged_2, Siege_2);
            }
            else
            {
                Debug.Log("No se puede activar el efecto");
            }
        }
    }
    //Multiplica por n su ataque, siendo n la cantidad de cartas iguales a ella en el campo
    public void Mult(GameObject Carta,List<GameObject> Melee, List<GameObject> Ranged, List<GameObject> Siege)
    {
        int n = 1;
        if(Carta.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Melee)
        {
        foreach (GameObject carta in Melee)
        {
            if(carta.GetComponent<CardDisplay>().card.nombre == Carta.GetComponent<CardDisplay>().card.nombre)
            {
                Debug.Log("Se encontro una carta igual");
                n++;
            }
        }
        }
        else if(Carta.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Ranged)
        {
        foreach (GameObject carta in Ranged)
        {
            if(carta.GetComponent<CardDisplay>().card.nombre == Carta.GetComponent<CardDisplay>().card.nombre)
            {
                Debug.Log("Se encontro una carta igual");
                n++;
            }
        }
        }
        else  if(Carta.GetComponent<CardDisplay>().card.ataque == CardUnity.TipoDeAtaque.Siege)
        {
        foreach (GameObject carta in Siege)
        {
            if(carta.GetComponent<CardDisplay>().card.nombre == Carta.GetComponent<CardDisplay>().card.nombre)
            {
                Debug.Log("Se encontro una carta igual");
                n++;
            }
        }
        }
        Carta.GetComponent<CardDisplay>().card.PuntosDePoder = n * Carta.GetComponent<CardDisplay>().card.PuntosDePoder;
    }
}