using UnityEngine;
public class Test : MonoBehaviour
{
    private void Start()
    {        
        int a = 4,b = 89;//�������, ��� ������� ���� ������ ������� ������������ � ����� �� ��������� 8 ������ �����������
        Debug.Log($"a = {a}, b = {b}");
        a += b;
        b = a - b;
        a -= b;
        Debug.Log($"a = {a}, b = {b}");
    }
}
