using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartManager : MonoBehaviour
{
    public TMP_Text winText; // Referencia al texto de ganar/perder

    void Update()
    {
        // Solo permite reiniciar si el texto de ganar/perder está activo
        if (winText != null && winText.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
