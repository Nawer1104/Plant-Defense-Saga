using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Transform> waypoints;

    public Transform spawnPoint;

    public GameObject zombiePrefab;

    public List<Zombie> zombies;

    private float delay = 2f;

    public int maxZombie = 5;

    public GameObject vfxSpawn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (zombies.Count < maxZombie)
        {
            if (delay <= 0)
            {
                delay = 1f;
                GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
                GameObject vfx = Instantiate(vfxSpawn, spawnPoint.position, Quaternion.identity);
                Destroy(vfx, 1f);
                zombies.Add(zombie.GetComponent<Zombie>());
            }
            else
            {
                delay -= Time.deltaTime;
            }

        }
    }
}