using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Llama a esta función desde el botón "Jugar"
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    // Nivel 2
    public void NivelExtra()
    {
        SceneManager.LoadScene("Nivel2");
    }

    public void Salir()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
