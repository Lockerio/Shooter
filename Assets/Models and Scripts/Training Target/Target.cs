using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Rigidbody rb;
    public Transform tr;

   

    public void Take_Damage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Respawn()
    {
        rb.isKinematic = true;

        tr.localPosition = new Vector3(0f, 0f, 0f);
        tr.localRotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    void Die()
    {
        rb.isKinematic = false;

        Invoke("Respawn", 2.5f);
    }
}
