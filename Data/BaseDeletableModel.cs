namespace T_Camps.Data
{
    using System;

    /// <summary>
    /// Has IsDeleted, DeletedOn, Id, CreatedOn and ModifiedOn.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public BaseDeletableModel()
        {
            this.IsDeleted = false;
            this.DeletedOn = null;
        }
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
