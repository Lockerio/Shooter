using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    public Rigidbody[] rb;
    public AudioSource[] audioSources;
    private int randomPoint;
    public HealthBar healthBar;
    public Animator animator;

    private void Start()
    {
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].isKinematic = true;
        }
        randomPoint = Random.Range(0, audioSources.Length - 1);

        healthBar.SetMaxHealth((int)health);
    }

    public void Take_Damage(float amount)
    {
        health -= amount;

        healthBar.SetHealth((int)health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void Die()
    {
        animator.enabled = false;

        audioSources[randomPoint].Play();

        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].isKinematic = false;
        }

        Invoke("DestroyEnemy", 5f);
    }
}
