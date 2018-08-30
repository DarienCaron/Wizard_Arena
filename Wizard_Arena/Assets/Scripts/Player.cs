using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : LivingEntity {

    [SerializeField] private float m_PlayerHealth;
    [SerializeField] private float m_PlayerMovementSpeed;

    

    // Use this for initialization
    void Start () {

        m_EntityHealth = m_PlayerHealth;
        m_EntityMovementSpeed = m_PlayerMovementSpeed;

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Attack()
    {

    }

    protected override void Kill()
    {
        m_IsDead = true;
            
    }
}
