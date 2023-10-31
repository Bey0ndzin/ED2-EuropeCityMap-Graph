using System;
using System.IO;
using System.Windows.Forms;

internal class Ligacao : IComparable<Ligacao>, IRegistro<Ligacao>
{
  const int tamCodigo = 3,
        tamDistancia = 5,
        tamTempo = 4,
        tamCusto = 5;

  const int iniCodigoOrigem = 0,
            iniCodigoDestino = iniCodigoOrigem + tamCodigo,
            iniDistancia = iniCodigoDestino + tamCodigo,
            iniTempo = iniDistancia + tamDistancia,
            iniCusto = iniTempo + tamTempo;


  string idCidadeOrigem, idCidadeDestino;
  int distancia, tempo, custo;

    const int tamanhoRegistro = sizeof(int) * 4;
    public int TamanhoRegistro { get => tamanhoRegistro; }
  public Ligacao(string idCidadeOrigem, string idCidadeDestino, int distancia, int tempo, int custo)
  {
    this.idCidadeOrigem = idCidadeOrigem;
    this.idCidadeDestino = idCidadeDestino;
    this.distancia = distancia;
    this.tempo = tempo;
    this.custo = custo;
  }

  public string IdCidadeOrigem { get => idCidadeOrigem; set => idCidadeOrigem = value; }
  public string IdCidadeDestino { get => idCidadeDestino; set => idCidadeDestino = value; }
  public int Distancia { get => distancia; set => distancia = value; }
  public int Tempo { get => tempo; set => tempo = value; }
  public int Custo { get => custo; set => custo = value; }

  public int CompareTo(Ligacao outro)
  {
    return (idCidadeOrigem.ToUpperInvariant()+idCidadeDestino.ToUpperInvariant()).CompareTo(
            outro.idCidadeOrigem.ToUpperInvariant()+outro.idCidadeDestino.ToUpperInvariant());
  }
    public Ligacao LerRegistro(BinaryReader arquivo, long qlRegistro)
    {
        if (arquivo != null && qlRegistro != 0)
        {
            try
            {
                long qtosBytes = qlRegistro * tamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);
                char[] umaOrigem = arquivo.ReadChars(tamCodigo);
                string nomeLido = "";
                for (int i = 0; i < tamCodigo; i++)
                    nomeLido += umaOrigem[i];
                idCidadeOrigem = nomeLido;

                char[] umDest = arquivo.ReadChars(tamCodigo);
                nomeLido = "";
                for (int i = 0; i < tamCodigo; i++)
                    nomeLido += umDest[i];
                idCidadeDestino = nomeLido;

                Distancia = arquivo.ReadInt32();
                Tempo = arquivo.ReadInt32();
                Custo = arquivo.ReadInt32();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return this;
        }
        return default(Ligacao);
    }
  public void GravarRegistro(BinaryWriter arq)
  {
    if (arq != null)  // arquivo de saída aberto?
    {
            if (arq != null)
            {
                char[] umaOrigem = new char[tamCodigo];
                for (int i = 0; i < tamCodigo; i++)
                    umaOrigem[i] = idCidadeOrigem[i];
                arq.Write(umaOrigem);
                char[] umDest = new char[tamCodigo];
                for (int i = 0; i < tamCodigo; i++)
                    umDest[i] = idCidadeDestino[i];
                arq.Write(umDest);
                arq.Write(Distancia);
                arq.Write(Tempo);
                arq.Write(Custo);
            }
        }
  }

  public override string ToString()
  {
    return $"{IdCidadeOrigem} {IdCidadeDestino} {Distancia:00000} {Tempo:0000} {Custo:00000}";
  }
}