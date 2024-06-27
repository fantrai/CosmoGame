using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class AbstractMap : MonoBehaviour
{
    [SerializeField] AbstractPlanet[] planets;
    [SerializeField] float distance;

    [ContextMenu("Initialization")]
    public void CreateMap()
    {
        Debug.Log("aboba");//����������� ���� ��� ������ �������� �����
        ABOBA
    }
}
