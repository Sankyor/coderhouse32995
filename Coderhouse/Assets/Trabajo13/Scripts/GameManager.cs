using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int trySwitchs;
    private PlayerController13 m_playerController;
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void sumIntent()
    {
        trySwitchs++;
    }
    public PlayerController13 GetPlayerController()
    {
        return m_playerController;
    }
    public void SetPlayerController(PlayerController13 p_playerController)
    {
        m_playerController = p_playerController;
    }
}

