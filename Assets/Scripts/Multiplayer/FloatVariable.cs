using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
	public float InitialValue;

	[NonSerialized]
	public float RuntimeValue;

	public void OnAfterDeserialize()
	{
		RuntimeValue = InitialValue;
	}

	public void OnBeforeSerialize() { }

	public void SetValue(float val)
	{
		RuntimeValue = val;
	}
}