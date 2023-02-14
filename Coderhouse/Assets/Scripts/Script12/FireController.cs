using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType
{
    Heal,
    Damage
}
public class FireController : MonoBehaviour
{
    [SerializeField] private TriggerType triggerType;
    [SerializeField] private PlayerController player;
    [SerializeField] private SlimeController slime;
    [SerializeField] private float coefficient;
    [SerializeField] private List<WallController> walls;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            switch (triggerType)
            {
                case TriggerType.Heal:
                    Heal(other);
                    break;
                case TriggerType.Damage:
                    Damage(other);
                    break;
            }
        }
    }
    private void Damage(Collider other)
    {
        var playerController = other.GetComponent(typeof(PlayerController));
        var slimeController = other.GetComponent(typeof(SlimeController));
        if (playerController)
        {
            foreach (WallController go in walls)
            {
                go.wallState = WallState.Up;
            }
            Debug.Log("Player taking damage");
            player.TakeDamage(coefficient);
        }
        if (slimeController)
        {
            slime.TakeDamage(coefficient);
        }
    }
    private void Heal(Collider other)
    {
        var playerController = other.GetComponent(typeof(PlayerController));
        var slimeController = other.GetComponent(typeof(SlimeController));
        if (playerController)
        {
            Debug.Log("Player taking healing");
            player.HealLife(coefficient);
            foreach (WallController go in walls)
            {
                go.wallState = WallState.Down;
            }
        }
        if (slimeController)
        {
            slime.HealLife(coefficient);
        }
    }

}   


