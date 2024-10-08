using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class FloatSync : RealtimeComponent<FloatModel>
{
	public FloatVariable _currentValue;
	private float _previousValue;

	protected override void OnRealtimeModelReplaced(FloatModel previousModel, FloatModel currentModel)
	{
		if (previousModel != null)
		{
			// Unregister from events
			previousModel.valueDidChange -= FloatDidChange;
		}

		if (currentModel != null)
		{
			// If this is a model that has no data set on it, populate it with the current mesh renderer color.
			if (currentModel.isFreshModel)
				currentModel.value = _currentValue.RuntimeValue;

			// Update the float to match the new model
			UpdateFloat();

			// Register for events so we'll know if the float changes later
			currentModel.valueDidChange += FloatDidChange;
		}
	}

	private void FloatDidChange(FloatModel model, float value)
	{
		// Update float variable
		UpdateFloat();
	}

	private void UpdateFloat()
	{
		// Get the float from the model and set it on the float variable.
		_currentValue.RuntimeValue = model.value;
	}

	public void SetFloat(float value)
	{
		// Set the float on the model
		// This will fire the floatChanged event on the model
		model.value = value;
	}

	private void Update()
	{
		// If the float has changed (via the inspector), call SetFloat on the float sync component.
		var value = _currentValue.RuntimeValue;
		if (value != _previousValue)
		{
			SetFloat(value);
			_previousValue = value;
		}
	}

}