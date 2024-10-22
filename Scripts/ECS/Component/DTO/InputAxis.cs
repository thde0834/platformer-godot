using Godot;
using System;

public readonly struct InputAxis {
    public double Value { get; init; }

    public InputAxis(IComparable positive, IComparable negative) {
        Value = positive.CompareTo(negative);
    }
}