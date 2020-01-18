namespace GameProjectCode.Objects
{
    internal interface IKillable
    {
        bool IsAlive { get; set; }
        void Die();
    }
}