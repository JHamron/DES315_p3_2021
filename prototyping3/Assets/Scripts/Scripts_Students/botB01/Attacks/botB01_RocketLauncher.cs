﻿using UnityEngine;

public class botB01_RocketLauncher : MonoBehaviour, botB01_IAttack
{
    [Range(0, 5)] public float Cooldown;
    private float cooldownTimer = 0.0f;

    private botB01_Weapons scrWeapons;
    private int index = 3;
    private botB01_AttackState currentState;

    public GameObject RocketPrefab;
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        scrWeapons = transform.parent.parent.GetComponent<botB01_Weapons>();
        enemy = GetEnemyBot();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == botB01_AttackState.cooldown) // Decay stage
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer < Cooldown)
            {
                
            }
            else
            {
                Ready();
            }
        }
    }

    public void Attack()
    {
        scrWeapons.SetButtonStatus(index, true);
        currentState = botB01_AttackState.cooldown;

        cooldownTimer = 0;
     
        GameObject rocket = Instantiate(RocketPrefab);
        rocket.transform.position = transform.position;
        botB01_RocketHoming scr = rocket.GetComponent<botB01_RocketHoming>();
        scr.Target = GetEnemyBot().transform;
    }

    public void Ready()
    {
        scrWeapons.SetButtonStatus(index, false);
        currentState = botB01_AttackState.inactive;
    }

    public void Cancel()
    {
        
    }

    private GameObject GetEnemyBot()
    {
        return gameObject;

        string playerTag = transform.root.tag;
        if (playerTag.Contains("1"))
            return GameHandler.player2Prefab;
        if (playerTag.Contains("2"))
            return GameHandler.player1Prefab;
        Debug.Log("Player is not tagged, rocket targeting shooter");
        return transform.parent.parent.gameObject;
    }
}