using UnityEngine;

public class botB01_Explosion : MonoBehaviour
{
    [Range(1, 15)] public float MaxRadius;
    private float originalRadius;
    [Range(0, 1)]  public float GrowthTime;
    private float timer = 0.0f;

    private Vector3 min;
    private Vector3 max;

    private MeshRenderer mesh;

    private void Start()
    {
        originalRadius = transform.localScale.x;
        
        min = Vector3.one * originalRadius;
        max = Vector3.one * MaxRadius;

        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (timer < GrowthTime)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(min, max, Mathf.Pow(timer / GrowthTime, 2));
            mesh.material.SetColor("_Color", Color.Lerp(Color.red, new Color(1, 0, 0, 0), Mathf.Pow(timer / GrowthTime, 2)));
            mesh.material.SetFloat("_Glossiness", Mathf.Lerp(1, 0, Mathf.Pow(timer / GrowthTime, 2)));
        }
        else
            Destroy(gameObject);
    }
}
