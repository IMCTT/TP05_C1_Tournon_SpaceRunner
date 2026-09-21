using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Runner/PlayerData", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float initialLife = 3;
    public float jumpForce = 10;

    public float currentLife = 0; 
}
