using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Script asociado al menu inicial
public class MenuInicial : MonoBehaviour
{
    public void Jugar() //Va para la escena del juego al tocar el boton jugar
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    
}
