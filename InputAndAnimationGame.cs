using InputAndAnimationGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01_animation_and_inputs;

public class InputAndAnimationGame : Game
{
    private const int _windowWidth = 1000;
    private const int _windowHeight = 535;
    private float _flowersX = 705, _flowersY = 95;
    private float _catX = 155, _catY = 260;
    private float _mouseX = 0, _mouseY = 450;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background, _flowers;
    private CelAnimationSequenceMultiRow _catSequence, _mouseSequence;
    private CelAnimationPlayerMultiRow _catAnimationPlayer, _mouseAnimationPlayer;
    private SpriteEffects catEffect, mouseEffect;
    
    

    public InputAndAnimationGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _windowWidth;
        _graphics.PreferredBackBufferHeight = _windowHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _background = Content.Load<Texture2D>("background");
        _flowers = Content.Load<Texture2D>("flowers");
        Texture2D catSpriteSheet = Content.Load<Texture2D>("cartoon_cat");
        _catSequence = new CelAnimationSequenceMultiRow(catSpriteSheet, 104, 65, 1 / 8f);
        _catAnimationPlayer = new CelAnimationPlayerMultiRow();
        _catAnimationPlayer.Play(_catSequence);

        Texture2D mouseSpriteSheet = Content.Load<Texture2D>("cartoon_mouse");
        _mouseSequence = new CelAnimationSequenceMultiRow(mouseSpriteSheet, 151, 67, 1 / 8f);
        _mouseAnimationPlayer = new CelAnimationPlayerMultiRow();
        _mouseAnimationPlayer.Play(_mouseSequence);
    }

    protected override void Update(GameTime gameTime)
    {
        _catAnimationPlayer.Update(gameTime);
        _mouseAnimationPlayer.Update(gameTime);
        
        KeyboardState kbCurrentState = Keyboard.GetState();
        //having cat move using WASD
        if (kbCurrentState.IsKeyDown(Keys.A)) 
        {
            _catX -= 1;
            catEffect = SpriteEffects.FlipHorizontally;
        }
        if (kbCurrentState.IsKeyDown(Keys.D)) 
        {
            _catX += 1;
            catEffect = SpriteEffects.None;
        }
        //having mouse move using arrow keys
        if (kbCurrentState.IsKeyDown(Keys.Right)) 
        {
            _mouseX += 2;
            mouseEffect = SpriteEffects.None;
        }
        if (kbCurrentState.IsKeyDown(Keys.Left)) 
        {
            _mouseX -= 2;
            mouseEffect = SpriteEffects.FlipHorizontally;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_flowers, new Vector2(_flowersX, _flowersY), Color.White);
        _catAnimationPlayer.Draw(_spriteBatch, new Vector2(_catX, _catY), catEffect);
        _mouseAnimationPlayer.Draw(_spriteBatch, new Vector2(_mouseX, _mouseY), mouseEffect);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
