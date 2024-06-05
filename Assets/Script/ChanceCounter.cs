using UnityEngine;

public class ChanceCounter : MonoBehaviour
{
    [SerializeField] private int _maxValueToChance = 10;
    [SerializeField] private int _maxChanceValue = 20;

    System.Random random = new System.Random();

    public bool IsCreatedChance()
    {
        int value = random.Next(_maxChanceValue);

        return value < _maxValueToChance;
    }
}
