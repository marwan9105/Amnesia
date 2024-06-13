using UnityEngine;

public class GameCursorManager : MonoBehaviour
{
    void Start()
    {
        // Masquer le curseur et le verrouiller au centre de l'écran
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Exemple de code pour gérer le curseur en fonction de l'état du jeu
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Rendre le curseur visible et déverrouillé
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
