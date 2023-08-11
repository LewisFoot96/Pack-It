namespace PackIT.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T>
{
  public T Id { get; protected set; } = default!;
  public int Version { get; protected set; }

  private static List<IDomainEvent> _events = new();

  public IEnumerable<IDomainEvent> Events = _events = new();
  
  private bool _versionIncremented;
  
  protected void AddEvent(IDomainEvent newEvent)
  {
    if (!_events.Any() && !_versionIncremented)
    {
      Version++;
      _versionIncremented = true;
      
      _events.Add(newEvent);
    }
  }

  protected void ClearEvents() => _events.Clear();
  
  protected void IncrementVersion()
  {
    if (_versionIncremented)
    {
      return;
    }

    Version++;
    _versionIncremented = true;
  }
}
