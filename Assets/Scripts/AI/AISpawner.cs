using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AISpawner : MonoBehaviour
{
    public GameObject aiPrefab;
    public GameObject bookPrefab;
    public GameObject janitorPrefab;
    public Transform[] spawnPoints;
    public Tilemap tileMap;
    

    [SerializeField] private float bookTimerMax = 5f;
    [SerializeField] private float aiTimerMax = 7f;
    [SerializeField] private float janitorTimerMax = 15f;

    private float bookTimer;
    private float aiTimer;
    private float janitorTimer;

    private List<Vector3> availablePlaces;

    private void Start()
    {
        //Position von jedem Floortile ermitteln:
        availablePlaces = new List<Vector3>();

        for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
        {
            for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
                Vector3 place = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
                }
            }
        }
    }

    void Update()
    {
        janitorTimer += Time.deltaTime;
        if (janitorTimer >= janitorTimerMax)
        {
            Vector3 spawnPosition = GetSpawnPosition();

            SpawnJanitor(spawnPosition);
            janitorTimer = 0;
        }


        bookTimer += Time.deltaTime;
        if (bookTimer >= bookTimerMax)
        {
            Vector3 spawnPosition = GetSpawnPosition();

            SpawnBook(spawnPosition);
            bookTimer = 0;
        }

        aiTimer += Time.deltaTime;
        if (aiTimer >= aiTimerMax)
        {
            SpawnAI();
            aiTimer = 0;
        }
    }
    
    public Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        int itr = 0;
        while (spawnPosition == Vector3.zero)
        {
            itr++;
            if (itr > 100)
            {
                Debug.LogWarning("Breaking out of While loop. No available spawn position found. This should not happen. Please check your code.");
                break;
            }
            spawnPosition = availablePlaces[Random.Range(0, availablePlaces.Count)];

            spawnPosition = new Vector3((Mathf.Round(spawnPosition.x / 0.16f) * 0.16f) - 0.08f, (Mathf.Round(spawnPosition.y / 0.16f) * 0.16f)- 0.08f, 0);
        }

        return spawnPosition;
    }

    public void SpawnJanitor(Vector3 position)
    {
        JanitorAI janitor = Instantiate(janitorPrefab, position, Quaternion.identity).GetComponent<JanitorAI>();
    }

    public void SpawnAI()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];
        GameObject ai = Instantiate(aiPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnBook()
    {
        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];
        BookTask book = Instantiate(bookPrefab, spawnPoint.position, Quaternion.identity).GetComponent<BookTask>();
        SetBookTask(book);
    }

    public void SpawnBook(Vector3 position)
    {
        BookTask book = Instantiate(bookPrefab, position, Quaternion.identity).GetComponent<BookTask>();
        SetBookTask(book);
    }

    public void SetBookTask(BookTask bookTask)
    {
        Section section = (Section)Random.Range(0, (int)Section.NONE - 1);
        bookTask.SetSection(section);
        
    }
}
