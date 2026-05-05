using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    // Armazena o valor do dado lido. 0 significa que não há dano pendente.
    public int ValorDadoPendente { get; set; } = 0;

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
        }
    }

    // Função provisória para simular o comportamento da câmera
    public void SimularLeituraDeDado()
    {
        ValorDadoPendente = Random.Range(1, 7);
        Debug.Log("Dado simulado lido: " + ValorDadoPendente);
    }
}
