using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace the_skyfarer;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public RenderTarget2D renderTarget;

    public Vector2 screenSize=new(256,192);
    public Rectangle windowRect;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 768;
        _graphics.PreferredBackBufferHeight = 576;
        _graphics.ApplyChanges();



        renderTarget= new(GraphicsDevice,(int)screenSize.X,(int)screenSize.Y);
        float s=Math.Min(_graphics.PreferredBackBufferWidth/renderTarget.Width,_graphics.PreferredBackBufferHeight/renderTarget.Height);

        windowRect=new(0,0,(int)(renderTarget.Width*s),(int)(renderTarget.Height*s));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
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
        GraphicsDevice.SetRenderTarget(renderTarget);
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        _spriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        _spriteBatch.Begin(samplerState:SamplerState.PointClamp);
        _spriteBatch.Draw(renderTarget,windowRect,Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
