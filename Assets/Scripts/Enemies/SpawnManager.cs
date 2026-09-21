using Player;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spikeyPrefab;
    [SerializeField] private GameObject barryPrefab;
    [SerializeField] private GameObject extralifePrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject deSpawnPoint;
    [SerializeField] private LayerMask extralifeLayerMask;
    [SerializeField] private LayerMask spikeyLayerMask;
    [SerializeField] private LayerMask barryLayerMask;
    [SerializeField] private LayerMask deSpawnLayerMask;


    [SerializeField] private float timeToSpawn;

    private float totalTime = 0;

    private GameObject spikey;
    private GameObject barry;
    public GameObject extraLife;

    private Vector2 spawnPosition;
    private Vector2 newSpawn;
    private bool spikeySpawned = false;
    private bool barrySpawned = false;
    private bool extraLifeSpawn = false;
    private int counter = 0;
    private float randomPosY;
    Vector2 spawn;

    void Start()
    {
        totalTime = 0;
        counter = 0;
        spawnPosition = spawnPoint.transform.position;

    }


    void Update()
    {
        totalTime += Time.deltaTime;
        SpawnSpikey();
        spawnBarry();
        spawnExtralife();
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

    }


    void SpawnSpikey()
    {
        randomPosY = Random.Range(-3.63f, -1f);

        newSpawn = new Vector2(0, randomPosY);
        spawn = spawnPosition + newSpawn;

        if (spikeySpawned == false)

        {

            spikey = Instantiate(spikeyPrefab, spawn, Quaternion.identity);
            spikeySpawned = true;
            counter++;

        }


    }
    void spawnBarry()
    {
        newSpawn = new Vector2(0, -4.3f);
        spawn = spawnPosition + newSpawn;

        if (barrySpawned == false && totalTime > timeToSpawn)
        {
            barry = Instantiate(barryPrefab, spawn, Quaternion.identity);
            barrySpawned = true;
            totalTime = 0;
            counter++;
        }
    }
    void spawnExtralife()
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

    public static bool CheckLayerInMask2(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }


}

