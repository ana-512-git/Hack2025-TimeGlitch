using UnityEngine;
using System.Collections.Generic;

public class CableRandom : MonoBehaviour
{
    public Transform[] leftCables, rightCables; 

    private void Start()
    {
        ShuffleCables(leftCables);
        ShuffleCables(rightCables);
    }

    void ShuffleCables(Transform[] cables)
    {
        List<Vector3> originalPositions = new List<Vector3>();
        foreach (Transform cable in cables)
            originalPositions.Add(cable.position);

        for (int i = 0; i < originalPositions.Count; i++)
        {
            Vector3 temp = originalPositions[i];
            int randomIndex = Random.Range(i, originalPositions.Count);
            originalPositions[i] = originalPositions[randomIndex];
            originalPositions[randomIndex] = temp;
        }

        for (int i = 0; i < cables.Length; i++)
            cables[i].position = originalPositions[i];
    }
}
