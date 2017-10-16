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
using RedXControl;
using MovementWatcher;
using System.Speech.Synthesis;

namespace RedXAffichage
{
    class Scene : Iscene
    {
        int i = 1;
        //private Texture2D _zozor;
        ContentManager Content;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpeechSynthesizer synth = new SpeechSynthesizer();
        float aspectRatio;
        CModel cmodel;
        LoadModel loadmodel;
        KinectListner listner = new KinectListner();
        KinectWatcher watcher = new KinectWatcher();
        
        public Scene(GraphicsDeviceManager graphics,  SpriteBatch spriteBatch , ContentManager content)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.Content = content;
            watcher.Subscribe(listner);
            watcher.MovementParser();
           
        }


        public void LoadContent()
        {
            synth.SetOutputToDefaultAudioDevice();
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;
            loadmodel = new LoadModel(aspectRatio, graphics, Content);
            cmodel = loadmodel.Create(4);
        }

        public void update()
        {
            KeyboardState newState = Keyboard.GetState();
            //tourne gauche
            if (newState.IsKeyDown(Keys.Left))
            {
                cmodel.tourGauche();
            }
            //tourne droite
            if (newState.IsKeyDown(Keys.Right))
            {
                cmodel.tourDroite();
            }
            //zoom ++++
            if (newState.IsKeyDown(Keys.Up))
            {
                cmodel.zoomPlus();
            }
            //zoom ----
            if (newState.IsKeyDown(Keys.Down))
            {
                cmodel.zoomMoin();
            }

            //son globe
            if (newState.IsKeyDown(Keys.D) && i == 3)
            {
                float angleview = cmodel.PosiZ;
                string speak = cmodel.echo(angleview);
                synth.Speak(speak);
            }

            if (newState.IsKeyDown(Keys.D) && i == 2)
            {
                synth.Speak("La statue de la Liberté , est l'un des monuments les plus célèbres des États-Unis. Cette statue monumentale est située à New York, sur l'île de Liberty Island au sud de Manhattan, à l'embouchure de l'Hudson et à proximité d'Ellis Island.");
            }

            // load watcher
            if (newState.IsKeyDown(Keys.Space) && i !=1)
            {
                cmodel = loadmodel.Create(1);
                i = 1;
            }
            // load statut
            if (newState.IsKeyDown(Keys.Space) && i != 2)
            {
                cmodel = loadmodel.Create(2);
                i = 2;
            }
            // load globe
            if (newState.IsKeyDown(Keys.Space) && i != 3)
            {
                cmodel = loadmodel.Create(3);
                i = 3;
            }
        }
        
        public void draw()
        {
            //spriteBatch.Begin();
            //spriteBatch.Draw(_zozor, Vector2.Zero, Color.White);
            //spriteBatch.End();
            cmodel.draw();

        }

    }
}
