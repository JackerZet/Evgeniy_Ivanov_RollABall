using RollABall.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.Interactivity
{
    public abstract class Opener : InteractiveObject, IIndexHaving
    {
        public List<int> Index { get; set; } = new();
        public abstract void Open();
        protected override void Interaction(GameObject gameobject) { }
    }
}
