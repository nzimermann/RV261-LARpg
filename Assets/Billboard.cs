using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cameraPrincipal;

    void Start()
    {
        // Captura a ARCamera automaticamente
        cameraPrincipal = Camera.main;
    }

    void LateUpdate()
    {
        if (cameraPrincipal != null)
        {
            // Faz o texto imitar a rotação exata da câmera, encarando-a perfeitamente
            transform.rotation = cameraPrincipal.transform.rotation;
        }
    }
}