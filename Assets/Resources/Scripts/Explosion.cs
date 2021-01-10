using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float power = 10f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float upForce = 1f;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        Explode();
    }

    // Update is called once per frame
    public void Explode()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (var hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power,explosionPosition,radius,upForce,ForceMode.Impulse);
            }
        }
    }
}
