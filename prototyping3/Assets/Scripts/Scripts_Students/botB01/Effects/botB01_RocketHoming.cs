using UnityEngine;

public class botB01_RocketHoming : MonoBehaviour
{
    public Transform Target;
    public MeshRenderer ball;

    [Range(0, 10)] public float Speed;
    [Range(0, 10)]  public float AngularSpeed;
    private Vector3 velocity;
    
    [Range(0, 5)] public float WarmUpTime;
    private float warmUpTimer = 0.0f;

    private Color red;
    private Color white;

    private Collider col;

    private botB01_AttackState state;
    
    // Start is called before the first frame update
    private void Start()
    {
        red = ball.material.color;
        Color.RGBToHSV(red, out float H, out float _, out float V);
        white = Color.HSVToRGB(H, 0.0f, V);

        col = GetComponent<Collider>();
        col.enabled = false;
        
        state = botB01_AttackState.stage_0;
        velocity = Vector3.up + Random.insideUnitSphere * 0.1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Target == null)
            return;

        if (state == botB01_AttackState.stage_0)
        {
            warmUpTimer += Time.deltaTime;
            if (warmUpTimer < WarmUpTime)
            {
                transform.LookAt(transform.position + Vector3.up);
            }
            else
            {
                col.enabled = true;
                state = botB01_AttackState.stage_1;
            }
        }
        else if (state == botB01_AttackState.stage_1)
        {
            Vector3 acceleration = (Target.position - transform.position).normalized * Time.deltaTime;
            velocity = (velocity + acceleration * AngularSpeed).normalized;
            transform.LookAt(transform.position + velocity);
        }

        transform.position += velocity * (Speed * Time.deltaTime);
    }
}
