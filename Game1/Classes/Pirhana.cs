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

        public void LoadContent(ContentManager content) {
            texture = content.Load<Texture2D>("pirhana");
        }

        public void Update(GameTime gt) {

        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(texture, new Vector2(0, 0), Color.White);
        }
    }
}
