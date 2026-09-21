using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEspawener : MonoBehaviour
{
    [SerializeField] private GameObject background1;
    
    
    [SerializeField] private LayerMask bgLayer;

    [SerializeField] private Vector2 bgReSpawn;


    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!CheckLayerInMask1(bgLayer, other.gameObject.layer))
        {
            background1.transform.position = bgReSpawn;
            
        }
        

    }
    public static bool CheckLayerInMask1(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
