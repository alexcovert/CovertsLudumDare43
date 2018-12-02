﻿using Assets.Scripts.Gameplay.People;
using Assets.Scripts.Gameplay.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Buildings
{
    public class Farm : WorkableTarget
    {
        [SerializeField] private int foodPerWork = 7;
        [SerializeField] private Animation animPlayer;
        
        public override Job job
        {
            get
            {
                return Job.Farmer;
            }
        }

        public override void WorkerAssigned(PersonAI aI)
        {
            base.WorkerAssigned(aI);
            aI.ReachedDestination = true;
            animPlayer.Play();
        }

        public override void WorkerFreed(PersonAI aI)
        {
            base.WorkerFreed(aI);
            animPlayer.Stop();
        }

        public override void DoWork(PersonAI aI)
        {
            GameplayController.instance.CurrentResources.Food += foodPerWork;
        }

    }
}