

//using System.Collections;
//using UnityEngine;

//public class StackSpawner : MonoBehaviour
//{
//    public GameObject stackPrefab;
//    public int numberOfStacksPerLine = 4;
//    public float stackSpacing = 1.5f;

//    public Color[] lineColors;

//    private int currentIndex = 0; 
//    private int linesSpawned = 0; 
//    private bool isSpawning = true;
//    private float currentZPosition = 30f;
//    private float currentXPosition = -2f;

//    void Start()
//    {
//        StartCoroutine(SpawnStacks());
//    }

//    IEnumerator SpawnStacks()
//    {
//        while (isSpawning)
//        { 

//            for (int i = 0; i < numberOfStacksPerLine; i++)
//            {
//                Vector3 spawnPosition = new Vector3(currentXPosition, .4f, currentZPosition + i * stackSpacing);

//                GameObject stackInstance = Instantiate(stackPrefab, spawnPosition, Quaternion.identity);

//                Renderer stackRenderer = stackInstance.GetComponent<Renderer>();

//                stackRenderer.material.color = lineColors[currentIndex];

//                yield return null;
//            }

//            linesSpawned++;
//            if (linesSpawned >= 3) 
//            {
//                isSpawning = false;
//            }
//            else
//            {
//                currentIndex = (currentIndex + 1) % lineColors.Length;
//                currentXPosition += 2f;
//            }
//        }
//    }



//    public void StartSpawning()
//    {
//        isSpawning = true;
//        linesSpawned = 0;
//        currentZPosition += 30f;
//        currentXPosition = -2f;
//        StartCoroutine(SpawnStacks());
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackSpawner : MonoBehaviour
{
    public GameObject stackPrefab;
    public int numberOfStacksPerLine = 4;
    public float stackSpacing = 1.5f;
    public Color[] lineColors;

    private int currentIndex = 0;
    private int linesSpawned = 0;
    private bool isSpawning = true;
    private float currentZPosition = 30f;
    private float currentXPosition = -2f;
    private List<GameObject> spawnedCubes = new List<GameObject>(); // List to store spawned cubes

    void Start()
    {
        StartCoroutine(SpawnStacks());
    }

    IEnumerator SpawnStacks()
    {
        while (isSpawning)
        {
            for (int i = 0; i < numberOfStacksPerLine; i++)
            {
                Vector3 spawnPosition = new Vector3(currentXPosition, .4f, currentZPosition + i * stackSpacing);

                GameObject stackInstance = Instantiate(stackPrefab, spawnPosition, Quaternion.identity);
                spawnedCubes.Add(stackInstance); // Add the spawned cube to the list

                Renderer stackRenderer = stackInstance.GetComponent < Renderer>();
            stackRenderer.material.color = lineColors[currentIndex];

            yield return null;
        }

        linesSpawned++;
        if (linesSpawned >= 3)
        {
            isSpawning = false;
        }
        else
        {
            currentIndex = (currentIndex + 1) % lineColors.Length;
            currentXPosition += 2f;
        }
    }
}

// Function to destroy all spawned cubes
public void DestroySpawnedCubes()
{
    foreach (var cube in spawnedCubes)
    {
        Destroy(cube);
    }
    spawnedCubes.Clear(); // Clear the list
}

public void StartSpawning()
{
    isSpawning = true;
    linesSpawned = 0;
    currentZPosition += 30f;
    currentXPosition = -2f;

    // Destroy all spawned cubes when starting a new game
   // DestroySpawnedCubes();

    StartCoroutine(SpawnStacks());
}
}
