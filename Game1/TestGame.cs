using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// HELLO EST-CE QUE CA MARCHE
namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestGame : Game
    {
        GraphicsDeviceManager graphicsDevice;
        RenderTarget2D renderTarget;
        float renderTargetScale = 0;

        SpriteBatch spriteBatch;
        Texture2D pirhanaTexture;

        public TestGame()
        {
            graphicsDevice = new GraphicsDeviceManager(this);
            graphicsDevice.PreferredBackBufferWidth = 640;
            graphicsDevice.PreferredBackBufferHeight = 480;
            graphicsDevice.ApplyChanges();

            renderTarget = new RenderTarget2D(GraphicsDevice, 160, 120);
            renderTargetScale = graphicsDevice.PreferredBackBufferHeight / renderTarget.Height;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pirhanaTexture = Content.Load<Texture2D>("pirhana");
        }
        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MediumAquamarine);

            // drawing code
            GraphicsDevice.SetRenderTarget(renderTarget);
            spriteBatch.Begin();
            spriteBatch.Draw(pirhanaTexture, Vector2.Zero, Color.White);
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
