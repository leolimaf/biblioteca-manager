using AutoMapper;
using LivrosAPI.Data;
using LivrosAPI.Data.DTOs.Emprestimo;
using LivrosAPI.Models;

namespace LivrosAPI.Services;

public class EmprestimoService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public EmprestimoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public LerEmprestimoDTO AdicionarEmprestimo(AdicionarEmprestimoDTO emprestimoDto)
    {
        Emprestimo emprestimo = _mapper.Map<Emprestimo>(emprestimoDto);
        _context.Emprestimos.Add(emprestimo);
        _context.SaveChanges();
        return _mapper.Map<LerEmprestimoDTO>(emprestimo);
    }

    public LerEmprestimoDTO ObterEmprestimoPorId(long id)
    {
        Emprestimo emprestimo = _context.Emprestimos.FirstOrDefault(emprestimo => emprestimo.Id == id);
        if (emprestimo is not null)
        {
            LerEmprestimoDTO emprestimoDto = _mapper.Map<LerEmprestimoDTO>(emprestimo);
            return emprestimoDto;
        }
        return null;
    }
}