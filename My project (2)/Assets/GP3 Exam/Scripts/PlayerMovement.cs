using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public GameManagement management;

    void Start()
    {
        
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horizontal, 0, vertical);
        transform.Translate (movement * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            management.scoreBoard.ScoreCount();
            collision.gameObject.SetActive(false);
        }
    }

}
