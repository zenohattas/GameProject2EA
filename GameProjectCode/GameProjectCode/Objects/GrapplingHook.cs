using GameProjectCode.Extensions;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class GrapplingHook : MoveableGameObject, ICollidable
    {
        MouseState mouse;
        bool IsShot;
        
        Vector2 _position;
        IHasCollision OriginObject;
        IHasCollision HookedObject;
        Animation GrapplingHookHead;
        List<Animation> GrapplingHookChain;

        public GrapplingHook(Dictionary<string, Animation> animations, Animation grapplingHookHead, Animation grapplingHookChain, IHasCollision origin) : base(animations, grapplingHookHead)
        {
            OriginObject = origin;
            Dimenions = new Vector2(5, 5);
            GrapplingHookChain = new List<Animation>();
            GrapplingHookChain.Add(grapplingHookChain);
            GrapplingHookHead = grapplingHookHead;
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle(Position.ToPoint(), Dimenions.ToPoint());
            }
        }
        public Vector2 OriginPoint
        {
            get
            {
                return RectangleExtension.GetBottomCenter(OriginObject.CollisionRectangle);
            }
        }
        public Vector2 Position 
        {
            get
            {
                if (HookedObject != null)
                {
                    return HookedObject.Position;
                }
                else
                {
                    return _position;
                }
            }

            set
            {
                _position = value;
            }
        }

        public Vector2 Dimenions { get; }

        public void Collide(IHasCollision o)
        {
            if(!(o is ILiquid) && mouse.RightButton == ButtonState.Pressed)
            {
                HookedObject = o as IHasCollision;
            }
        }

        public void ResolveCollisions()
        {
            //
        }

        public void Shoot()
        {
            IsShot = true;
        }
        public void Release()
        {
            HookedObject = null;
        }
        protected override void draw(SpriteBatch spriteBatch)
        {

            base.draw(spriteBatch);
        }
        protected override void update(GameTime gametime)
        {
            mouse = Mouse.GetState();
            base.update(gametime);
            UpdateChain();
        }

        private void UpdateChain()
        {
            if (Math.Abs(OriginPoint.X - Position.X) > GrapplingHookChain.Count*GrapplingHookChain[0].Frames[GrapplingHookChain[0].CurrentFrame].Frame.Width||Math.Abs(OriginPoint.Y - Position.Y) > GrapplingHookChain.Count * GrapplingHookChain[0].Frames[GrapplingHookChain[0].CurrentFrame].Frame.Height)
            {
                GrapplingHookChain.Add(GrapplingHookChain[0].Duplicate());
            }
            if (Math.Abs(OriginPoint.X - Position.X) > GrapplingHookChain.Count * GrapplingHookChain[0].Frames[GrapplingHookChain[0].CurrentFrame].Frame.Width || Math.Abs(OriginPoint.Y - Position.Y) > GrapplingHookChain.Count * GrapplingHookChain[0].Frames[GrapplingHookChain[0].CurrentFrame].Frame.Height)
            {
                GrapplingHookChain.Add(GrapplingHookChain[0].Duplicate());
            }
        }

        protected override void Move()
        {
            if (IsShot)
            {
                Velocity += new Vector2((mouse.X - Position.X) * 0.3f, (mouse.Y - Position.Y) * 0.3f);
            }
            else if (HookedObject != null)
            {
                Velocity = new Vector2(0, 0);
            }
            else
            {
                Position += new Vector2((OriginPoint.X - Position.X) * 0.3f, (OriginPoint.Y - Position.Y) * 0.3f);
            }
            Position += Velocity;

        }
    }
}
