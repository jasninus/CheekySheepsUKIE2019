﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class FireDamageSystem : JobComponentSystem
{
    private struct FireDamageJob : IJobForEach<Temperature, Health, Death>
    {
        public float maxTempBeforeDamage, healthLossPerTick;

        public void Execute(ref Temperature temperature, ref Health health, ref Death death)
        {
            if (temperature.temperature > maxTempBeforeDamage)
            {
                health.health = math.max(health.health - healthLossPerTick, 0);

                if (health.health <= 0)
                {
                    death.isDead = true;
                }
            }
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new FireDamageJob
        {
            maxTempBeforeDamage = 80f,
            healthLossPerTick = 0.1f
        };

        return job.Schedule(this, inputDeps);
    }
}