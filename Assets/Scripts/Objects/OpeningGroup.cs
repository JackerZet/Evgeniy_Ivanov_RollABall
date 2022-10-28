using RollABall.Interactivity;
using System;
using UnityEngine;

namespace RollABall.Objects
{
    [Serializable]
    public class OpeningGroup
    {
        [field: SerializeField] public Opener Openable { get; private set; }
        [field: SerializeField] public Door Locked { get; private set; }

        public int Id { get; private set; }
        public void SetId(int id)
        {
            Id = id;
                       
            Openable.Index.Add(id);
            Locked.Index.Add(id);                     
        }             
    }
}
