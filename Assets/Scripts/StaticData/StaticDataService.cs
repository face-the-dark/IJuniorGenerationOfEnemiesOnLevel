using System.Collections.Generic;
using System.Linq;
using StaticData.SO;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService
    {
        private const string EnemiesStaticDataPath = "Enemies/StaticData";
        private const string TargetsStaticDataPath = "Targets/StaticData/Target";
        
        private Dictionary<EnemyType, EnemyStaticData> _enemies;
        private TargetStaticData _targetStaticData;

        public void LoadData()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>(EnemiesStaticDataPath)
                .ToDictionary(x => x.EnemyType, x => x);
            
            _targetStaticData = Resources
                .Load<TargetStaticData>(TargetsStaticDataPath);
        }

        public EnemyStaticData ForEnemy(EnemyType enemyType) =>
            _enemies.GetValueOrDefault(enemyType);
        
        public TargetStaticData ForTarget() =>
            _targetStaticData;
    }
}