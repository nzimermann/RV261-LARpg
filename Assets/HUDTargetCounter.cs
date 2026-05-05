using UnityEngine;
using TMPro;
using Vuforia;

public class HUDTargetCounter : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    private ObserverBehaviour[] observadores;

    void Start()
    {
        // Captura todos os alvos do Vuforia presentes na cena atual
        observadores = FindObjectsByType<ObserverBehaviour>(FindObjectsSortMode.None);
    }

    void Update()
    {
        int alvosAtivos = 0;

        foreach (ObserverBehaviour obs in observadores)
        {
            // Incrementa o contador se o motor reportar o status do alvo como rastreado
            if (obs.TargetStatus.Status == Status.TRACKED || obs.TargetStatus.Status == Status.EXTENDED_TRACKED)
            {
                alvosAtivos++;
            }
        }

        if (textoContador != null)
        {
            textoContador.text = "Targets Detectados: " + alvosAtivos;
        }
    }
}
