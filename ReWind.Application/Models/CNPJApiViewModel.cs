namespace HackathonEquipe6.Application.Models;

public class CNPJApiViewModel
{
    public string Email { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public List<TelefoneDto> Telefones { get; set; }
}

public class TelefoneDto
{
    public string Telefone { get; set; }
    public bool Whatsapp { get; set; }
}