using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatListener : MonoBehaviour
{
	public FloatVariable floatVariable;
	private float _previousValue = -1.0f;

	[System.Serializable]
	public class OnValueChanged : UnityEvent<float> { };
	public OnValueChanged onValueChanged;

	private void Update()
	{
		// If the color has changed (via the inspector), call SetColor on the color sync component.
		var value = floatVariable.RuntimeValue;
		if (value != _previousValue)
		{
			onValueChanged.Invoke(value);
			_previousValue = value;
		}
	}



}
