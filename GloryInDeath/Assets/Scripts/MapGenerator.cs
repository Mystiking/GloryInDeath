﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour {
    // Dimensions
    public int columns;
    public int rows;
    // Board "coordinates"
    private List <Vector3> gridPositions = new List <Vector3>();

    public GameObject[] waterTiles;
    public GameObject[] groundTiles;
    public GameObject[] enemyTiles;
    public GameObject[] boarderTilesRight;
    public GameObject[] beachObjectTiles;

    private Transform boardHolder;

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public Count beachObjectCount = new Count(5,9);
    public Count enemyObjectCount = new Count(5,9);

    void Init() {
        gridPositions.Clear();
        for (int i = 0; i < columns-1; i++)
        {
            for (int j = 0; j < rows-1; j++)
            {
                gridPositions.Add(new Vector3(i, j, 0f));
            }
        }
    }

    void BoardSetup() {
        boardHolder = new GameObject("Board").transform;
        Vector2 center = new Vector2(Mathf.Ceil(columns/2) - 1, Mathf.Ceil(rows/2) - 1);
        for (int x = 0; x < columns-1; x++)
        {
            for (int y = 0; y < rows-1; y++)
            {

                GameObject toInstantiate;
                Vector2 pos = new Vector2(x, y);
                // TODO change (-1) to some percentage
                Debug.Log(Vector2.Distance(center,pos));
                if (Vector2.Distance(center, pos) > (rows/2 - 1)) {
                    toInstantiate = waterTiles[Random.Range(0, waterTiles.Length)];
                }
                //else if(Vector2.Distance(center,pos) < (rows/2 -1) && Vector2.Distance(center,pos) > (rows/2 -1) -1 )
                //{
                //    toInstantiate = boarderTilesRight[Random.Range(0,boarderTilesRight.Length)];
                //} 
                else {
                    toInstantiate = groundTiles[Random.Range(0, groundTiles.Length)];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition() {
        int randIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randIndex];
        gridPositions.RemoveAt(randIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum) {
        int objectCount = Random.Range(minimum, maximum);
        for(int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice,randomPosition,Quaternion.identity);

        }
    }

    public void SetupScene() {
        BoardSetup();
        Init();
        LayoutObjectAtRandom(beachObjectTiles,beachObjectCount.minimum,beachObjectCount.maximum);
        LayoutObjectAtRandom(enemyTiles,enemyCount.minimum,enemyCount.maximum);

    }
}
