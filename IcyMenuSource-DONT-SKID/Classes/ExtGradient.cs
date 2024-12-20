﻿using System;
using UnityEngine;

namespace StupidTemplate.Classes
{
    public class ExtGradient
    {
        public GradientColorKey[] colors = new GradientColorKey[]
        {
            new GradientColorKey(Color.cyan, 0f),
            new GradientColorKey(Color.cyan, 0.5f),
            new GradientColorKey(Color.cyan, 1f)
        };

        public bool isRainbow = false;
        public bool copyRigColors = false;
    }
}
