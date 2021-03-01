using UnityEngine;

public class botB01_PushBack : MonoBehaviour, botB01_IAttack
{
    [Range(0, 5)] public float Cooldown;
    [Range(0, 5)] public float AttackTime;
    private float cooldownTimer = 0.0f;
    private float attackTimer   = 0.0f;

    [Range(0, 10)] public float GrowthExponent;
    [Range(1, 20)] public float MaxRadiusScale;
    private Vector3 startDimensions;
    private Vector3 maxDimensions;

    private MeshRenderer mesh;
    private Color activeColor;

    private Collider col;
    
    private botB01_Weapons scrWeapons;
    private int index = 0;
    private botB01_AttackState currentState;

    // Start is called before the first frame update
    void Start()
    {
        scrWeapons = transform.parent.parent.GetComponent<botB01_Weapons>();
        
        startDimensions = transform.localScale;
        maxDimensions = startDimensions * MaxRadiusScale;
        maxDimensions.y = startDimensions.y;
        
        mesh = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        
        Ready();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == botB01_AttackState.stage_0)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer < AttackTime)
            {
                transform.localScale = Vector3.Lerp(startDimensions, maxDimensions, Mathf.Pow(attackTimer / AttackTime, GrowthExponent));
            }
            else
            {
                currentState = botB01_AttackState.cooldown;
                col.enabled = false;
            }
        }
        else if (currentState == botB01_AttackState.cooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer < Cooldown)
            {
                transform.localScale = Vector3.Lerp(maxDimensions, startDimensions, cooldownTimer / Cooldown);
            }
            else
                Ready();
        }
    }

    public void Attack()
    {
        scrWeapons.SetButtonStatus(index, true);
        
        currentState = botB01_AttackState.stage_0;
        transform.localScale = startDimensions;
        
        cooldownTimer = 0.0f;
        attackTimer   = 0.0f;
        
        mesh.enabled = true;
        col.enabled = true;
    }

    public void Ready()
    {
        scrWeapons.SetButtonStatus(index, false);
        currentState = botB01_AttackState.inactive;
        mesh.enabled = false;
    }
}
