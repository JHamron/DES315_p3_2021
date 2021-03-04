using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehavior : MonoBehaviour
{

    [SerializeField] private float SpawnTime;
    private float spawnTimer = 0f;

    [SerializeField] private float LifeTime;
    private float lifeTimer = 0f;

    [SerializeField] private float BlinkIntervalTime = 1f;
    [SerializeField] private float BlinkDecay = 0.1f;
    private float blinkTimer = 0f;
    [SerializeField] private float BlinkHoldTime = 0.1f;
    private float blinkHoldTimer = 0f;
    
    
    // If bomb is active
    private bool isActive = false;


    [SerializeField] private Material InactiveColor;
    [SerializeField] private Material ActiveColor;
    [SerializeField] private Material BlinkColor;

    [SerializeField] private MeshRenderer Rend;
    
    // Start is called before the first frame update
    void Start()
    {
        Rend.material = InactiveColor;
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn timer is the time before mine is active
        if (spawnTimer >= SpawnTime)
        {
            isActive = true;
            gameObject.tag = "Hazard";
            Rend.material = ActiveColor;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }

        // Life timer after it's been active
        if (lifeTimer >= LifeTime)
        {
            Explode();
        }
        else if (isActive)
        {
            lifeTimer += Time.deltaTime;
        }


        if (isActive)
        {
            // Not currently doing a blink
            if (blinkHoldTimer <= 0f)
            {
                // Regular blink timer
                blinkTimer += Time.deltaTime;
                if (blinkTimer >= BlinkIntervalTime)
                {
                    // Shorten time for next blink
                    BlinkIntervalTime -= BlinkDecay;
                    // Start active blinking
                    blinkHoldTimer += Time.deltaTime;
                    Rend.material = BlinkColor;
                }
            }
            else
            {
                blinkHoldTimer += Time.deltaTime;
                if (blinkHoldTimer >= BlinkHoldTime)
                {
                    blinkHoldTimer = 0f;
                    blinkTimer = 0f;
                    Rend.material = ActiveColor;
                }
            }

        }
        
    }
    
    // Collision code to check if isActive
    private void OnTriggerEnter(Collider other)
    {
        if (isActive && gameObject.transform.root.tag.Contains("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // TODO Particle burst
        
        Destroy(this);
    }
}

