using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShipElement : MonoBehaviour, IShipElement
{
    [SerializeField, Min(0.001f)] protected float cooldown = 1;

	float timeAfterCooldown;
	public float TimeAfterCooldown
	{
		get { return timeAfterCooldown; }
		set 
		{ 
			timeAfterCooldown = value;
			while (timeAfterCooldown > cooldown)
			{
                Effect();
                timeAfterCooldown -= cooldown;
            }
		}
	}

	[SerializeField] protected string nameElement;
    string IShipElement.NameElement { get => nameElement; set => nameElement = value; }
    [SerializeField] protected string descriptionElement;
    string IShipElement.DescriptionElement { get { return descriptionElement; } set { descriptionElement = value; } }

    protected abstract void Effect();

    public IShipElement StartUse(Transform parent)
    {
		var result = Instantiate(gameObject);
		result.transform.parent = parent;
		return result.GetComponent<AbstractShipElement>();
    }
}
