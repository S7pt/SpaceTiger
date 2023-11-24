using UnityEngine;

public abstract class UIWindow : MonoBehaviour
{
    public virtual void Enable()
	{
		SetActive(true);
	}

	public virtual void Disable()
	{
		SetActive(false);
	}

	protected virtual void SetActive(bool isActive)
	{
		gameObject.SetActive(isActive);
	}
}
