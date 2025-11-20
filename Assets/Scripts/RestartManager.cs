using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartManager : MonoBehaviour
{
    public TMP_Text winText;   // Texto de victoria
    public TMP_Text loseText;  // Texto de derrota

    void Update()
    {
        // Si aparece el texto de victoria o derrota → permitir reiniciar
        bool canRestart =
            (winText != null && winText.gameObject.activeSelf) ||
            (loseText != null && loseText.gameObject.activeSelf);

        if (canRestart && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
