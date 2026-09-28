using System.Threading;
using UnityEngine;
using TMPro;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private AudioSource audioSourceJump;
        [SerializeField] private AudioSource audioSourceLand;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private UiManager uiManager;
        [SerializeField] PlayerSettings playerSettings;
        [SerializeField] FloorDetect floorDetect;
        [SerializeField] private LayerMask extraLifeLayerMask;
        [SerializeField] private Collider2D playerCollider;
        [SerializeField] private TMP_Text invincibilityTimer;
        [SerializeField] private LayerMask invincibilityLayerMask;

        bool onInvincibility = false;
        float timer = 0;

        private Rigidbody2D rb;


        void Start()
        {
            playerSettings.currentLife = playerSettings.initialLife;
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && floorDetect.isGrounded)
            {
                audioSourceJump.Play();
                floorDetect.isGrounded = false;
                animator.SetTrigger("Jumped");

                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * playerSettings.jumpForce, ForceMode2D.Impulse);
            }

            if (onInvincibility)
            {
                timer += Time.deltaTime;
                invincibilityTimer.text = timer.ToString("INVINCIBLE!");
            }


            if (timer >= 5)
            {
                onInvincibility = false;
                //playerCollider.enabled = true;
                invincibilityTimer.text = null;
                timer = 0;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (FloorDetect.CheckLayerInMask(enemyLayer, other.gameObject.layer) && !onInvincibility)
            {
                animator.SetTrigger("Death");
                playerSettings.currentLife--;
                uiManager.SetLife(playerSettings.currentLife);
            }
            else if (FloorDetect.CheckLayerInMask(extraLifeLayerMask, other.gameObject.layer))
            {
                playerSettings.currentLife++;
                uiManager.SetLife(playerSettings.currentLife);
            }
            else if (FloorDetect.CheckLayerInMask(invincibilityLayerMask, other.gameObject.layer))
            {
                Invincibility();
            }
            else
            {
                audioSourceLand.Play();
            }
        }

        private void Invincibility()
        {
            onInvincibility = true;
            
        }
    }
}