namespace CompanyDDD.Domain.DTOs;
public class FuncionarioUpdateDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataNascimento { get; set; }
}
