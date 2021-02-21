using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    /// <summary>
    /// The user entity.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// The user's email address.
        /// </summary>
        [Key]
        [EmailAddressAttribute]
        public string Email { get; set; }
    }
}