using UnityEngine;

public class ScriptFPSRB : MonoBehaviour
{
    Vector3 keyInput;
    Vector2 mouseInput;
    float moveSpeed = 3f, xRot, jumpForce;
    [SerializeField] float sensitivity = 150f;
    public Rigidbody rb;
    [SerializeField] Transform _camera;
    public Animator animController;
    public static bool canMove = true;

    void Awake()
    {
        animController = GetComponent<Animator>();
    }

    /*void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }*/

    void Update()
    {
        if (canMove)
        {
            MouseInput();
            KeyInput();
            RotatePlayer(mouseInput);
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer(keyInput);
        }
    }

    Vector2 MouseInput()
    {
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        return mouseInput;
    }

    Vector3 KeyInput()
    {
        keyInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        return keyInput;
    }

    public void MovePlayer(Vector3 keyinput)
    {
        Vector3 MoveVector = transform.TransformDirection(keyinput) * moveSpeed;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (keyinput != Vector3.zero && !ScriptGunSystem.shooting)
        {
            animController.SetBool("IsWalking", true);
        }
        else
        {
            animController.SetBool("IsWalking", false);
        }
    }

    public void RotatePlayer(Vector2 mouseinput)
    {
        if (!ScriptUIManager2.pauseActive)
        {
            //funciona
            //maneja la rotacion en el eje Y
            xRot -= (mouseinput.y * Time.fixedDeltaTime) * sensitivity;
            xRot = Mathf.Clamp(xRot, -50, 50); //limita el vertical
            //_camera.transform.parent.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            _camera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

            //maneja la rotacion en el eje X
            transform.Rotate(Vector3.up, (mouseinput.x * Time.fixedDeltaTime) * sensitivity);

        }
    }
}
