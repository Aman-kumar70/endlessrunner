using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb; // for Storing the rigibody component from the unity Inspector.
    public float speed = 5f; // for Forward speed.
    public float horispeed = 5f; // for Sideway speed.
    private float horizontalInput; // for Sideway Movement.
    private int count; // Var for Storing Score.
    public TextMeshProUGUI CountText; // To Show the Output of Score.
    public UIManager MenuManage;
    public TextMeshProUGUI ScoreMenu;
    public float jumpforce = 5f;
    private bool isGrounded;


    private void Start()
    {
        count = 0; // At Starting Score set to 0.
        SetCount(); // Displaying that Score is 0.
       
    }
    private void FixedUpdate() // For Physics related task like Rigibody Movement.
    {
        Vector3 forwardmove = Vector3.forward * speed * Time.fixedDeltaTime; // Continous Movement In forward Direction.
        Vector3 sidemove = Vector3.right * horizontalInput * horispeed * Time.fixedDeltaTime; // Sideway Movement by using User Input.
        
        rb.MovePosition(rb.position + forwardmove + sidemove ); // Applying the Movement via Rigibody Physics.

    }

    private void Update() // Check every frame for Input
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Taking input for Horizontal Movement Like A(-1)-> Left and D(1)-> Right.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision) // For Death logic.
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        else if (collision.gameObject.CompareTag("FallTrigger") || collision.gameObject.CompareTag("obstacle")) // Check if the player falls from the ground.
        {
            gameObject.SetActive(false);
            MenuManage.Menu.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other) // For Collectbies
    {
        if (other.gameObject.CompareTag("Pickup")) // Check if the player Collide with Collectbies.
        {
            other.gameObject.SetActive(false); //Make the Collectbies Inactive When collided.
            count += 1;
            SetCount();
        }
    }

    void SetCount() // function for Score Display
    {
        CountText.text = "Score: " + count.ToString(); //It will Display the Score in the Unity Scene via UI text.
        ScoreMenu.text = CountText.text;
    }
}
