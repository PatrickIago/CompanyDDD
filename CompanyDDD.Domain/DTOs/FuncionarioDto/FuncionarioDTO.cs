namespace CompanyDDD.Domain.DTOs.FuncionarioDto;

public class FuncionarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public decimal Salario { get; set; }
    public int DepartamentoId { get; set; }
    public string DepartamentoNome { get; set; }
    public string Descricao { get; set; }
}