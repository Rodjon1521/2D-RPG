using _Scripts.StaticData;

namespace _Scripts.Infrastructure.Services
{
    public interface IStaticDataService : IService
    {
        void LoadMonsters();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
    }
}