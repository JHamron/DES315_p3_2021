using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botB06_Ethan : MonoBehaviour
{
    //vars pulled from teacher
    public GameObject compassSides;
    public GameObject compassVertical;
    private float sidelimit = 3.0f;
    private float attackDamage;
    public float knockBackSpeed = 10f;

    public float shieldPowerTop = 5f;
    public float shieldPowerBottom = 5f;

    private Rigidbody rb;
    private GameHandler gameHandler;
    private string thisPlayer;
    private bool notMyWeapon = true;

    //Shields
    public GameObject TopShield, BottomShield;
    //particles
    public GameObject TopParticles, BottomParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
