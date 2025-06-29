using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float PlayerSpeed;
    public float JumpSpeed;
    public int PlayerHealth = 3;
    public GameObject LosePanel;
    public Rigidbody PlayerRB;
    public GameObject PlayerCamera;
    public bool isGrounded; 


    // Update is called once per frame
    void Update()
    {
        float horoizontal = Input.GetAxis("Horizontal") * PlayerSpeed;
        float vertical = Input.GetAxis("Vertical") * PlayerSpeed;
        PlayerRB.linearVelocity = new Vector3(horoizontal, PlayerRB.linearVelocity.y, vertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRB.AddForce(new Vector3(0, JumpSpeed, 0), ForceMode.Impulse);
        }

        MoveCamera();
    }

    float rotationCam = 0;
    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX, 0));

        float mouseY = Input.GetAxis("Mouse Y");
        rotationCam -= mouseY;

        PlayerCamera.transform.localRotation =
        Quaternion.Euler(rotationCam, 0, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerHealth--;
            other.gameObject.SetActive(false);

            if (PlayerHealth <= 0)
            {
                gameObject.SetActive(false);
                LosePanel.SetActive(true);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
