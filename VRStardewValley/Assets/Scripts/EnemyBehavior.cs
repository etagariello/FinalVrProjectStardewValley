using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyBehavior : MonoBehaviour
{
    public TextMeshProUGUI PlayerHealthText;
    protected int PlayerHealth;
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PlayerController").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }

        

    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerController")
        {
            agent.destination = player.position;
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "PlayerController")
        {
            string[] splitHealthText = PlayerHealthText.text.Split();
            int PlayerHealth = int.Parse(splitHealthText[1]);

            PlayerHealth--;
            PlayerHealthText.text = "Health: " + PlayerHealth;

            if (PlayerHealth <= 0)
            {
                Application.Quit();
            }
        }
            
    }
}
