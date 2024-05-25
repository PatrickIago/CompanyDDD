namespace CompanyDDD.Domain.Entities;
public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public decimal Salario { get; set; }
    public string Email { get; set; }
    public string Contato { get; set; }
}
