using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] float movementSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Move(); 
    }

    private void Move()
    {
       var deltaX = Input.GetAxis("Horizontal") *Time.deltaTime * movementSpeed;
       var newXPos = transform.position.x + deltaX;

       transform.position = new Vector2(newXPos, transform.position.y); 
    }
}
