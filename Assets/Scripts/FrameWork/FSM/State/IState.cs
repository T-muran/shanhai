//IState-->提供给父级状态机
public interface IState 
{
    void Initialize(IStateParent parent);
    void OnEnter();
    void OnUpdate();
    void OnExit();
    void OnFixedUpdate();
}
