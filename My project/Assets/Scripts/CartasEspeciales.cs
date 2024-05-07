using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Propiedades de las cartas especiales
[CreateAssetMenu(fileName = "New CartasEspeciales", menuName = "CartasEspeciales")]
public class CartasEspeciales : Card
{
    public enum ZonaDeJuego
    {
        ZonaClima,
        ZonaAumentoM1,
        ZonaAumentoR1,
        ZonaAumentoS1,
        ZonaAumentoM2,
        ZonaAumentoR2,
        ZonaAumentoS2,
        ZonaSenuelo

    }
    public enum Faccion
    {
        Fairies,
        Demons
    }
    public enum Tipo
    {
        Clima,
        Señuelo,
        Aumento,
        Despeje
    }
    public Tipo tipe;
    public ZonaDeJuego zone;
    public Faccion faccion;
    public Sprite imagen;
    public Sprite FONDO;
    public bool CartaJugada;
}
