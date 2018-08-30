using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class LivingEntity : MonoBehaviour {


    protected float m_EntityHealth;
    protected float m_EntityMovementSpeed;

    protected Transform m_EntityTransform;
    protected Vector3 m_StartPosition;

    protected bool m_IsDead;
    protected bool m_IsAlive;
    // Use this for initialization

    private void Start()
    {
        m_EntityTransform = transform;
        m_StartPosition = m_EntityTransform.position;
    }

    private void Update()
    {
        if(m_EntityHealth <= 0.0f)
        {
            Kill();
        }
    }

    protected abstract void Attack();

    private void OnCollisionEnter(Collision collision)
    {
        GameObject InteractingObject = collision.gameObject;

        if(InteractingObject.GetComponent<Attack>() != null)
        {
            float damageToDeal = InteractingObject.GetComponent<Attack>().GetDamage();
            TakeDamage(damageToDeal);
        }
    }

    protected abstract void Kill();

    protected void TakeDamage(float damage)
    {
        m_EntityHealth -= damage;
    }
}
