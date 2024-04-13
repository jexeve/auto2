using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Necesario para trabajar con TextMeshPro


public class PlayerMove : MonoBehaviour
{

    public float velocidad = 5.0f;
    public float velocidadR = 40.0f;
    public float saltoF = 5.0f;

    private Rigidbody fisica;

    public TextMeshProUGUI textoM1;
    public TextMeshProUGUI textoM2;
    public TextMeshProUGUI textoM3;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fisica = GetComponent<Rigidbody>();

        // Obtener las referencias a los componentes de texto
        textoM1 = GameObject.Find("M1").GetComponent<TextMeshProUGUI>();
        textoM2 = GameObject.Find("M2").GetComponent<TextMeshProUGUI>();
        textoM3 = GameObject.Find("M3").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        // LOGICA DEL MOVIMIENTO DEL "PLATER"
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");

        if (x != 0 || y != 0) {
            Debug.Log("MOVIMIENTO DE TECLAS DETECTADO");
            textoM1.color = Color.red;
            textoM1.fontStyle = FontStyles.Strikethrough;
        }

        transform.Translate(new Vector3(x, 0.0f, y) * Time.deltaTime * velocidad);

        // ROTACION DE LA CAMERA, SE BLOQUEA EL CURSOR Y NO LO VE.
        float rotationY = Input.GetAxis("Mouse X");

        if (rotationY != 0) {
            Debug.Log("MOVIMIENTO DE RATON DETECTADO");
            textoM2.color = Color.red;
            textoM2.fontStyle = FontStyles.Strikethrough;
        }

        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * velocidadR, 0));

        // SALTA WILLY SALTA
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("TECLA ESPACIADORA PRESIONADA");
            textoM3.color = Color.red;
            textoM3.fontStyle = FontStyles.Strikethrough;
            fisica.AddForce(new Vector3(0, saltoF, 0), ForceMode.Impulse);
        }

    }
}
