using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Bullet special;

    public float cooldown = 1.5f;
    public float special_cooldown = 50f;
    public float timer;
    public float special_timer;

    [SerializeField] private Transform shootPoint;

    PlayerInput playerInput;
    InputAction fireAction;
    InputAction frostBlastAction;

    bool isFiring = false;
    bool isSpecialAttacking = false;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        fireAction = playerInput.actions["fire"];
        frostBlastAction = playerInput.actions["frostblast"];
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        FrostBlast();
    }

    void Fire()
    {
        var fireInput = fireAction.ReadValue<float>();

        if (!isFiring && fireInput > 0) 
        { 
            isFiring = true;
            timer = 0;
            //shoot
            SoundManager.Instance.PlaySound(SoundManager.Instance.attack);
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        }

        if (isFiring)
        {
            timer += Time.deltaTime;

            if (timer > cooldown)
            {
                isFiring = false;
            }
        }
    }

    void FrostBlast()
    {
        var frostBlastInput = frostBlastAction.ReadValue<float>();

        if (!isSpecialAttacking && frostBlastInput > 0)
        {
            isSpecialAttacking = true;
            special_timer = 0;
            //shoot
            SoundManager.Instance.PlaySound(SoundManager.Instance.special);
            Instantiate(special, shootPoint.position, shootPoint.rotation);
        }

        if (isSpecialAttacking)
        {
            special_timer += Time.deltaTime;

            if (special_timer > special_cooldown)
            {
                isSpecialAttacking = false;
            }
        }
    }
}
