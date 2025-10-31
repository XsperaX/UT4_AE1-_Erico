using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text winText;
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
        winText.gameObject.SetActive(false);
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

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruye el jugador
            Destroy(gameObject);

            // Pone que pierdes
            winText.gameObject.SetActive(true);
            winText.text = "¡Que lástima! ¡Has perdido!\nPulsa R para reiniciar";
        }
    }

    // Actualiza la puntuación y comprueba si ganas
    void SetScoreText()
    {
        ScoreText.text = "Puntuación: " + count.ToString();    //Pongo Puntuación para tener el juego en Español.

        if (count >= 12)
        {
            winText.gameObject.SetActive(true);
            winText.text = "¡Has ganado!\nPulsa R para reiniciar"; // Mensaje al ganar
            Destroy(GameObject.FindGameObjectWithTag("Enemy")); //Destruimos al malote al ganar
        }
    }
}
