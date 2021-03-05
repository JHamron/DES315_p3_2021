using UnityEngine;

public class botB01_RocketLauncher : MonoBehaviour, botB01_IAttack
{
    [Range(0, 5)] public float Cooldown;
    private float cooldownTimer = 0.0f;

    private botB01_Weapons scrWeapons;
    private int index = 3;
    private botB01_AttackState currentState;

    public GameObject RocketPrefab;
    public GameObject ExplosionPrefab;
    private GameObject enemy;


    void Start()
    {
        scrWeapons = transform.parent.parent.GetComponent<botB01_Weapons>();
        enemy = GetEnemyBot();
    }

    void Update()
    {
        if (currentState == botB01_AttackState.cooldown) // Decay stage
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= Cooldown)
                Ready();
        }
    }

    public void Attack()
    {
        scrWeapons.SetButtonStatus(index, true);
        
        currentState = botB01_AttackState.cooldown;
        cooldownTimer = 0;
     
        GameObject rocket = Instantiate(RocketPrefab);
        rocket.transform.position = transform.position;
        var scr = rocket.GetComponent<botB01_RocketHoming>();
        scr.Target = enemy.transform;
        scr.scrLauncher = this;
    }

    public void Ready()
    {
        scrWeapons.SetButtonStatus(index, false);
        currentState = botB01_AttackState.inactive;
    }

    public void Cancel()
    {
        // No-op
    }

    private GameObject GetEnemyBot()
    {
        GameHandler gh = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        string playerTag = transform.root.tag;
        if (playerTag.Contains("1"))
            return gh.Player2Holder.transform.GetChild(0).gameObject;
        if (playerTag.Contains("2"))
            return gh.Player1Holder.transform.GetChild(0).gameObject;
        Debug.Log("Player is not tagged, rocket targeting shooter");
        return transform.parent.parent.gameObject;
    }

    public void SpawnExplosion(Vector3 pos)
    {
        GameObject obj = Instantiate(ExplosionPrefab);
        obj.transform.position = pos;
        
        var hazard = obj.GetComponent<HazardDamage>();
        if (transform.root.CompareTag("Player1"))
            hazard.isPlayer1Weapon = true;
        if (transform.root.CompareTag("Player2"))
            hazard.isPlayer2Weapon = true;
    }
}
