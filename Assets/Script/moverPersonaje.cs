using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadMov = 5.0f;
    public float velocidadRot = 200.0f;
    public float x, y;
    private Animator animator;

    // Etiqueta del objeto que quieres interactuar
    public Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * velocidadRot, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMov);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        // Detectar objetos al frente usando un rayo
     
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ganador"))
        {
            Debug.Log("Haz gando");
            Time.timeScale = 0;
        }
        if (collision.collider.CompareTag("punto"))
        {
            collision.gameObject.SetActive(false);
            score++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Puntos: " + score;
    }
}
