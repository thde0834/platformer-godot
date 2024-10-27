using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public record class Family {
    private List<BaseComponent> Components;
    public Family(params BaseComponent[] components) {
        this.Components = components.ToList();
    }
}