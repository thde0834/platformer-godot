using Godot;

public interface IUniqueNode {
    public static string GetUniqueName<T>() where T : Node 
    {
        return "%" + typeof(T).Name;
    }
}