﻿using System;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.GUI.Elements
{
    public class GameLine : GameElement, ILine
    {
        protected Vector SecondPosition;

        public GameLine(DateTime maxLifeTime, ByteColor color, Vector realPosition, Vector secondPosition) : base(
            maxLifeTime, color, realPosition)
        {
            this.SecondPosition = secondPosition;
        }

        public override bool Calculate()
        {
            Vector dst = new Vector();
            if (base.Calculate() && ExtraMath.WorldToScreen(SecondPosition, ref dst))
            {
                X2 = (int) dst.X;
                Y2 = (int) dst.Y;
                return true;
            }

            return false;
        }

        public override void Draw()
        {
            TimeUpdate();

            if (!IsValid)
                return;

            if (!Calculate())
                return;

            SDK.Surface.SetDrawColor(Color);
            SDK.Surface.DrawLine(X, Y, X2, Y2);
        }

        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}