public abstract class StateBase : IState
{
    //关联父级状态机
    protected IStateParent Parent { get; private set; }

    void IState.Initialize(IStateParent parent)
    {
        Parent = parent;
        Initialize();
    }

    void IState.OnEnter() => OnEnter();

    void IState.OnExit() => OnExit();

    void IState.OnFixedUpdate() => OnFixedUpdate();

    void IState.OnUpdate() => OnUpdate();

    protected virtual void Initialize() { }
    protected virtual void OnEnter() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnExit() { }
    protected virtual void OnFixedUpdate() { }
}
