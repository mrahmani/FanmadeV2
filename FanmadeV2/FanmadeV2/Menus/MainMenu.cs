using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FanmadeV2.Menus
{
    class MainMenu
    {
        private enum Button
        {
            Start,
            Exit
        };

        #region Properties

        private Texture2D Background { get; set; }
        private Texture2D StartUnselected { get; set; }
        private Texture2D StartSelected { get; set; }
        private Texture2D ExitUnselected { get; set; }
        private Texture2D ExitSelected { get; set; }
        private static Button SelectedButton { get; set; }

        #endregion

        //Default to having the start button selected
        MainMenu()
        {
            SelectedButton = Button.Start;
        }

        void Update(GameState gameState)
        {
            KeyboardState keyState = Keyboard.GetState();
            if(keyState.IsKeyDown(Keys.Down) && SelectedButton != Button.Exit)
                SelectedButton++;
            if (keyState.IsKeyDown(Keys.Up) && SelectedButton != Button.Start)
                SelectedButton--;

            //TODO: modify GameState based on menu selection
        }
    }
}
