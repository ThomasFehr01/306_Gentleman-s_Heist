using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public PlayerScript player;

    public bool playing;
    public static Game Instance { get; set; }

    private void FindPaths()
    {
        AstarPath.active.Scan();
    }

    private void Awake()
    {
        Instance = this;
        StartDungeon();
    }

    void Update() {
        if (PlayerData.GetCurrentHealth() < 1)
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
<<<<<<< Updated upstream
        if (!SaveMaster.needsLoad)
        {
            SaveMaster.needsSave = true;
        }


=======
        PlayerScript.detected = false;
>>>>>>> Stashed changes
    }

    public void NextFloor() {
        GenerateDungeon.Instance.DeleteDungeon();
        GenerateDungeon.Instance.GenerateNewDungeon();
        Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        Vector3 spawnPos3 = spawnPos;
        player.transform.position = spawnPos3;
        PlayerData.NextLevel();
        Invoke("FindPaths", .1f);
        PlayerScript.detected = false;
    }

        public void ResetDungeon() {
        // GenerateDungeon.Instance.DeleteDungeon();
        // GenerateDungeon.Instance.GenerateNewDungeon();
        // Vector2 spawnPos = GenerateDungeon.Instance.GetSpawnPos();
        // Vector3 spawnPos3 = spawnPos;
        // player.transform.position = spawnPos3;
        PlayerData.SetLevel(1);
        PlayerData.FullHeal();
        PlayerScript.detected = false;
        Invoke("FindPaths", .1f);
        SceneManager.LoadScene("PrisonMenu");
    }
}