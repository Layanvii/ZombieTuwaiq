using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{
   
    public NavMeshAgent EnemyAgent;
    public Transform PlayerPoss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAgent.SetDestination(PlayerPoss.position);
    }
}
