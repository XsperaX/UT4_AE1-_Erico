using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text winText;    // Texto de victoria
    public TMP_Text loseText;   // Texto de derrota
    public float speed;
    public float jumpForce = 5f; //Con esto determino la fuerza de salto
    private bool isGrounded = true; //Para evitar saltos continuos, compruebo que ha llegado al suelo.
    private float movementXTeclado;
    private float movementYTeclado;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        count = 0; //hacer que el contador esté a 0
        SetScoreText();
        rb = GetComponent<Rigidbody>();

        // Ocultamos los textos al empezar
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    // FixedUpdate el que explicaste tiburcio que era para las físicas.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementXTeclado, 0.0f, movementYTeclado);
        rb.AddForce(movement * speed);
    }

    // Update añadido para el salto
    void Update()
    {
        // Si se pulsa la barra espaciadora y está en el suelo, salta
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // evita saltos dobles
        }

        // ⭐ Si ganas → volver al menú pulsando M
        if (winText.gameObject.activeSelf && Keyboard.current.mKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Menu_Principal");
        }

        // ⭐ Si pierdes → reiniciar con R
        if (loseText.gameObject.activeSelf && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // El movimiento
    private void OnMove(InputValue movement)
    {
        Vector2 actualMovement = movement.Get<Vector2>();

        movementXTeclado = actualMovement.x;
        movementYTeclado = actualMovement.y;
    }

    // Las colisiones con los Pickups
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            //añadir 1 al contador al coger un pickup
            count = count + 1;
            SetScoreText();
        }
    }

    // Detecta colisión con el suelo y con el enemigo
    private void OnCollisionEnter(Collision collision)
    {
        // Si toca el suelo, vuelve a poder saltar
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Si toca al enemigo → pierdes
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destruye el jugador

            // Mostrar mensaje de derrota
            loseText.gameObject.SetActive(true);
            loseText.text = "¡Qué lástima! ¡Has perdido!\nPulsa R para reiniciar";
        }
    }

    // Actualiza la puntuación y comprueba si ganas
    void SetScoreText()
    {
        ScoreText.text = "Puntuación: " + count.ToString();    //Pongo Puntuación para tener el juego en Español.

        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            winText.text = "¡Has ganado!\nPulsa M para volver al menú principal";

            //Destruimos a todos los enemigos al ganar
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemigo in enemigos)
            {
                Destroy(enemigo);
            }
        }
    }
}
