using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Explotion bullets
    private bool explosionBullet = false;
    private float explosionForce;
    private float explosionRadius;
    //Gravity bullets
    private bool gravityBullet = false;
    private float influenceRangeGravity;
    private float intensity;
    private float distanceToObject;
    [SerializeField] private float lifeTime;
    Vector3 pullForce;


    // Update is called once per frame
    void Update()
    {
        
        if (gravityBullet)
        {
            GameObject[] atracttableObjects = GameObject.FindGameObjectsWithTag("attractiveObjects");
            foreach (var obje in atracttableObjects)
            {
                if (obje!=this.gameObject)
                {
                    distanceToObject = Vector3.Distance(obje.transform.position, transform.position);
                    if (distanceToObject <= influenceRangeGravity)
                    {
                        pullForce = (transform.position - obje.transform.position).normalized / distanceToObject * intensity;
                        obje.GetComponent<Rigidbody>().AddForce(pullForce, ForceMode.Force);
                    }
                }
            }
        }
        Destroy(this.gameObject,lifeTime);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnviromentElements")|| collision.gameObject.CompareTag("attractiveObjects"))
        {
            GameObject[] atracttableObjects = GameObject.FindGameObjectsWithTag("attractiveObjects");
            foreach (var obje in atracttableObjects)
            {
                distanceToObject = Vector3.Distance(obje.transform.position, transform.position);
                if (distanceToObject <= explosionRadius)
                {
                    obje.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    Destroy(this.gameObject);
                }
            }
        }
    }
    public void CreateExplosionBullet(float force, float radius)
    {
        explosionBullet = true;
        explosionForce = force;
        explosionRadius = radius;
    }
    public void CreateGravityBullet(float intencityForce, float Range)
    {
        intensity = intencityForce;
        influenceRangeGravity = Range;
        gravityBullet = true;
    }
}
