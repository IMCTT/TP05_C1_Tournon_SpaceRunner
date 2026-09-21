
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float rotation = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        rb.AddTorque(rotation * Time.deltaTime, ForceMode2D.Force);
    }
}
