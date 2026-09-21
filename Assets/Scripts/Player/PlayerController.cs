using UnityEngine;

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

        }
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (FloorDetect.CheckLayerInMask(enemyLayer, other.gameObject.layer))
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
            else
            {
                audioSourceLand.Play();
            }


        }


    }
}