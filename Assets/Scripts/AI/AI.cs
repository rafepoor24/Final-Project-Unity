using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//<summary>
//this class controlled AI
// </summary>
public class AI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform[] _destinations;

    // initialized the start point
    private int i = 0;
    [Header("Values")]
    [SerializeField] private bool followPlayer;
    //[SerializeField]private float _distanceFollowPlayer=10;
    [SerializeField]private float _distanceFollowPathr=1.5f;

    private GameObject _player;
    private float _distancePlayer;
  
    void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
        //_navMeshAgent.destination = _destinations[0].transform.position;
    }

   
    void Update()
    {
        FollowPlayer();
        /*_distancePlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (_distancePlayer <= _distanceFollowPlayer && followPlayer)
        {
            
        }
        else
        {
            EnemyPath();
        }*/
    }
    public void EnemyPath()
    {
        _navMeshAgent.destination = _destinations[i].position;

        if (Vector3.Distance(transform.position, _destinations[i].position)<=_distanceFollowPathr){
            if (_destinations[i] != _destinations[_destinations.Length-1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }
    public void FollowPlayer()
    {
        _navMeshAgent.destination = _player.transform.position;
    }
}
