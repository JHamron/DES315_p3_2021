using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{

    [SerializeField] private GameObject MinePrefab;
    
    public string button1;

    
    // Start is called before the first frame update
    void Start()
    {
        button1 = gameObject.transform.parent.GetComponent<playerParent>().action1Input;

    }

    // Update is called once per frame
    void Update()
    {
        // Drop a mine
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(MinePrefab);
        }
     
        if ((Input.GetButtonDown(button1)))
        {
            Instantiate(MinePrefab, transform.position, Quaternion.identity);
        }
    }
}
