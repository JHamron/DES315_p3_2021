using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B05_BladeRush : MonoBehaviour
{
    private bool b_attacking = false;
    private float timer = 0.0f;
    public float t_startup = 0.0f;
    public float t_length = 0.0f;
    public float t_cooldown = 0.0f;
    public int damage = 0;

    public MeshRenderer vent;
    public Material mat_able;
    public Material mat_used;

    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        b_attacking = false;
        timer = 0.0f;
        vent.material = mat_able;
    }

    // Update is called once per frame
    void Update()
    {
        if (!b_attacking)
            return;

        timer += Time.deltaTime;
        if (timer > (t_startup + t_length + t_cooldown))
        {
            EndAttack();
        }
    }

    public void Attack()
    {
        // begin attack if avaliable
        if (!b_attacking)
        {
            BeginAttack();
        }
    }

    private void BeginAttack()
    {
        b_attacking = true;
        vent.material = mat_used;
        timer = 0.0f;
        ani.Play("BladeExtend");
    }

    private void EndAttack()
    {
        b_attacking = false;
        vent.material = mat_able;
        timer = 0.0f;
        ani.Play("BladeDetract");
    }
}
