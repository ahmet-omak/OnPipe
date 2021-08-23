﻿using UnityEngine;

public class CornController : MonoBehaviour
{
    [SerializeField] CornExplosionData explosionData;
    [SerializeField] GameObject cornPrefab;

    private Renderer cornRenderer;
    private GameObject corn;

    private void Awake()
    {
        cornRenderer = GetComponent<Renderer>();
    }

    public void DoExplodeEffect()
    {
        //Explodes corn
        cornRenderer.enabled = false;
        SpawnCorn();
        foreach (Transform soloCorn in corn.transform)
        {
            var soloCornBody = soloCorn.GetComponent<Rigidbody>();
            if (soloCornBody != null)
            {
                soloCornBody.AddExplosionForce(explosionData.Power,
                    transform.position,
                    explosionData.Radius,
                    explosionData.UpwardsModifier);
            }
        }
        Destroy(corn, explosionData.DestroyDelay);
    }

    private void SpawnCorn()
    {
        //Spawns hand-made corn
        corn = Instantiate(cornPrefab);
        corn.transform.position = transform.position;
    }
}
