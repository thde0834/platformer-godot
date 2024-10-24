public class InputType : Enumeration {
    public static InputType Up = new(1, "ui_up");
    public static InputType Down = new(2, "ui_down");
    public static InputType Left = new(3, "ui_left");
    public static InputType Right = new(4, "ui_right");

    public InputType(int id, string name) : base(id, name) {}
}

