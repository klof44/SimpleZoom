using System;
using DuckGame;

namespace DuckGame.SimpleZoom
{
    public class SimpleUpdate : IEngineUpdatable
    {
        public SimpleUpdate()
        {
            MonoMain.RegisterEngineUpdatable(this);
        }
        public void PreUpdate()
        {
            if (Keyboard.Pressed(Keys.F10))
            {
                zoom = !zoom;
            }
            if (Keyboard.Down(Keys.OemOpenBrackets) && zoomNum > 1 && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                zoomNum--;
            }
            if (Keyboard.Down(Keys.OemCloseBrackets) && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                zoomNum++;
            }
        }
        public void Update()
        {
            if (Keyboard.Pressed(Keys.OemQuotes) && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                duck++;
                right = true;
            }
            if (Keyboard.Pressed(Keys.OemSemicolon) && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                duck--;
                right = false;
            }

            if (duck < 0)
            {
                duck = 7;
            }
            if (duck > 7)
            {
                duck = 0;
            }
        }
        public void PostUpdate()
        {
            Duck d = Duck.Get(duck);
            if (zoom && d != null && !(Level.current is RockIntro) && !(Level.current is RockScoreboard) && !rock)
            {
                float six = zoomNum * 16f;
                float nine = zoomNum * 9f;
                Vec2 vec = new Vec2(six, nine);
                if (zoom)
                {
                    Layer.Foreground.camera.size = vec;
                    Layer.Foreground.camera.center = d.GetPos();
                }
                if (d.dead && right)
                {
                    duck++;
                }
                else if (d.dead && !right)
                {
                    duck--;
                }
            }
            if (d == null && right)
            {
                duck++;
            }
            else if (d == null && !right)
            {
                duck--;
            }
        }
        public void OnDrawLayer(Layer l)
        {
            bool draw = l == Layer.Console;
            if (draw && zoom && !rock)
            {
                Graphics._biosFont.Draw(duck.ToString(), 1, Layer.Console.camera.bottom - 8, Color.White);
            }
        }
        internal static bool zoom = false;
        internal static bool rock = false;
        private float zoomNum = 20;
        private int duck = 0;
        private bool right = true;
    }
}
