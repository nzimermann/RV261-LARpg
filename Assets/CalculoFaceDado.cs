using UnityEngine;

public class CalculoFaceDado : MonoBehaviour
{
    // Eixos locais das 6 faces estruturais do Multi-Target
    private readonly Vector3[] eixosLocais = new Vector3[]
    {
        Vector3.up,      // Top
        Vector3.down,    // Bottom
        Vector3.left,    // Left
        Vector3.right,   // Right
        Vector3.forward, // Front
        Vector3.back     // Back
    };

    // Valores atrelados à respectiva face no array de eixos (Ajuste conforme seu mapeamento no Target Manager)
    private readonly int[] valoresFaces = { 1, 6, 3, 4, 5, 2 };

    public int ObterFaceSuperior()
    {
        float maiorAlinhamento = -Mathf.Infinity;
        int valorFaceSuperior = 0;

        for (int i = 0; i < eixosLocais.Length; i++)
        {
            // Traduz a rotação local da face em relação à câmera para as coordenadas do espaço global
            Vector3 vetorGlobalFace = transform.TransformDirection(eixosLocais[i]);

            // Compara o vetor da face com o vetor constante oposto à gravidade
            float produtoEscalar = Vector3.Dot(vetorGlobalFace, Vector3.up);

            if (produtoEscalar > maiorAlinhamento)
            {
                maiorAlinhamento = produtoEscalar;
                valorFaceSuperior = valoresFaces[i];
            }
        }

        Debug.Log("Valor da face superior: " + valorFaceSuperior);

        return valorFaceSuperior;
    }
}
