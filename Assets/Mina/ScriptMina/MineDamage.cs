using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDamage : MonoBehaviour
{
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();  
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);
        int i = 0;
        while(i < numCollisionEvents)
        {
            Visible();
            i++;
        }
    }

    public GameObject Object;
    private void Visible()
    {
        Object.SetActive(true);
    }
}
