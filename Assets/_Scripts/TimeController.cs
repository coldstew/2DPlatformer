using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isReversing = false;

    [SerializeField] private GameObject player;
    [SerializeField] private ArrayList playerPositions;
    [SerializeField] private ArrayList playerRotations;

    void Start()
    {
        playerPositions = new ArrayList();
        playerRotations = new ArrayList();
    }

    void Update()
    {
        SetIsReversing();
    }

    private void SetIsReversing()
    {
        if (Input.GetKey(KeyCode.R))
        {
            isReversing = true;
        }
        else
        {
            isReversing = false;
        }
    }

    void FixedUpdate()
    {
        if (!isReversing && player)
        {
            playerPositions.Add(player.transform.position);
        }
        else
        {
            player.transform.position = (Vector3) playerPositions[playerPositions.Count - 1];
            playerPositions.RemoveAt(playerPositions.Count - 1);

            player.transform.localEulerAngles = (Vector3) playerRotations[playerRotations.Count - 1];
            playerRotations.RemoveAt(playerRotations.Count - 1);
        }
    }
}
