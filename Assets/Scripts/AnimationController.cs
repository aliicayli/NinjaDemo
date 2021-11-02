using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            Debug.Log("It works");
            enemy.GetComponent<Animator>().Play("EnemyAttack");
        }
    }
}
