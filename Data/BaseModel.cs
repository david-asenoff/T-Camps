namespace T_Camps.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Has Id, CreatedOn and ModifiedOn.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseModel<TKey> : IAuditInfo
    {
        public BaseModel()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.ModifiedOn = null;
        }
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
