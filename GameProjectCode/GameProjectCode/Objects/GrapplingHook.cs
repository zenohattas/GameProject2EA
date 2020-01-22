using GameProjectCode.Extensions;
using GameProjectCode.Models.Classes.Simulations;
using GameProjectCode.Models.Classes;
using GameProjectCode.Models.Interfaces;
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
        GrapplingHookSimulation GrapplingHookSimulation;
        bool IsShot;
        bool IsExtended;
        bool IsRetracting;
        
        IHasCollision OriginObject;
        IHasCollision HookedObject;
        Animation GrapplingHookHead;
        Animation GrapplingHookChain;

        public GrapplingHook(Dictionary<string, Animation> animations, Animation grapplingHookHead, Animation grapplingHookChain, IHasCollision origin) : base(animations, grapplingHookHead)
        {
            OriginObject = origin;
            Dimenions = new Vector2(5, 5);
            GrapplingHookChain = grapplingHookChain;
            GrapplingHookHead = grapplingHookHead;

            Mass originMass;
            //Rope simulation setup
            if (origin is IWeighted)
            {
                originMass = (origin as IWeighted).Mass;
            
                GrapplingHookSimulation = new GrapplingHookSimulation(
                originMass,
                0.2f,                              // Each Particle Has A Weight Of 200 Grams
                1f,                                 // The grapplingHook weighs 1kg
                10000.0f,                           // springConstant In The Rope
                0.05f,                              // Normal Length Of Springs In The Rope
                0.2f,                               // Spring Inner Friction Constant
                new Vector3D(0, -9.81f, 0),         // Gravitational Acceleration
                0.02f,                              // Air Friction Constant
                100.0f,                             // Ground Repel Constant
                0.2f,                               // Ground Slide Friction Constant
                2.0f);                               // Ground Absoption Constant
               
            }
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
                return RectangleExtension.GetCenter(OriginObject.CollisionRectangle);
            }
        }
        public override Vector2 Position 
        {
            get
            {
                if (HookedObject != null)
                {
                    return HookedObject.Position;
                }
                else
                {
                    return GrapplingHookSimulation.masses.Last<Mass>().Position;
                }
            }

            set
            {
                GrapplingHookSimulation.masses.Last<Mass>().Position = value;
            }
        }
        public override Vector2 Velocity
        {
            get
            {
                return new Vector2(GrapplingHookSimulation.ropeConnectionVel.x, GrapplingHookSimulation.ropeConnectionVel.y);
            }
            set
            {
                GrapplingHookSimulation.ropeConnectionVel.x = value.X;
                GrapplingHookSimulation.ropeConnectionVel.y = value.Y;
            }
        }

        public Vector2 Dimenions { get; }

        public void Collide(IHasCollision o)
        {
            if(!(o is ILiquid) && mouse.RightButton == ButtonState.Pressed)
            {
                if (IsExtended && !IsRetracting)
                {
                    HookedObject = o as IHasCollision;
                    GrapplingHookSimulation.Invert();

                }
            }
        }

        public void ResolveCollisions()
        {
            //
        }

        public void Shoot()
        {
            IsShot = true;
            IsExtended = true;
        }
        public void Release()
        {
            HookedObject = null;
        }
        protected override void draw(SpriteBatch spriteBatch)
        {
            if (Position != OriginPoint)
            {
                _animationManager.Position = OriginPoint;
                _animationManager.Play(GrapplingHookChain);
                base.draw(spriteBatch);
                for (int i = 1; i < GrapplingHookSimulation.masses.Count; i++)
                {
                    _animationManager.Position = GrapplingHookSimulation.masses[i].Position;
                    _animationManager.Play(GrapplingHookChain);
                    base.draw(spriteBatch);
                }
                if (HookedObject != null)
                {
                    _animationManager.Position = Position;
                }
                else
                {
                    _animationManager.Position = GrapplingHookSimulation.masses.Last<Mass>().Position;
                }
                _animationManager.Play(GrapplingHookHead);
                base.draw(spriteBatch);

            }
        }
        protected override void update(GameTime gametime)
        {
            if (mouse.RightButton != Mouse.GetState().RightButton)
            {
                mouse = Mouse.GetState();
                
                if (mouse.RightButton == ButtonState.Pressed)
                {
                    Shoot();
                }
                else
                {
                    Retract();
                    Release();
                }
            }
            if (Position != OriginPoint)
            {
                base.update(gametime);
                UpdateChain();
            }
                //GrapplingHookSimulation.operate((float)gametime.ElapsedGameTime.TotalSeconds);
        }

        private void Retract()
        {
            IsRetracting = true;
        }

        private void UpdateChain()
        {
            if (Math.Abs(OriginPoint.X - Position.X) > GrapplingHookSimulation.masses.Count * GrapplingHookChain.Frames[GrapplingHookChain.CurrentFrame].Frame.Width ||Math.Abs(OriginPoint.Y - Position.Y) > GrapplingHookSimulation.masses.Count * GrapplingHookChain.Frames[GrapplingHookChain.CurrentFrame].Frame.Height)
            {
                GrapplingHookSimulation.AddMass();
            }
            if (Math.Abs(OriginPoint.X - Position.X) < GrapplingHookSimulation.masses.Count * GrapplingHookChain.Frames[GrapplingHookChain.CurrentFrame].Frame.Width || Math.Abs(OriginPoint.Y - Position.Y) < GrapplingHookSimulation.masses.Count * GrapplingHookChain.Frames[GrapplingHookChain.CurrentFrame].Frame.Height)
            {
                GrapplingHookSimulation.RemoveMass();
            }
            if (OriginPoint == Position)
            {
                IsExtended = false;
                IsRetracting = false;
            }
        }

        protected override void Move()
        {
            if (HookedObject != null)
            {
                Velocity = new Vector2(0, 0);
            }
            else if (IsShot)
            {
                Velocity += new Vector2((mouse.X - Position.X) * 0.3f, (mouse.Y - Position.Y) * .3f);
                IsShot = false;
            }
            else if(IsRetracting)
            {
                if (Math.Abs(OriginPoint.X - Position.X) < 1 && Math.Abs(OriginPoint.Y - Position.Y) < 1)
                {
                    Position = OriginPoint;
                    IsRetracting = false;
                }
                else
                {
                    Velocity = new Vector2((OriginPoint.X - Position.X) * 0.3f, (OriginPoint.Y - Position.Y) * 0.3f);
                }
            }

        }
    }
}
