using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion = 2;
    [SerializeField] private float _forceExplsion = 5;

    public void ExplosionCube(Vector3 explosionPosition)
    {
        foreach (Rigidbody explodableCube in GetExplosionCubes(explosionPosition))
        {
            explodableCube.AddExplosionForce(_forceExplsion, explosionPosition, _radiusExplosion);
        }
    }

    private List<Rigidbody> GetExplosionCubes(Vector3 explosionPosition)
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(explosionPosition, _radiusExplosion);
      
        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider collider in overlappedColliders)
        {
            if (collider.attachedRigidbody != null)
            {
                cubes.Add(collider.attachedRigidbody);
            }
        }

        return cubes;
    }
}