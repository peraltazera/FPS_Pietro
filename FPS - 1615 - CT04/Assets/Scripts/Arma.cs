using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    public Image arma;
    public Sprite armaNormal;
    public Sprite armaAtirando;
    public float timer = 0f;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.1f)
        {
            PararDeAtirar();
        }
    }

    public void Atirar()
    {
        timer = 0f;
        arma.sprite = armaAtirando;
    }

    public void PararDeAtirar()
    {
        arma.sprite = armaNormal;
    }
}
