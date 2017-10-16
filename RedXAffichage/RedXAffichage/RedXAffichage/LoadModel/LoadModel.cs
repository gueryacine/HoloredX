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
namespace RedXAffichage
{
   public class LoadModel : ILoadModel
    {

        float aspectRatio;
        GraphicsDeviceManager graphics;
        ContentManager Content;



        public LoadModel(float aspectRatio, GraphicsDeviceManager graphics, ContentManager Content)
        {
            this.aspectRatio = aspectRatio;
            this.graphics = graphics;
            this.Content = Content;
        }
        
        public CModel Create(int i)
        {
            Model model;
            CModel cmodel = null;

            if (i == 1)
            {
                model = Content.Load<Model>("watcher");
                cmodel = new CModel(model, aspectRatio, 120, 0);
            }
            else if(i==2)
            {
                model = Content.Load<Model>("Liberty");
                cmodel = new CModel(model, aspectRatio, 25, 700);
            }
            else if (i == 3)
            {
                model = Content.Load<Model>("earth");
                cmodel = new CModel(model, aspectRatio, 200, 0);
            }
            else if (i == 4)
            {
                model = Content.Load<Model>("HouseLow");
                cmodel = new CModel(model, aspectRatio, 500, -1500);
            }
            return cmodel;
        }


    }
}
