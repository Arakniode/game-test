using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game1.Classes {
    class Pirhana {

        private Texture2D texture;
        public Vector2 pos;
        public Vector2 vel;
        private float speed = 0.1f;

        public Pirhana() {
            this.pos = Vector2.Zero;
            this.vel = Vector2.Zero;
        }

        public void LoadContent(ContentManager content) {
            texture = content.Load<Texture2D>("pirhana");
        }

        public void Update(GameTime gt) {

            // keyboard management
            KeyboardState kstate = Keyboard.GetState();
            Keys[] keys = kstate.GetPressedKeys();

            if (keys.Contains(Keys.Up) && !keys.Contains(Keys.Down))
                this.vel.Y = -speed * (float)gt.ElapsedGameTime.TotalMilliseconds;
            else this.vel.Y = 0f;

            if (keys.Contains(Keys.Down) && !keys.Contains(Keys.Up))
                this.vel.Y = speed * (float)gt.ElapsedGameTime.TotalMilliseconds;
            else this.vel.Y = 0f;

            if (keys.Contains(Keys.Left) && !keys.Contains(Keys.Right))
                this.vel.X = -speed * (float)gt.ElapsedGameTime.TotalMilliseconds;
            else this.vel.X = 0f;

            if (keys.Contains(Keys.Right) && !keys.Contains(Keys.Left))
                this.vel.X = speed * (float)gt.ElapsedGameTime.TotalMilliseconds;
            else this.vel.X = 0f;

            // normalize vector for diagonal movement
            if(this.vel.Length() != 0) {
                this.vel.X /= this.vel.Length();
                this.vel.Y /= this.vel.Length();
            }

            // move (apparently you can override operators in C# :D)
            this.pos += this.vel;
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(texture, pos, Color.White);
        }
    }
}
