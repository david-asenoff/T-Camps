namespace T_Camps.Data
{
    using System;

    /// <summary>
    /// Has IsDeleted and DeletedOn.
    /// </summary>
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
