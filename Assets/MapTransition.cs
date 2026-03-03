/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapTransition : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundary;
    CinemachineConfiner2D confiner;

    private void Awake()
    {
        confiner = FindObjectOfType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            confiner.m_BoundingShape2D = mapBoundary;
        }
    }
}
*/