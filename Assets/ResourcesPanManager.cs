using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesPanManager : MonoBehaviour
{
    [SerializeField] ResourcePan resourcesPanPrefab;

    Dictionary<EnumMatherials, ResourcePan> resources = new Dictionary<EnumMatherials, ResourcePan>();

    private void OnEnable()
    {
        IPlayer.OnUpdateMatherial += UpdateMatherial;
    }

    private void OnDisable()
    {
        IPlayer.OnUpdateMatherial -= UpdateMatherial;
    }

    void UpdateMatherial(IMatherial matherial, int count)
    {
        if (resources.ContainsKey(matherial.Matherial))
        {
            resources[matherial.Matherial].Count = count;
        }
        else
        {
            ResourcePan resource = Instantiate(resourcesPanPrefab.gameObject).GetComponent<ResourcePan>();
            resources.Add(matherial.Matherial, resource);
            resource.Count = count;
            resource.Ico = matherial.Ico;
            resource.gameObject.transform.SetParent(gameObject.transform, false);
        }
    }
}
