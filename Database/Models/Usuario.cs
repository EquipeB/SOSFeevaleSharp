using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Usuario : IdentityUser
    {
        public Usuario()
            : base()
        {
            PreviousUserPasswords = new List<PreviousPassword>();
        }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        public string Foto { get; set; }
        
        public virtual ICollection<EstabelecimentoVoto> EstabelecimentoVotos { get; set; }

        public virtual ICollection<EstabelecimentoComentario> EstabelecimentoComentarios { get; set; }

        public virtual ICollection<ProdutoComentario> ProdutoComentarios { get; set; }

        public virtual ICollection<ProdutoVoto> ProdutoVotos { get; set; }

        public virtual IList<PreviousPassword> PreviousUserPasswords { get; set; }
    }

    public class PreviousPassword
    {
        public PreviousPassword()
        {
            CreateDate = DateTimeOffset.Now;
        }

        [Key, Column(Order = 0)]
        public string PasswordHash { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        public virtual Usuario User { get; set; }

    }
}
