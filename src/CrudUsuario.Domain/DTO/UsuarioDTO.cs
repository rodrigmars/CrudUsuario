using System;

namespace CrudUsuario.Domain.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
