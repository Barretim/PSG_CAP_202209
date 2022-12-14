public abstract class BaseAtributos
{
    protected int id;
    public int Id { get => id; set => id = value; }
    public BaseAtributos()
    { }
    public BaseAtributos(int id)
    {
        this.id = id;
    }
}
public abstract class BasePessoaAtributos : BaseAtributos
{
    protected string nome = string.Empty;
    protected string email = string.Empty;
    protected string telefone = string.Empty;
    protected string usuario = string.Empty;
    protected string senha = string.Empty;
    protected DateTime dataNascimento;
    public string Nome { get => nome; set => nome = value; }
    public string Email { get => email; set => email = value; }
    public string Telefone { get => telefone; set => telefone = value; }
    public string Usuario { get => usuario; set => usuario = value; }
    public string Senha { get => senha; set => senha = value; }
    public DateTime DataNascimento { get => dataNascimento; set => dataNascimento = value; }
    public BasePessoaAtributos(int id) : base(id)
    { }
    public BasePessoaAtributos(string nome, string email, string telefone, string usuario,
    string senha, DateTime dataNascimento)
    {
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
        this.usuario = usuario;
        this.senha = senha;
        this.dataNascimento = dataNascimento;
    }
}
public class Funcionario : BasePessoa//?????????
{
    private string matricula = string.Empty;
    private string contaCorrente = string.Empty;
    public Funcionario(string nome, string email, string telefone, string usuario, string senha,
    DateTime dataNascimento)
    : base(nome, email, telefone, usuario, senha, dataNascimento)
    {
    }
}

public class Bilhete : BaseAtributos
{
    private int numeroBilhete;
    private string assento = string.Empty;
    public Bilhete()
    { }
    public Bilhete(int id, int numeroBilhete, string assento) : base(id)
    {
        this.numeroBilhete = numeroBilhete;
        this.assento = assento;
    }
}
public static class FakeDBGenerico<TDominio> where TDominio : class
{
    private static List<TDominio>? tabela;
    public static List<TDominio>? Tabela
    {
        get
        {
            if (tabela == null)
            {
                tabela = new List<TDominio>();
            }
            return tabela;
        }
    }
}
public abstract class RepositorioGenerico<TDominio> where TDominio : class
{
    public RepositorioGenerico()
    { }
    public virtual TDominio Create(TDominio obj)
    {
        throw new NotImplementedException();
    }
    public virtual TDominio? Read(int chave)
    {
        throw new NotImplementedException();
    }
    public List<TDominio> ReadAll()
    {
        return FakeDBGenerico<TDominio>.Tabela;
    }
    public virtual TDominio? Update(TDominio obj)
    {
        throw new NotImplementedException();
    }

    public TDominio? Delete(int chave)
    {
        TDominio? original = this.Read(chave);
        if (original != null)
        {
            FakeDBGenerico<TDominio>.Tabela.Remove(original);
        }
        return original;
    }
}

public class BilheteRepositorio : RepositorioGenerico<Bilhete>
{
    public override Bilhete Create(Bilhete obj)
    {
        int chave = 0;
        if (FakeDBGenerico<Bilhete>.Tabela.Count == 0)
            chave++;
        else
            chave = FakeDBGenerico<Bilhete>.Tabela.Last().Id + 1;
        obj.Id = chave;
        FakeDBGenerico<Bilhete>.Tabela.Add(obj);
        return obj;
    }
    public override Bilhete? Read(int chave)
    {
        return FakeDBGenerico<Bilhete>.Tabela.SingleOrDefault(obj => obj.Id == chave);
    }
    public override Bilhete? Update(Bilhete obj)
    {
        Bilhete? original = this.Read(obj.Id);
        if (original != null)
        {
            original.NumeroBilhete = obj.NumeroBilhete;
            original.Assento = obj.Assento;
        }
        return original;
    }
}