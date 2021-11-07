using UnityEngine;
using System.Collections;

public class TimeScaleIndependentParticleSystem : TimeScaleIndependentUpdate
{
	[SerializeField] private ParticleSystem particleSystem;
	protected override void Update()
	{
		base.Update();

        particleSystem.Simulate(deltaTime, true, false);
	}
}