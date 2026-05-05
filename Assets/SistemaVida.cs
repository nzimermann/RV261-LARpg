using UnityEngine;
using TMPro; // Obrigatório para manipular TextMeshPro via código

public class SistemaVida : MonoBehaviour
{
    public int vidaMaxima = 10;
    private int vidaAtual;

    // Arraste o seu objeto de texto para este campo no Inspector do Unity
    public TMP_Text textoVidaHUD;
    
    // Referência ao motor de animação
    private Animator animator;
    private Collider colisorPersonagem;
    private bool estaMorto = false;

    void Start()
    {
        vidaAtual = vidaMaxima;

        // Busca o Animator no objeto atual ou nos filhos (malha)
        animator = GetComponentInChildren<Animator>();
        colisorPersonagem = GetComponent<Collider>();

        AtualizarTextoHUD();
    }

    public void ReceberDano(int quantidade)
    {
        // Ignora o dano se já estiver morto
        if (estaMorto) return;

        vidaAtual -= quantidade;
        AtualizarTextoHUD();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    private void AtualizarTextoHUD()
    {
        if (textoVidaHUD != null)
        {
            textoVidaHUD.text = vidaAtual.ToString();
        }
    }

    private void Morrer()
    {
        Debug.Log($"{gameObject.name} foi eliminado.");
        // Desativa a renderização e o colisor do personagem (e o texto some junto pois é filho)
        // gameObject.SetActive(false);

        estaMorto = true;

        // Dispara a transição de estado no Animator
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        // Desativa o colisor para que o Raycast ignore o cadáver na mesa
        if (colisorPersonagem != null)
        {
            colisorPersonagem.enabled = false;
        }

        // Oculta o número da HUD
        if (textoVidaHUD != null)
        {
            textoVidaHUD.gameObject.SetActive(false);
        }
    }
}
