using Player;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spikeyPrefab;
    [SerializeField] private GameObject barryPrefab;
    [SerializeField] private GameObject extralifePrefab;
    [SerializeField] private GameObject invinciblePrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject deSpawnPoint;
    [SerializeField] private LayerMask extralifeLayerMask;
    [SerializeField] private LayerMask spikeyLayerMask;
    [SerializeField] private LayerMask barryLayerMask;
    [SerializeField] private LayerMask deSpawnLayerMask;
    [SerializeField] private LayerMask invincibleLayerMask;


    [SerializeField] private float timeToSpawn;

    private float totalTime = 0;

    private GameObject spikey;
    private GameObject barry;
    private GameObject extraLife;
    private GameObject invincible;

    private Vector2 spawnPosition;
    private Vector2 newSpawn;
    private bool spikeySpawned = false;
    private bool barrySpawned = false;
    private bool extraLifeSpawn = false;
    private bool invincibiltySpawn = false;
    private int counter = 0;
    private int invcounter;
    private float randomPosY;
    Vector2 spawn;

    void Start()
    {
        totalTime = 0;
        counter = 0;
        invcounter = 0;
        spawnPosition = spawnPoint.transform.position;

    }


    void Update()
    {
        totalTime += Time.deltaTime;
        
        SpawnSpikey();
        SpawnBarry();
        SpawnExtraLife();
        SpawnInvincibility();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (CheckLayerInMask2(spikeyLayerMask, other.gameObject.layer))
        {
            Destroy(spikey);
            spikeySpawned = false;



        }
        if (CheckLayerInMask2(barryLayerMask, other.gameObject.layer))
        {
            Destroy(barry);
            barrySpawned = false;

        }
        if (CheckLayerInMask2(extralifeLayerMask, other.gameObject.layer))
        {
            Destroy(extraLife);
            extraLifeSpawn = false;

        }
        if (CheckLayerInMask2(invincibleLayerMask, other.gameObject.layer))
        {
            Destroy(invincible);
            invincibiltySpawn = false;

        }

    }


    void SpawnSpikey()
    {
        randomPosY = Random.Range(-3.63f, -1f);

        newSpawn = new Vector2(0, randomPosY);
        spawn = spawnPosition + newSpawn;

        if (!spikeySpawned)
        {

            spikey = Instantiate(spikeyPrefab, spawn, Quaternion.identity);
            spikeySpawned = true;
            counter++;
            invcounter++;
        }


    }
    void SpawnBarry()
    {
        newSpawn = new Vector2(0, -4.3f);
        spawn = spawnPosition + newSpawn;
        
        if (!barrySpawned && totalTime > timeToSpawn)
        {
            barry = Instantiate(barryPrefab, spawn, Quaternion.identity);
            barrySpawned = true;
            totalTime = 0;
            counter++;
            invcounter++;
        }
    }
    void SpawnExtraLife()
    {
        randomPosY = Random.Range(-3.63f, 1f);
        newSpawn = new Vector2(0, randomPosY);
        spawn = spawnPosition + newSpawn;

        if (counter >= 8 && extraLifeSpawn == false)
        {
            
            extraLife = Instantiate(extralifePrefab, spawn, Quaternion.identity);

            extraLifeSpawn = true;

            counter= 0;
        }
    }
    void SpawnInvincibility()
    {
        randomPosY = Random.Range(-3.63f, 1f);
        newSpawn = new Vector2(0, randomPosY);
        spawn = spawnPosition + newSpawn;

        if ( invcounter >= 5 && invincibiltySpawn == false)
        {
            
            invincible = Instantiate(invinciblePrefab, spawn, Quaternion.identity);
            Debug.Log("invincible");

            invincibiltySpawn = true;
            invcounter = 0;

        }
    }

    public static bool CheckLayerInMask2(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }


}

