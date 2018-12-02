﻿using Assets.Scripts.Gameplay.World;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Resources
{
    public class CollectableResource : MonoBehaviour
    {
        [SerializeField] private uint amount;

        [SerializeField] private ResourceType resourceType;

        /// <summary>
        /// If true, destroys its game object when amount reaches 0.
        /// </summary>
        [SerializeField] private bool selfDestroying = true;

        [SerializeField] private bool blocksBuilding = true;

        public Tile placedTile;

        public uint Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                if (amount <= 0 && selfDestroying)
                {
                    Destroy(gameObject);
                    if(blocksBuilding)
                    {
                        placedTile.IsBuildable = true;
                    }
                }
            }
        }

        public ResourceType ResourceType
        {
            get { return resourceType; }
            set { resourceType = value; }
        }


        public void Initialize(Tile myTile)
        {
            placedTile = myTile;
            if (blocksBuilding)
            {
                placedTile.IsBuildable = false;
            }
        }
    }
}
