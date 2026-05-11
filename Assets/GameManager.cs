using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    // Armazena o valor do dado lido. 0 significa que não há dano pendente.
    public int ValorDadoPendente { get; set; } = 0;

    // Referência direta para o script anexado ao Multi-Target
    public CalculoFaceDado dadoFisico;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        // Detecta o pressionamento da barra de espaço
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SimularLeituraDeDado();
            //if (dadoFisico != null)
            //{
            //    ValorDadoPendente = dadoFisico.ObterFaceSuperior();
            //    Debug.Log("Valor físico registrado no GameManager: " + ValorDadoPendente);
            //}
            //else
            //{
            //    Debug.LogError("O script CalculoFaceDado não foi atribuído no GameManager.");
            //}
        }
    }

    // Função provisória para simular o comportamento da câmera
    public void SimularLeituraDeDado()
    {
        ValorDadoPendente = Random.Range(1, 7);
        Debug.Log("Dado simulado lido: " + ValorDadoPendente);
    }
}
