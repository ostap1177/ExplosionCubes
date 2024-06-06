using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class ChanceCounter : MonoBehaviour
{
    [SerializeField] private int _maxValueToChance = 10;
    [SerializeField] private int _maxChanceValue = 20;
    [SerializeField] private Cube _cube;

    public bool IsCreatedChance()
    {
        int value = Random.Range(0, _maxChanceValue);

        if (_cube.CountSplit > 0)
        {
            return value < _maxValueToChance / _cube.CountSplit;
        }
        else 
        {
            return value < _maxValueToChance;
        }
    }
}
