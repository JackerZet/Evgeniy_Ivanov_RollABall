using RollABall.Interfaces;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RollABall.Data
{    
    public class kindofRepository //I'll rewrite this class )
    {
        private const string _folderName = "DataSave";
        private const string _fileName = "data.json";

        private readonly IData<LevelPositionsData> _data;
        private readonly string _path;
        public kindofRepository()
        {
            _data = new JsonData<LevelPositionsData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }
        public void Save(List<Transform> transforms)
        {
            if (!Directory.Exists(Path.Combine(_path)))           
                Directory.CreateDirectory(_path);
            
            List<Vector3_Serializable> positions = new();

            foreach(var t in transforms)           
                positions.Add((Vector3_Serializable)t.position);
            
            var savePlayer = new LevelPositionsData { positions = positions };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }
        public void Load(List<Transform> transforms)
        {
            var file = Path.Combine(_path, _fileName);

            if (!File.Exists(file)) return;

            var positionsData = _data.Load(file);

            for(int i = 0; i < positionsData.positions.Count; i++)            
                transforms[i].position = (Vector3)positionsData.positions[i];                       
        }
    }
}
