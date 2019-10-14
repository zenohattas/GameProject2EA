using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Sprites
{
    abstract class Sprite_Base
    { 
        #region Fields

    protected Texture2D _texture;

    protected AnimationManager _animationManager;

    protected Dictionary<string, Animation> _animations;

    protected Vector2 _position;

    #endregion
    #region Properties

    public Input Input;

    public Vector2 Position
    {
        get { return _position; }
        set
        {
            _position = value;

            if (_animationManager != null)
            {
                _animationManager.Position = _position;
            }
        }
    }

    public float Speed = 0.8f;

    public Vector2 Velocity;

    #endregion

    #region Method

    public Sprite_Base(Texture2D texture)
    {
        _texture = texture;
    }
    public Sprite_Base(Dictionary<string, Animation> animations)
    {
        _animations = animations;
        _animationManager = new AnimationManager(_animations.First().Value);
    }
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (_texture != null)
            spriteBatch.Draw(_texture, Position, Color.White);
        else if (_animationManager != null)
            _animationManager.Draw(spriteBatch);
        else throw new Exception("This ain't right..!");
    }

    protected abstract void Move();

    protected abstract void SetAnimations();
    public virtual void Update(GameTime gametime, List<Sprite_Base> sprites)
    {
        Move();

        SetAnimations();

        _animationManager.Update(gametime);

        Position += Velocity;

        Velocity = Vector2.Zero;
    }

        #endregion
    }
}
