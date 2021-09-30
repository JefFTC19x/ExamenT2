using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    private int Puntaje =0;
    private int Vidas =3;
   
    public Text scoreText;
    public Text NVidas;
    
    
    void Start()
    {
        scoreText.text = " Puntaje: " + Puntaje ;
        NVidas.text = "Vidas: " + Vidas;
    }

    public int GetScore()
    {
        return this.Puntaje;
    }

    public void PlusScore(int score)
    {
        this.Puntaje+= score;  
        scoreText.text = " Puntaje: " + Puntaje ;      
    }

    public void paraVidas(int menos)
    {
        this.Vidas+= menos;   
        NVidas.text = "Vidas: " + Vidas;     
    }   
}