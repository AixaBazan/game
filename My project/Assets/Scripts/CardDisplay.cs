using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class CardDisplay : MonoBehaviour
{
    public CardUnity card;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image fotico;
    public TMP_Text power;
    public TMP_Text tipo;
    public Image fondo;

    void Start()
    {
        nameText.text = card.nombre;
        descriptionText.text = card.descripcion;
        fotico.sprite = card.imagen;
        power.text = card.PuntosDePoder.ToString();
        tipo.text = card.ataque.ToString();
        fondo.sprite = card.FONDO;
    }
   
}
