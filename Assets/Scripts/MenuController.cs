using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        // Rendre le curseur visible et déverrouillé au début
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Méthode appelée lorsque le bouton "Jouer" est cliqué
    public void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked");

        // Masquer le curseur et le verrouiller au centre de l'écran
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Chargez la scène de jeu (assurez-vous que le nom de la scène est correct)
        SceneManager.LoadScene("GameScene");
    }

    // Méthode appelée lorsque le bouton "Paramètre" est cliqué
    public void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked");

        // Affiche les paramètres ou chargez la scène des paramètres
        SceneManager.LoadScene("SettingsScene");
    }

    // Méthode appelée lorsque le bouton "Quitter" est cliqué
    public void OnQuitButtonClicked()
    {
        Debug.Log("Quit button clicked");

        // Quitter l'application
        Application.Quit();

        // Affiche un message dans l'éditeur Unity pour confirmer l'action (ne fonctionne pas dans le build final)
        Debug.Log("Game is exiting");
    }
}
