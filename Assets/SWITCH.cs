using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading

public class MainMenu : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void PlayGame()
    {
        // Load the game scene. Replace "GameScene" with the actual name of your game scene.
        SceneManager.LoadScene("Main");
    }
}
