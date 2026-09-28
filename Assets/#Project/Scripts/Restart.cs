using System;
using UnityEngine;
using UnityEngine.AI;

public class Restart : MonoBehaviour
{

    private const string PLAYER_TAG = "Player";
    private GameObject player;
    [SerializeField] private float levelLimitY = -5f;
    private Vector3 playerStartPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        if (player == null)
        {
            Debug.LogError("Player not found.");
        };
        playerStartPosition = player.transform.position;
    }

    void Update()
    {
        if (player.transform.position.y <= levelLimitY)
            RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        player.transform.position = playerStartPosition;
    }
}
