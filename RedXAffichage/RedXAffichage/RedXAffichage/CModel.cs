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
     public class CModel : IMove
    {
        float posi;
        float posiY1;
        float posiY2;
        float posiX1;
        float posiX3;
        float posiZ = 0.0f;
        // positionnement du model 4 fois
        Vector3 modelPosition;
        Vector3 modelPosition1;
        Vector3 modelPosition2;
        Vector3 modelPosition3;
        //position de la camera
        Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 820.0f);
        // la roation du model 
        float modelRotation;
        Model model;
        float aspectRatio;

        public float PosiZ
        {
            get
            {
                return posiZ;
            }

            set
            {
                posiZ = value;
            }
        }

        public CModel(Model model, float aspectRatio,float posi,float posiZ) 
        {
            this.model = model;
            this.aspectRatio = aspectRatio;
            this.PosiZ = posiZ;
            intit(posi, posiZ);
        }

        public void intit(float posi,float posiZ)
        {
             posiY1 = posi;
             posiY2 = -posi;
             posiX1 = posi;
             posiX3 = -posi;

            modelPosition = new Vector3(posiX1, 0.0f, posiZ);
            modelPosition1 = new Vector3(0.0f, posiY2, posiZ);
            modelPosition2 = new Vector3(0.0f, posiY1, posiZ);
            modelPosition3 = new Vector3(posiX3, 0.0f, posiZ);
        }

        public void Positionnement(Model model,Vector3 modelPosition, float angle)
        {
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            // Dessine le modèle. Un modèle peut avoir plusieurs mailles, de sorte que la boucle.
            foreach (ModelMesh mesh in model.Meshes)
            {
                // Ceci est où l'orientation de maillage est fixé, ainsi que 
                // votre appareil photo et de projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(modelRotation) * Matrix.CreateRotationZ(angle) * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 12.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
        public void update()
        {


        }

        public void draw()
        {

            Positionnement(model, modelPosition, -1.5708f); //droite
            Positionnement(model, modelPosition1, (float)Math.PI); //bas
            Positionnement(model, modelPosition2, 0.0f); //haut
            Positionnement(model, modelPosition3, 1.5708f); //gauche

        }

        public void tourDroite()
        {
            this.modelRotation += 0.02f;
        }

        public void tourGauche()
        {
            modelRotation -= 0.02f;
        }

        public void zoomMoin()
        {
            posiX1 += 1.0f;
            posiX3 -= 1.0f;
            PosiZ -= 5.0f;
            posiY1 += 1.0f;
            posiY2 -= 1.0f;
            modelPosition = new Vector3(posiX1, 0.0f, PosiZ);
            modelPosition1 = new Vector3(0.0f, posiY2, PosiZ);
            modelPosition2 = new Vector3(0.0f, posiY1, PosiZ);
            modelPosition3 = new Vector3(posiX3, 0.0f, PosiZ);
        }

        public void zoomPlus()
        {
            posiX1 -= 1.0f;
            posiX3 += 1.0f;
            PosiZ += 5.0f;
            posiY1 -= 1.0f;
            posiY2 += 1.0f;

            modelPosition = new Vector3(posiX1, 0.0f, PosiZ);
            modelPosition1 = new Vector3(0.0f, posiY2, PosiZ);
            modelPosition2 = new Vector3(0.0f, posiY1, PosiZ);
            modelPosition3 = new Vector3(posiX3, 0.0f, PosiZ);
        } 

        public string echo(float roation)
        {
            int lol;
            string dire = "ca ne marche pas";
            float degree = (roation * 180) / (float)Math.PI;
            if (roation < 0) {
                lol = -(int)degree / 360;
                degree = degree + (360 * lol);
                degree = degree + 360;
            }else
            {
                lol = (int)degree / 360;
                degree = degree - (360 * lol);
            }

            if (degree < 30 && degree > 0)
                dire = "Ocean Pacifique";
            else if (degree > 30 && degree < 97)
                dire = "Oceanie";
            else if(degree>97 && degree<135)
                dire = "Ocean Indien";
            else if (degree > 135 && degree < 203)
                dire = "Afrique";
            else if (degree > 203 && degree < 226)
                dire = "Ocean Atlantique";
            else if (degree > 226 && degree < 311)
                dire = "Amerique du Sud";
            else if (degree > 311 && degree < 359)
                dire = "Ocean Pacifique";

            return dire;
        }
    }
}
