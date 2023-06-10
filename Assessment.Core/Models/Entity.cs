using Newtonsoft.Json;
using System;

namespace Assessment.Core.Models
{
    /// <summary>
    /// Class that must be inherited by all persistent entities.
    /// When assigned to a collection to be cached before storing (most ORM requires this)
    /// it should override <see cref="Equals(object)"/> and <see cref="GetHashCode"/>.
    /// Descendants should specify the <see cref="GetBusinessHashcode"/> hashcode based on 'business fields', all the
    /// fields that are relevant for the business logic, omiting any fields that are
    /// relevant to the persistance engine (i.e. omit Id, LastUpdated, Created from hashcode).    ///
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="System.IComparable&lt;Assessment.Core.Models.Entity&lt;TId&gt;&gt;" />
    /// <seealso cref="System.IEquatable&lt;Assessment.Core.Models.Entity&lt;TId&gt;&gt;" />
    [Serializable]
    public abstract class Entity<TId> : IComparable<Entity<TId>>, IEquatable<Entity<TId>>
    {
        private int? hashCode;

        public virtual TId Id { get; set; }
        public virtual DateTimeOffset? CreatedDate { get; set; }
        public virtual DateTimeOffset? LastUpdated { get; set; }
        public virtual DateTimeOffset? InactiveDate { get; set; }
        public virtual bool? IsActive { get; set; } = true;

        public override bool Equals(object obj)
        {
            return obj is not null && (ReferenceEquals(this, obj) || Equals(obj as Entity<TId>));
        }
        /// <summary>
        /// Gets a value indicating whether this instance is transient.
        /// Transience is relevant to assign a new Id for the object previoust to persisting it to storage.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        public virtual bool IsTransient { get => Equals(Id, default(TId)); }

        [JsonIgnore]
        public virtual bool MarkModified { get; set; }

        /// <summary>
        /// Determines whether the fields on the instance were modified from another instance that represents the same persistant object.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if [is modified from] [the specified other]; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsModifiedFrom(Entity<TId> other)
        {
            return Equals(other) && !EqualByFields(other);
        }

        public override int GetHashCode()
        {
            hashCode ??= IsTransient ? GetBusinessHashcode() : Id.GetHashCode();
            return hashCode.Value;
        }

        protected abstract int GetBusinessHashcode();

        public abstract int CompareTo(Entity<TId> other);

        public abstract bool EqualByFields<T>(T other);

        public virtual bool Equals(Entity<TId> other)
        {
            return IsTransient ? EqualByFields(other) : Equals(Id, other.Id);
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return right is not null && (ReferenceEquals(left, right) || left.Equals(right));
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !(left == right);
        }
    }
}
