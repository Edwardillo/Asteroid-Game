using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle Rnave;
        Texture2D nave;
        Texture2D disparo;
        Rectangle rbola;
        Texture2D bola;
        int j;
        List<Disparos> Ldisparos = new List<Disparos> { };
        List<BOLAS> lbolas = new List<BOLAS> { };
        int velocidadX=5;
        int velocidadY=5;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Rnave = new Rectangle(500 ,400,48,48);
            nave = this.Content.Load<Texture2D>(@"Imagenes/bs");
            disparo = this.Content.Load<Texture2D>(@"Imagenes/bulleteu1");
            //rbola = new Rectangle(50,50,64,64);
            bola = this.Content.Load<Texture2D>(@"Imagenes/bola");
            if(lbolas.Count<=20)

            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            rbola.X+=velocidadX;
            rbola.Y += velocidadY;
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.Right))
               Rnave.X+=5;

            if(Keyboard.GetState().IsKeyDown(Keys.Left))
               Rnave.X-=5;


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                Ldisparos.Add(new Disparos { posicionX = Rnave.X, tdisparo = disparo});

            foreach (Disparos idisparo in Ldisparos)
            {
                idisparo.Update();
            }

            for (j = 0; j < Ldisparos.Count; j++)
                if(Ldisparos[j].rdisparo.Y < 0)
                    Ldisparos.Remove(Ldisparos[j]);
            
            


            if (Rnave.X <= 0)
                Rnave.X = 0;

            
            if (Rnave.X + nave.Width >= 800)
                Rnave.X = 800 - nave.Width;
            
           
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Disparos idisparo in Ldisparos)
                idisparo.draw(spriteBatch);
            
            spriteBatch.Begin();

            spriteBatch.Draw(nave, Rnave, Color.White);

            spriteBatch.Draw(bola, rbola, Color.White);

            spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
