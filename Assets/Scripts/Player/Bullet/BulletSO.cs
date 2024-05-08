using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet")]
public class BulletSO : ScriptableObject
{
    public float lifetime = 0.5f;
    public float speed = 70f;
    public float damage = 5f;
    public float radius = 1f;

}
