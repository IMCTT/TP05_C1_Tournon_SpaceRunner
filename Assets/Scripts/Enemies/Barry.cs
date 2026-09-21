using UnityEngine;

public class Barry : MonoBehaviour
{
    [SerializeField] private Animator animator;

    
    void Update()
    {
        animator.SetTrigger("Barry");
    }
}
