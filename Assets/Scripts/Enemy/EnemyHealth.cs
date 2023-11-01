using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public Animator animator;
    public Slider lifeSlider;
    public MonoBehaviour enemyMovementScript;//There are different types of Enemy Movement scripts
    public GameObject dnaCoin;
    public GameObject deadEnemy;

    public void Start()
    {
        lifeSlider.maxValue = health;
        lifeSlider.value = lifeSlider.maxValue;
    }

    public void DecraseHealth(float damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            lifeSlider.value = 0;
            GameObject fireBullet = Instantiate(dnaCoin, gameObject.transform.position, Quaternion.identity);
            GameObject dead = Instantiate(deadEnemy, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            return;
        }
        animator.SetTrigger("Hurt");
        lifeSlider.value = lifeSlider.value - damage;
        health -= damage;
        return;
    }
}
