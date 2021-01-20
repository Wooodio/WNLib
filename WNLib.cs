using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace RevenantAwoken
{
    public class WNLib
    {
        public static string ColorText(string text, Color color)
        {
            return "[c/" + color.Hex3() + ":" + text + "]";
        }
        public static string ItemText(int id)
        {
            return  "[i:" + id + "]";
        }
    }
}