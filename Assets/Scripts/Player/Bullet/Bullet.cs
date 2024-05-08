using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public BulletSO newbullet;

    SphereCollider sphereCollider;
    Rigidbody rb;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = newbullet.radius;

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        Destroy(this.gameObject, newbullet.lifetime);
        soundManager = SoundManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (newbullet.speed > 0)
        {
            transform.Translate(Vector3.forward * newbullet.speed * Time.deltaTime);
            soundManager.PlaySound(soundManager.bullet_sound);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //effect when hit
        if (other.gameObject.CompareTag("Enemy")) { 
            RabbitHealth rabbitHealth = other.GetComponent<RabbitHealth>();
            rabbitHealth.TakeDamage(newbullet.damage);
        }
        //Destroy(this.gameObject);
    }
    
}
