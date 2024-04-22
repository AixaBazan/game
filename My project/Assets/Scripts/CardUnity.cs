using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardUnity", menuName = "UnityCard")]
public class CardUnity : Card
{
    public enum Clasificacion{
        Plata,
        Oro
    }
    public enum TipoDeAtaque
    {
        Melee,
        Ranged,
        Siege
    }
    public enum Faccion 
    {
        Fairies,
        Demons
    }
    public Sprite imagen;
    public bool CartaJugada = false;
    public Sprite FONDO;
    public Faccion faccion;
    public int PoderOriginal;
    public int PuntosDePoder;
    public TipoDeAtaque ataque;
    public Clasificacion categoria;
}
