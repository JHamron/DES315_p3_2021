using UnityEngine;
using Random = UnityEngine.Random;

public class botB01_RocketHoming : MonoBehaviour
{
    public Transform Target;
    public MeshRenderer ball;

    [Range(0, 10)] public float Speed;
    [Range(0, 10)]  public float AngularSpeed;
    private Vector3 velocity;

    [Range(0, 500)] public float Knockback = 200;
    
    [Range(0, 5)] public float WarmUpTime;
    private float warmUpTimer = 0.0f;

    private Color red;
    private Color white;

    private Collider col;

    public botB01_RocketLauncher scrLauncher;

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

    // private void OnCollisionEnter(Collision other)
    // {
    //     var obj = other.transform.root;
    //
    //     if (obj.tag.Contains("Player"))
    //     {
    //         Vector3 dir = (obj.transform.position - transform.position).normalized;
    //         dir.y = 0.5f;
    //         Rigidbody rb = other.transform.root.GetComponentInChildren<Rigidbody>();
    //         rb.AddForce(dir * Knockback, ForceMode.Impulse);
    //     }
    //
    //     //transform.GetComponent<Collider>().enabled = false;
    //     foreach (MeshRenderer mesh in transform.GetComponentsInChildren<MeshRenderer>())
    //         mesh.enabled = false;
    //     Destroy(gameObject, 1.00f); 
    // }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        scrLauncher.SpawnExplosion(transform.position);
    }
}
