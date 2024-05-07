using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    public void Volver() //Vuelve al menu inicial cuando se acaba el juego
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
