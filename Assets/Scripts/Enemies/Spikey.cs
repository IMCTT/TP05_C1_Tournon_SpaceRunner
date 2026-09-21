using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikey : MonoBehaviour
{
    [SerializeField] private Animator animator;


    void Update()
    {
        animator.SetTrigger("Spikey");

    }
}
