namespace generics.Interfaces
{

interface IRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    void Add(TKey id, TEntity entity);
    TEntity Get(TKey id);
    IEnumerable<TEntity> GetAll();
    void Remove(TKey id);
}

interface IReadOnlyRepository<out TEntity, in TKey>
{
    TEntity Get(TKey id);
    IEnumerable<TEntity> GetAll();
}


class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>, IReadOnlyRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    private Dictionary<TKey, TEntity> _storage = new Dictionary<TKey, TEntity>();

    public void Add(TKey id, TEntity entity)
    {
        if (_storage.ContainsKey(id))
        {
            _storage[id] = entity;
        }
        else
        {
            _storage.Add(id, entity);
        }
    }

    public TEntity Get(TKey id)
    {
        if (_storage.TryGetValue(id, out TEntity entity))
        {
            return entity;
        }
        return null;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _storage.Values;
    }

    public void Remove(TKey id)
    {
        _storage.Remove(id);
    }

}
