using UnityEngine;

public class RotatePadlockCap : MonoBehaviour
{
    // Référence vers le cadenas pour vérifier le code
    public PadLockPassword padLock;

    // Référence vers l'objet PadlockCap à faire pivoter
    public GameObject padlockCap;

    // Position cible après la rotation
    public Vector3 targetPosition = new Vector3(5.139f, 5.034f, 5.158f);

    // Variable de suivi pour vérifier si la rotation a déjà été effectuée
    private bool rotated = false;

    // Fait pivoter l'objet PadlockCap lorsque le code est correct
    void Update()
    {
        if (padLock != null && padLock.isPasswordCorrect && !rotated)
        {
            RotateCap();
        }
    }

    // Fait pivoter l'objet PadlockCap de 90 degrés et le positionne à la position spécifiée
    void RotateCap()
    {
        if (padlockCap != null)
        {
            padlockCap.transform.Rotate(0, 90, 0);
            padlockCap.transform.position = targetPosition;
            rotated = true; // Marquer la rotation comme déjà effectuée
        }
    }
}
