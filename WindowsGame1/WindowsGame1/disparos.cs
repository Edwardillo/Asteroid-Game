using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    public class Disparos
    {
        float aceleracion = -10f, velocidad=-100f;
        public Rectangle rdisparo;
        public Texture2D tdisparo;
        public int posicionX;
        
        public void Update()
        {

            rdisparo = new Rectangle(posicionX, 500, 15, 32);
            rdisparo.Y += (int)velocidad;

            velocidad += aceleracion;
            
            


        }

        public void draw(SpriteBatch spritebath)
        {
            spritebath.Begin();

            spritebath.Draw(tdisparo, rdisparo, Color.White);

            spritebath.End();
        }
    }
}
