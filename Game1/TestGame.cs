using Game1.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class TestGame : Game
    {
        GraphicsDeviceManager graphicsDevice;
        RenderTarget2D renderTarget;
        float renderTargetScale = 4f;

        SpriteBatch spriteBatch;
        Pirhana pirhana;

        public TestGame()
        {
            graphicsDevice = new GraphicsDeviceManager(this);
            graphicsDevice.PreferredBackBufferWidth = 640;
            graphicsDevice.PreferredBackBufferHeight = 480;
            graphicsDevice.ApplyChanges();

            renderTarget = new RenderTarget2D(GraphicsDevice, 160, 120);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            pirhana = new Pirhana();

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pirhana.LoadContent(Content);
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            // check if the player exits the game
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            pirhana.Update(gameTime);

            //base.Update(gameTime);
            
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumAquamarine);

            // drawing code
            GraphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin();
            pirhana.Draw(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            spriteBatch.Draw(renderTarget, new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth / 2,
                                                       GraphicsDevice.PresentationParameters.BackBufferHeight / 2),
                             null, Color.White, 0f, new Vector2(renderTarget.Width / 2, renderTarget.Height / 2),
                             renderTargetScale, SpriteEffects.None, 0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
