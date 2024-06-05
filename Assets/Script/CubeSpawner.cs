using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Cube))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Material[] _materials;

    [SerializeField] private int _minCountCubes;
    [SerializeField] private int _maxCountCubes;
    [SerializeField] private int _splitterCube = 2;

    private Transform _transform;
    private Cube _cube;
    private int _maxValuetToSplit = 10;

    private void OnEnable()
    {
        _prefabCube.CleckedCube += OnClickedCube;
    }

    private void OnDisable()
    {
        _prefabCube.CleckedCube -= OnClickedCube;
    }

    private void Awake()
    {
        _transform = transform;
        _cube = GetComponent<Cube>();
    }

    private void OnClickedCube(Transform transform)
    { 
        CreateCubes(transform.localScale);
    }

    private void CreateCubes(Vector3 scale)
    {
        System.Random random = new System.Random();

        if (IsCreatedCubes(random) == true)
        {
            int countCubes = random.Next(_minCountCubes, _maxCountCubes);

            for (int i = 0; i < countCubes; i++)
            {
                Cube cube = Instantiate(_prefabCube, _transform.position, Quaternion.identity);
                cube.transform.localScale = scale / _splitterCube;
                cube.gameObject.GetComponent<Renderer>().material = ChangeColor(random);
            }

            _explosion.ExplosionCube(_transform.position);
            _cube.DestroyCube();
        }
    }

    private Material ChangeColor(System.Random random)
    { 
        int index = random.Next(0, _materials.Length);

        return _materials[index];
    }

    private bool IsCreatedCubes(System.Random random)
    {
        int value = random.Next(20);

        return value < _maxValuetToSplit;
    }
}
