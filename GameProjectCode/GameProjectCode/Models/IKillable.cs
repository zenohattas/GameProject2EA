namespace GameProjectCode.Objects
{
    internal interface IKillable
    {
        bool IsAllive { get; set; }
        void Die();
    }
}