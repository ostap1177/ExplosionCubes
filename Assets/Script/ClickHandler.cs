using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Cube _cube;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (GetHitCube(out Cube cubeHit)) 
            {
                _cube = cubeHit;
                _cube.ClickOnCube();
            }
        }
    }

    private bool GetHitCube(out Cube cubeHit)
    {
        cubeHit = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);

        foreach (var raycastHit in raycastHits)
        {
            if (raycastHit.transform.TryGetComponent<Cube>(out Cube cube))
            {
                cubeHit = cube;
            }
        }

        return cubeHit != null;
    }
}
