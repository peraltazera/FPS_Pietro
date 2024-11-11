using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sensibilidadeMouse = 100f;
    public Transform jogador;
    private float rotacaoX = 0f;

    public CharacterController controller;
    public float velocidade = 4.0f;
    public float gravidade = -9f;

    public Vector3 aceleracaoY;

    public Arma arma;
    public Inimigo inimigo;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            arma.Atirar();

            Vector3 origem = transform.position;
            Vector3 direcao = transform.forward;
            Ray ray = new Ray(origem, direcao);

            RaycastHit informacao;
            bool hit = Physics.Raycast(ray, out informacao);

            if (informacao.collider.CompareTag("Inimigo"))
            {
                informacao.collider.GetComponent<Inimigo>().DestroyRespaw();
            }
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;
       
        rotacaoX -= mouseY;
        rotacaoX = Math.Clamp(rotacaoX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        jogador.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * velocidade * Time.deltaTime);

        aceleracaoY.y += gravidade * Time.deltaTime;
        controller.Move(aceleracaoY * Time.deltaTime);
    }
}
