using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    bool isSlice = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            weapon.GetComponent<Animator>().Play("WeaponAnimation");
            isSlice = true;
        }

        if (isSlice==true)
        {
            StartCoroutine(SetTime());
        }
    }

    
    

    IEnumerator SetTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
    }

    
}
