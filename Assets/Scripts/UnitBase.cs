using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitBase : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] private Renderer _renderer;

    public Bounds WorldBounds => _renderer.bounds;
    public bool IsVisible => _renderer.isVisible;
}