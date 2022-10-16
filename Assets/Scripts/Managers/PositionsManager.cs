using RollABall.Data;
using RollABall.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RollABall.Managers
{
    public class PositionsManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> positions;
        private kindofRepository repository;

        private readonly KeyCode _saveData = KeyCode.K;
        private readonly KeyCode _loadData = KeyCode.L;

        private void OnEnable()
        {
            repository = new();
        }
        private void Update()
        {
            if (Input.GetKeyDown(_saveData))
            {
                repository.Save(positions);
            }
            else if (Input.GetKeyDown(_loadData))
            {
                repository.Load(positions);
            }
        }
    }
}
