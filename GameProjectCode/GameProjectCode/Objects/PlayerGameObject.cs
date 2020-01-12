using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameProjectCode.Objects
{
    class PlayerGameObject : ControlledGameObject, ICollidable, IJump, IAnimated, IDamagable
    {
        private bool Collided;
        private int JumpsLeft;
        private bool IsfacingRight;
        private bool IsDrowning;
        private bool IsTouchingWall;
        private Keys[] previousKeys;
        private bool CanJump;
        private Vector2 tomove;
        private float walkSpeed = 0.14f;
        private float runSpeed = 0.07f;
        private float jumpHeight = -5f;
        private Vector2 crouchOffset;
        private float _timer;
        private float autoDamageTimer = 1
            ;

        public int HP { get; set; }

        public PlayerGameObject(Dictionary<string, Animation> animations, float Speed = 1f, string animationLeft_AirAttack1 = "Adventurer/Left_AirAttack1", string animationLeft_AirAttack2 = "Adventurer/Left_AirAttack2", string animationLeft_AirAttack3End = "Adventurer/Left_AirAttack3", string animationLeft_AirAttack3Loop = "Adventurer/Left_AirAttack3Loop", string animationLeft_AirAttack3Ready = "Adventurer/Left_AirAttack3Ready", string animationLeft_Attack1 = "Adventurer/Left_Attack1", string animationLeft_Attack2 = "Adventurer/Left_Attack2", string animationLeft_Attack3 = "Adventurer/Left_Attack3", string animationLeft_Cast = "Adventurer/Left_Cast", string animationLeft_CastLoop = "Adventurer/Left_CastLoop", string animationLeft_CornerClimb = "Adventurer/Left_CornerClimb", string animationLeft_CornerGrab = "Adventurer/Left_CornerGrab", string animationLeft_CornerJump = "Adventurer/Left_CornerJump", string animationLeft_Crouch = "Adventurer/Left_Crouch", string animationLeft_Die = "Adventurer/Left_Die", string animationLeft_Fall = "Adventurer/Left_Fall", string animationLeft_Hurt = "Adventurer/Left_Hurt", string animationLeft_Idle = "Adventurer/Left_Idle", string animationLeft_Idle2 = "Adventurer/Left_Idle2", string animationLeft_Items = "Adventurer/Left_Items", string animationLeft_Jump = "Adventurer/Left_Jump", string animationLeft_LadderClimb = "Adventurer/Left_LadderClimb", string animationLeft_Run = "Adventurer/Left_Run", string animationLeft_Slide = "Adventurer/Left_Slide", string animationLeft_RollDodge = "Adventurer/Left_RollDodge", string animationLeft_Stand = "Adventurer/Left_Stand", string animationLeft_SwordDraw = "Adventurer/Left_SwordDraw", string animationLeft_SwordSheat = "Adventurer/Left_SwordSheat", string animationLeft_WallSlide = "Adventurer/Left_WallSlide", string animationRight_AirAttack1 = "Adventurer/Right_AirAttack1", string animationRight_AirAttack2 = "Adventurer/Right_AirAttack2", string animationRight_AirAttack3End = "Adventurer/Right_AirAttack3", string animationRight_AirAttack3Loop = "Adventurer/Right_AirAttack3Loop", string animationRight_AirAttack3Ready = "Adventurer/Right_AirAttack3Ready", string animationRight_Attack1 = "Adventurer/Right_Attack1", string animationRight_Attack2 = "Adventurer/Right_Attack2", string animationRight_Attack3 = "Adventurer/Right_Attack3", string animationRight_Cast = "Adventurer/Right_Cast", string animationRight_CastLoop = "Adventurer/Right_CastLoop", string animationRight_CornerClimb = "Adventurer/Right_CornerClimb", string animationRight_CornerGrab = "Adventurer/Right_CornerGrab", string animationRight_CornerJump = "Adventurer/Right_CornerJump", string animationRight_Crouch = "Adventurer/Right_Crouch", string animationRight_Die = "Adventurer/Right_Die", string animationRight_Fall = "Adventurer/Right_Fall", string animationRight_Hurt = "Adventurer/Right_Hurt", string animationRight_Idle = "Adventurer/Right_Idle", string animationRight_Idle2 = "Adventurer/Right_Idle2", string animationRight_Items = "Adventurer/Right_Items", string animationRight_Jump = "Adventurer/Right_Jump", string animationRight_LadderClimb = "Adventurer/Right_LadderClimb", string animationRight_Run = "Adventurer/Right_Run", string animationRight_Slide = "Adventurer/Right_Slide", string animationRight_RollDodge = "Adventurer/Right_RollDodge", string animationRight_Stand = "Adventurer/Right_Stand", string animationRight_SwordDraw = "Adventurer/Right_SwordDraw", string animationRight_SwordSheat = "Adventurer/Right_SwordSheat", string animationRight_WallSlide = "Adventurer/Right_WallSlide") : base(animations, Speed)
        {
            _animationLeft_AirAttack1 = animationLeft_AirAttack1;
            _animationLeft_AirAttack2 = animationLeft_AirAttack2;
            _animationLeft_AirAttack3End = animationLeft_AirAttack3End;
            _animationLeft_AirAttack3Loop = animationLeft_AirAttack3Loop;
            _animationLeft_AirAttack3Ready = animationLeft_AirAttack3Ready;
            _animationLeft_Attack1 = animationLeft_Attack1;
            _animationLeft_Attack2 = animationLeft_Attack2;
            _animationLeft_Attack3 = animationLeft_Attack3;
            _animationLeft_Cast = animationLeft_Cast;
            _animationLeft_CastLoop = animationLeft_CastLoop;
            _animationLeft_CornerClimb = animationLeft_CornerClimb;
            _animationLeft_CornerGrab = animationLeft_CornerGrab;
            _animationLeft_CornerJump = animationLeft_CornerJump;
            _animationLeft_Crouch = animationLeft_Crouch;
            _animationLeft_Die = animationLeft_Die;
            _animationLeft_Fall = animationLeft_Fall;
            _animationLeft_Hurt = animationLeft_Hurt;
            _animationLeft_Idle = animationLeft_Idle;
            _animationLeft_Idle2 = animationLeft_Idle2;
            _animationLeft_Items = animationLeft_Items;
            _animationLeft_Jump = animationLeft_Jump;
            _animationLeft_LadderClimb = animationLeft_LadderClimb;
            _animationLeft_Run = animationLeft_Run;
            _animationLeft_Slide = animationLeft_Slide;
            _animationLeft_RollDodge = animationLeft_RollDodge;
            _animationLeft_Stand = animationLeft_Stand;
            _animationLeft_SwordDraw = animationLeft_SwordDraw;
            _animationLeft_SwordSheat = animationLeft_SwordSheat;
            _animationLeft_WallSlide = animationLeft_WallSlide;

            _animationRight_AirAttack1 = animationRight_AirAttack1;
            _animationRight_AirAttack2 = animationRight_AirAttack2;
            _animationRight_AirAttack3End = animationRight_AirAttack3End;
            _animationRight_AirAttack3Loop = animationRight_AirAttack3Loop;
            _animationRight_AirAttack3Ready = animationRight_AirAttack3Ready;
            _animationRight_Attack1 = animationRight_Attack1;
            _animationRight_Attack2 = animationRight_Attack2;
            _animationRight_Attack3 = animationRight_Attack3;
            _animationRight_Cast = animationRight_Cast;
            _animationRight_CastLoop = animationRight_CastLoop;
            _animationRight_CornerClimb = animationRight_CornerClimb;
            _animationRight_CornerGrab = animationRight_CornerGrab;
            _animationRight_CornerJump = animationRight_CornerJump;
            _animationRight_Crouch = animationRight_Crouch;
            _animationRight_Die = animationRight_Die;
            _animationRight_Fall = animationRight_Fall;
            _animationRight_Hurt = animationRight_Hurt;
            _animationRight_Idle = animationRight_Idle;
            _animationRight_Idle2 = animationRight_Idle2;
            _animationRight_Items = animationRight_Items;
            _animationRight_Jump = animationRight_Jump;
            _animationRight_LadderClimb = animationRight_LadderClimb;
            _animationRight_Run = animationRight_Run;
            _animationRight_Slide = animationRight_Slide;
            _animationRight_RollDodge = animationRight_RollDodge;
            _animationRight_Stand = animationRight_Stand;
            _animationRight_SwordDraw = animationRight_SwordDraw;
            _animationRight_SwordSheat = animationRight_SwordSheat;
            _animationRight_WallSlide = animationRight_WallSlide;

            previousKeys = Keyboard.GetState().GetPressedKeys();
            IsfacingRight = true;
            IsTouchingWall = false;
            CanJump = false;
            JumpsLeft = 2;
            crouchOffset = new Vector2(0,_animations[_animationLeft_Crouch].Offset.Y);
            HP = 10;
        }

        #region animation names
        private string _animationLeft_AirAttack1;
        private string _animationLeft_AirAttack2;
        private string _animationLeft_AirAttack3End;
        private string _animationLeft_AirAttack3Loop;
        private string _animationLeft_AirAttack3Ready;
        private string _animationLeft_Attack1;
        private string _animationLeft_Attack2;
        private string _animationLeft_Attack3;
        private string _animationLeft_Cast;
        private string _animationLeft_CastLoop;
        private string _animationLeft_CornerClimb;
        private string _animationLeft_CornerGrab;
        private string _animationLeft_CornerJump;
        private string _animationLeft_Crouch;
        private string _animationLeft_Die;
        private string _animationLeft_Fall;
        private string _animationLeft_Hurt;
        private string _animationLeft_Idle;
        private string _animationLeft_Idle2;
        private string _animationLeft_Items;
        private string _animationLeft_Jump;
        private string _animationLeft_LadderClimb;
        private string _animationLeft_Run;
        private string _animationLeft_Slide;
        private string _animationLeft_RollDodge;
        private string _animationLeft_Stand;
        private string _animationLeft_SwordDraw;
        private string _animationLeft_SwordSheat;
        private string _animationLeft_WallSlide;

        private string _animationRight_AirAttack1;
        private string _animationRight_AirAttack2;
        private string _animationRight_AirAttack3End;
        private string _animationRight_AirAttack3Loop;
        private string _animationRight_AirAttack3Ready;
        private string _animationRight_Attack1;
        private string _animationRight_Attack2;
        private string _animationRight_Attack3;
        private string _animationRight_Cast;
        private string _animationRight_CastLoop;
        private string _animationRight_CornerClimb;
        private string _animationRight_CornerGrab;
        private string _animationRight_CornerJump;
        private string _animationRight_Crouch;
        private string _animationRight_Die;
        private string _animationRight_Fall;
        private string _animationRight_Hurt;
        private string _animationRight_Idle;
        private string _animationRight_Idle2;
        private string _animationRight_Items;
        private string _animationRight_Jump;
        private string _animationRight_LadderClimb;
        private string _animationRight_Run;
        private string _animationRight_Slide;
        private string _animationRight_RollDodge;
        private string _animationRight_Stand;
        private string _animationRight_SwordDraw;
        private string _animationRight_SwordSheat;
        private string _animationRight_WallSlide;
        #endregion


        public void SetAnimations()
        {
            if (IsGrounded)
            {
                if (Keyboard.GetState().IsKeyDown(Input.Left))
                {
                    if (Keyboard.GetState().IsKeyDown(Input.Down))
                        _animationManager.Play(_animations[_animationLeft_Crouch]);
                    else
                        _animationManager.Play(_animations[_animationLeft_Run]);
                    IsfacingRight = false;
                }
                else if (Keyboard.GetState().IsKeyDown(Input.Right))
                {
                    if (Keyboard.GetState().IsKeyDown(Input.Down))
                        _animationManager.Play(_animations[_animationRight_Crouch]);
                    else
                        _animationManager.Play(_animations[_animationRight_Run]);
                    IsfacingRight = true;

                }
                else if (IsfacingRight)
                    if (Keyboard.GetState().IsKeyDown(Input.Down))
                        _animationManager.Play(_animations[_animationRight_Crouch]);
                    else
                        _animationManager.Play(_animations[_animationRight_Idle]);
                else if (!IsfacingRight)
                    if (Keyboard.GetState().IsKeyDown(Input.Down))
                        _animationManager.Play(_animations[_animationLeft_Crouch]);
                    else
                        _animationManager.Play(_animations[_animationLeft_Idle]);
                if (Keyboard.GetState().IsKeyDown(Input.Sprint))
                    _animationManager._animation.FrameSpeed = runSpeed;
                else
                    _animationManager._animation.FrameSpeed = walkSpeed;
            }
            else
            {
                if (IsfacingRight)
                {
                    if (Keyboard.GetState().IsKeyDown(Input.Jump))
                        _animationManager.Play(_animations[_animationRight_Jump]);
                    else if(Velocity.Y>1)
                        _animationManager.Play(_animations[_animationRight_Fall]);
                }
                else
                {
                    if (Keyboard.GetState().IsKeyDown(Input.Jump))
                        _animationManager.Play(_animations[_animationLeft_Jump]);
                    else if (Velocity.Y > 1)
                        _animationManager.Play(_animations[_animationLeft_Fall]);
                }
                if (Keyboard.GetState().IsKeyDown(Input.Left))
                    IsfacingRight = false;
                if (Keyboard.GetState().IsKeyDown(Input.Right))
                    IsfacingRight = true;
            }
        }
        protected override void Move()
        {
            
            if (Keyboard.GetState().IsKeyDown(Input.Sprint))
            {
                if(Keyboard.GetState().IsKeyDown(Input.Left))
                    Velocity.X = -Speed * 2;
                else if (Keyboard.GetState().IsKeyDown(Input.Right))
                    Velocity.X = Speed * 2;
                else
                {
                    Velocity.X = Velocity.X / 1.2f;
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Input.Left))
                    Velocity.X = -Speed;
                else if (Keyboard.GetState().IsKeyDown(Input.Right))
                    Velocity.X = Speed;
                else
                {
                    Velocity.X = Velocity.X / 1.2f;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down) && !previousKeys.Contains(Input.Down))
            {
                Position -= crouchOffset;
            }
            if(!Keyboard.GetState().IsKeyDown(Input.Down) && previousKeys.Contains(Input.Down))
            {
                Position += crouchOffset;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Jump) && JumpsLeft > 0&& !previousKeys.Contains(Input.Jump))
            {
                if (Velocity.Y > jumpHeight*slow)
                    Velocity.Y = jumpHeight*slow;
                IsGrounded = false;
                JumpsLeft--;
            }
            else if (!IsGrounded)
            {
                Velocity.Y += gravity;
            }

            previousKeys = Keyboard.GetState().GetPressedKeys();
        }
        protected Rectangle _collisionRectangle;
        public Rectangle CollisionRectangle
        {
            get
            {
                _collisionRectangle.X = (int)Position.X;
                _collisionRectangle.Y = (int)Position.Y;
                _collisionRectangle.Width = (int)Dimenions.X;
                _collisionRectangle.Height = (int)Dimenions.Y;
                return _collisionRectangle;
                //return _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame;
            }
        }
        public void Collide(IHasCollision o)
        {
            Collided = true;
            if(o is ILiquid)
            {
                ILiquid liquid = o as ILiquid;
                slow = liquid.Density;
                IsGrounded = false;
                JumpsLeft = 2;
            }
            else
            {
                slow = DefaultSlowValue;
                Vector2 movement = actionManager.MoveObject((IHasCollision)this, o);

                if (movement.Y < 0)
                {
                    IsGrounded = true;
                    JumpsLeft = 2;
                    Velocity.Y = 0;
                }
                if (movement.Y > 0 && Velocity.Y < 0)
                    Velocity.Y = 0;

                tomove = movement;
                //Position += movement;
            }
        }
        public void ResolveCollisions()
        {
            Position += tomove;
            tomove.X = 0;
            tomove.Y = 0;
        }
        private bool hasJumped;
        public bool HasJumped { get => hasJumped; set => hasJumped = value; }
        public Vector2 Dimenions {
            get
            {
                _dimension.X = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Width;
                _dimension.Y = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Height;
                return _dimension;
            }
        }
        private Vector2 _dimension;
        public bool IsGrounded = false;
        public bool IsMoving
        {
            get
            {
                if (Velocity.X != 0 || Velocity.Y != 0)
                    return true;
                else
                    return false;
            }
        }


        protected override void update(GameTime gametime)
        {
            base.update(gametime);
            if (!Collided)
            {
                IsGrounded = false;
            }
            Collided = false;
            SetAnimations();
            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (_timer >= autoDamageTimer)
            {
                Damage(1);
                _timer = 0;
            }
        }

        public void Damage(int damage)
        {
            HP -= damage;
        }
    }
}
