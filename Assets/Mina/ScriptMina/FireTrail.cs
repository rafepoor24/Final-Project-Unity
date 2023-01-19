using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Vector2 _durationRange = new Vector2(5, 10);
    [SerializeField] private float _destroyDelay = 1f;

    private float _duration = 0f;
    private float _destroyTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _duration = Random.Range(_durationRange.x, _durationRange.y);
        _particleSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(_destroyTimer > _duration)
        {
            _particleSystem.Stop();
            
            if(_destroyTimer - _duration > _destroyDelay)
            {
                Destroy(gameObject);
            }
        }

        _destroyTimer += Time.deltaTime;
    }
}
