using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class CartaEspecialDisplay : MonoBehaviour
{
    public CartasEspeciales card;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public Image Fondo;
    public Image fotico;
    public TMP_Text tipo;
    void Start()
    {
        nameText.text = card.nombre;
        descriptionText.text = card.descripcion;
        fotico.sprite = card.imagen;
        tipo.text = card.tipe.ToString();
        Fondo.sprite = card.FONDO;
    }

}

