namespace T_Camps.Data
{
    using System;

    /// <summary>
    /// Has CreatedOn and ModifiedOn.
    /// </summary>
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
