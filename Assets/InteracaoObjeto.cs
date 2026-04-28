using UnityEngine;
using UnityEngine.InputSystem;

public class InteracaoObjeto : MonoBehaviour
{
    private Vector3 escalaOriginal;
    private bool estaAmpliado = false;

    void Start()
    {
        // Armazena a escala exata que o objeto possui no momento em que a cena inicia
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        bool inputDetectado = false;
        Vector2 posicaoTela = Vector2.zero;

        // Captura entrada via Novo Sistema de Input (Mouse ou Touch)
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            inputDetectado = true;
            posicaoTela = Mouse.current.position.ReadValue();
        }
        else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            inputDetectado = true;
            posicaoTela = Touchscreen.current.primaryTouch.position.ReadValue();
        }

        // Executa o Raycast se houver input
        if (inputDetectado)
        {
            Ray raio = Camera.main.ScreenPointToRay(posicaoTela);
            RaycastHit hit;

            if (Physics.Raycast(raio, out hit))
            {
                // Valida colisão com este objeto ou qualquer sub-objeto (filho) dele
                if (hit.transform.IsChildOf(this.transform) || hit.transform == this.transform)
                {
                    AlternarEscala();
                }
            }
        }
    }

    private void AlternarEscala()
    {
        estaAmpliado = !estaAmpliado;

        if (estaAmpliado)
        {
            // Aumenta o objeto em 20%
            transform.localScale = escalaOriginal * 1.2f;
        }
        else
        {
            // Restaura a escala base
            transform.localScale = escalaOriginal;
        }
    }
}

// CÓDIGO INICIAL

//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InteracaoObjeto : MonoBehaviour
//{
//    private Renderer objRenderer;

//    void Start()
//    {
//        objRenderer = GetComponent<Renderer>();
//    }

//    void Update()
//    {
//        bool isPressed = false;
//        Vector2 screenPosition = Vector2.zero;

//        // Detecta clique do mouse (Editor/PC)
//        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
//        {
//            isPressed = true;
//            screenPosition = Mouse.current.position.ReadValue();
//        }
//        // Detecta toque na tela (Mobile)
//        else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
//        {
//            isPressed = true;
//            screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
//        }

//        // Executa o Raycast
//        if (isPressed)
//        {
//            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
//            RaycastHit hit;

//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.collider.gameObject == this.gameObject)
//                {
//                    ExecutarAcao();
//                }
//            }
//        }
//    }

//    private void ExecutarAcao()
//    {
//        Debug.Log("Objeto detectado e interagido: " + gameObject.name);

//        if (objRenderer != null)
//        {
//            objRenderer.material.color = Color.red;
//        }
//    }
//}