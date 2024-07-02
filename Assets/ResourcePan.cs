using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePan : MonoBehaviour
{
    [SerializeField] Image ico;
    [SerializeField] TextMeshProUGUI countTextBlock;

	public Sprite Ico
	{
		set { ico.sprite = value; }
	}

	public int Count
	{
		set { countTextBlock.text = value.ToString(); }
	}
}
