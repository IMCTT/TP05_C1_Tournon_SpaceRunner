using Player;

using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    
    [SerializeField] private float speed = 5;
   

 
    void Update()
    {
    
        transform.position += Vector3.left * (speed * Time.deltaTime);

        
    }
   
}
