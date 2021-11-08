using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;

public class Game : MonoBehaviour
{
    public PlayerScript player;

    public int floor = 1;

    public bool playing;
    public static Game Instance { get; set; }

    private void FindPaths()
    {
        AstarPath.active.Scan();//GET THIS WORKING
    }

    private void Awake()
    {
        Instance = this;
        StartDungeon();
    }

    void Update() {
        if (player.currentHealth < 1)
        {
            ResetDungeon();
        }
    }

    public void StartDungeon() {
        playing = true;
        GenerateDungeon.Instance.GenerateNewDungeon();
        Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        Vector3 spawnPos3 = spawnPos;
        player.transform.position = spawnPos3;
        Invoke("FindPaths", .1f);
    }

    public void NextFloor() {
        GenerateDungeon.Instance.DeleteDungeon();
        GenerateDungeon.Instance.GenerateNewDungeon();
        Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        Vector3 spawnPos3 = spawnPos;
        player.transform.position = spawnPos3;
        floor++;
        Invoke("FindPaths", .1f);
    }

        public void ResetDungeon() {
        GenerateDungeon.Instance.DeleteDungeon();
        GenerateDungeon.Instance.GenerateNewDungeon();
        Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        Vector3 spawnPos3 = spawnPos;
        player.transform.position = spawnPos3;
        floor = 1;
        player.currentHealth = player.maxHealth;
        Invoke("FindPaths", .1f);
    }
}