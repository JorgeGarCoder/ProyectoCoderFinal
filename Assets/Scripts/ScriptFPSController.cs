using UnityEngine;

public class ScriptFPSController : MonoBehaviour
{
    float moveSpeed = 3f, sensitivity = 1000f, verticalRotation;
    public Transform cam;
    public Animator animController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        MouseLook();
        //Jump();
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 InputPlayer = new Vector3(hor, 0, ver);

        transform.Translate(InputPlayer * moveSpeed * Time.deltaTime);

        if (InputPlayer != Vector3.zero)
        {
            animController.SetBool("IsWalking", true);
        }
        else
        {
            animController.SetBool("IsWalking", false);
        }
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //rotacion del personaje en X horizontal
        transform.Rotate(new Vector3(0, mouseX, 0));

        //rotacion de la camara 
        verticalRotation -= mouseY; //maneja el invertir vertical
        verticalRotation = Mathf.Clamp(verticalRotation, -70, 70); //limita el vertical
        cam.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    /*void Jump()
    {

    }*/
}