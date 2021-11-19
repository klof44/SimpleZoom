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
                DevConsole.Log("SimpleZoom Enabled: " + zoom.ToString());
            }
            if (Keyboard.Down(Keys.OemOpenBrackets) && flote > 1 && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                flote--;
            }
            if (Keyboard.Down(Keys.OemCloseBrackets) && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                flote++;
            }
        }
        public void Update()
        {
            if (Keyboard.Pressed(Keys.OemQuotes) && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                eent++;
            }
            if (Keyboard.Pressed(Keys.OemSemicolon) && !DuckNetwork.core.enteringText && !DevConsole.core.open)
            {
                eent--;
            }
        }
        public void PostUpdate()
        {
            Duck d = Duck.Get(eent);
            if (zoom && d != null && !(Level.current is RockIntro) && !(Level.current is RockScoreboard) && !rock)
            {
                float six = flote * 16f;
                float nine = flote * 9f;
                Vec2 vec = new Vec2(six, nine);
                if (zoom)
                {
                    Layer.Foreground.camera.size = vec;
                    Layer.Foreground.camera.center = d.GetPos();
                }
                if (d.dead)
                {
                    eent++;
                }
            }
            if (d == null)
            {
                eent++;
            }
            if (eent > 7)
            {
                eent = 0;
            }
        }
        public void OnDrawLayer(Layer l)
        {
            bool draw = l == Layer.Console;
            if (draw && zoom)
            {
                Graphics._biosFont.Draw("Zoom Enabled", 1, Layer.Console.camera.bottom - 8, Color.White);
            }
        }
        internal static bool zoom = false;
        internal static bool rock = false;
        private float flote = 20;
        private int eent = 0;
    }
}
