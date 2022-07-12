using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap_StateMachine : MonoBehaviour
{
    [Header("TileMaps")]
    [SerializeField] private GameObject tileMap20NMi;
    [SerializeField] private GameObject tileMap50NMi;
    [SerializeField] private GameObject tileMap100NMi;
    [SerializeField] private GameObject tileMap200NMi;

    public enum TileMapState
    {
        TileMap20NMi,
        TileMap50NMi,
        TileMap100NMi,
        TileMap200NMi
    }

    [SerializeField] private TileMapState currentTileMapState;

    // Start is called before the first frame update
    void Start()
    {
        ChangingTileMapState(TileMapState.TileMap50NMi);
    }

    IEnumerator TileMap20NMi()
    {
        tileMap20NMi.SetActive(true);

        while (currentTileMapState == TileMapState.TileMap20NMi)
        {
            yield return null;
        }

        tileMap20NMi.SetActive(false);
    }

    IEnumerator TileMap50NMi()
    {
        tileMap50NMi.SetActive(true);

        while (currentTileMapState == TileMapState.TileMap50NMi)
        {
            yield return null;
        }

        tileMap50NMi.SetActive(false);
    }

    IEnumerator TileMap100NMi()
    {
        tileMap100NMi.SetActive(true);

        while (currentTileMapState == TileMapState.TileMap100NMi)
        {
            yield return null;
        }

        tileMap100NMi.SetActive(false);
    }

    IEnumerator TileMap200NMi()
    {
        tileMap200NMi.SetActive(true);

        while (currentTileMapState == TileMapState.TileMap200NMi)
        {
            yield return null;
        }

        tileMap200NMi.SetActive(false);
    }

    public void ChangingTileMapState(TileMapState newState)
    {
        currentTileMapState = newState;
        StartCoroutine($"{newState}");
    }
}
