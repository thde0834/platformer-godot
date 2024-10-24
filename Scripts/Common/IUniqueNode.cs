using Godot;

public interface IUniqueNode {
    public string GetUniqueName()
    {
        return "%" + this.GetType().Name;
    }
}