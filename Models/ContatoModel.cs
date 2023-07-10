using System.ComponentModel.DataAnnotations;

namespace CadastroDeContatos.Models;

public class ContatoModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O Email é Obrigatório")]
    [EmailAddress(ErrorMessage = "O Email é Invalido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O número de Celular é Obrigatório")]
    [Phone(ErrorMessage = "O celular informado é invalido")]
    public string Celular { get; set; }
}
