using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public delegate void ExplosionDelegate();
    public event ExplosionDelegate OnExplosionTriggerEvent;

    public float _ExplosionRadius;
    public float _ExplosionFalloffThresholdRadius;

    public float _MaxExplosionForce;
    public float _MinimumExplosionForce;

    [SerializeField] private ParticleSystem _explosionParticleSysem;
    [SerializeField] private FireTrail _explosionFireTrail;

    [SerializeField] private float _destroyDelay;
    [SerializeField] private float _catchFireChance;
    [SerializeField] private bool _bTriggerOnStart;
    [SerializeField] private bool _bDestroyOnTrigger;
    [SerializeField] private bool _bTriggerOnce;
    
    private bool _bWasTriggered;

    private float _destroyTimer;
    
    private List<Vector3>_RecentHits = new List<Vector3>();

    //private float _falloffThresholdPointValue;

    private void Start()
    {
        //if(_bTriggerOnStart)
            //Trigger();
    }


    private void Update()
    {
        if(_bDestroyOnTrigger && _destroyTimer >= _destroyDelay)
            Destroy(gameObject);

        if(_bWasTriggered && _bDestroyOnTrigger)
            _destroyTimer += Time.deltaTime;

        //if(Input.GetKeyDown(KeyCode.B))
            //Trigger();
    }

  void OnTriggerEnter(Collider other)
  {
    print(other.gameObject.tag);
    if(other.gameObject.tag == "Player") Trigger();
  }
    public void Trigger()
    {
        if(_bWasTriggered && _bTriggerOnce)
            return;

        OnExplosionTriggerEvent?.Invoke();

        _explosionParticleSysem.Play();


        _RecentHits.Clear();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _ExplosionRadius);

        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                _RecentHits.Add(rigidbody.transform.position);

                float distance = Vector3.Distance(rigidbody.transform.position, transform.position);
                float falloffThresholdPointValue = _ExplosionFalloffThresholdRadius / _ExplosionRadius;

                float distancePoint = Mathf.Clamp(distance / _ExplosionRadius, 0, 1);
                float calculatedForce = 0f;

                if(distancePoint <= falloffThresholdPointValue)
                {
                    calculatedForce = _MaxExplosionForce;

                    if(RollFireChance())
                    {
                        Instantiate(_explosionFireTrail, rigidbody.transform);
                    }
                }
                else
                {
                    float pointBetweenThresholdToMaxDistance = (distance - _ExplosionFalloffThresholdRadius) / (_ExplosionRadius - _ExplosionFalloffThresholdRadius);
                    calculatedForce = Mathf.Lerp(_MaxExplosionForce, _MinimumExplosionForce, pointBetweenThresholdToMaxDistance);
                }

                rigidbody.AddForce(((rigidbody.transform.position - transform.position).normalized + (Random.onUnitSphere*0.001f))*calculatedForce, ForceMode.Impulse);
                rigidbody.AddTorque(Vector3.RotateTowards((rigidbody.transform.position - transform.position)*calculatedForce, transform.position, 6, 1), ForceMode.Impulse);
            }
        }

        _bWasTriggered = true;
    }

    private bool RollFireChance()
    {
            return Random.Range(0f, 1.1f) < _catchFireChance;
    }

    private void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _ExplosionRadius);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _ExplosionFalloffThresholdRadius);

            Gizmos.color = Color.red;
            if(_RecentHits != null)
            {
                for(int i = 0; i < _RecentHits.Count; i++)
                {
                    Gizmos.DrawSphere(_RecentHits[i], 0.1f);
                }
            }
        }
    }
