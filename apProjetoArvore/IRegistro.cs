using System.IO;

public interface IRegistro<Dado>
{
    Dado LerRegistro(BinaryReader arquivo, long qlRegistro);
    void GravarRegistro(BinaryWriter arquivo);
    int TamanhoRegistro { get; }
}