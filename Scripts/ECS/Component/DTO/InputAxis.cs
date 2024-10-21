using Godot;
using System;

public readonly struct InputAxis {
    public double Value { get; init; }

    public InputAxis(double positive, double negative) {
        Value = positive - negative;
    }
}