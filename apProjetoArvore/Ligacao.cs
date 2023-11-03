using System;
using System.IO;
using System.Windows.Forms;

public class Ligacao : IComparable<Ligacao>, IRegistro<Ligacao>
{
    const int tamOrigem = 15,
              tamDestino = 15;


    string idCidadeOrigem, idCidadeDestino;
    int distancia, tempo;

    const int tamanhoRegistro = tamOrigem + tamDestino + sizeof(int) * 2;
    public int TamanhoRegistro { get => tamanhoRegistro; }
    public Ligacao(string idCidadeOrigem, string idCidadeDestino, int distancia, int tempo)
    {
      this.idCidadeOrigem = idCidadeOrigem;
      this.idCidadeDestino = idCidadeDestino;
      this.distancia = distancia;
      this.tempo = tempo;
    }
    public Ligacao() { }

    public string Origem { get => idCidadeOrigem; set => idCidadeOrigem = value; }
    public string Destino { get => idCidadeDestino; set => idCidadeDestino = value; }
    public int Distancia { get => distancia; set => distancia = value; }
    public int Tempo { get => tempo; set => tempo = value; }

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
                 char[] umaOrigem = arquivo.ReadChars(tamOrigem);
                 string nomeLido = "";
                 for (int i = 0; i < tamOrigem; i++)
                     nomeLido += umaOrigem[i];
                 idCidadeOrigem = nomeLido;

                 char[] umDest = arquivo.ReadChars(tamDestino);
                 nomeLido = "";
                 for (int i = 0; i < tamDestino; i++)
                     nomeLido += umDest[i];
                 idCidadeDestino = nomeLido;

                 Distancia = arquivo.ReadInt32();
                 Tempo = arquivo.ReadInt32();
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
                char[] umaOrigem = new char[tamOrigem];
                for (int i = 0; i < tamOrigem; i++)
                    umaOrigem[i] = idCidadeOrigem[i];
                arq.Write(umaOrigem);

                char[] umDest = new char[tamDestino];
                for (int i = 0; i < tamDestino; i++)
                    umDest[i] = idCidadeDestino[i];

                arq.Write(umDest);
                arq.Write(Distancia);
                arq.Write(Tempo);
            }
        }
      }

      public override string ToString()
      {
        return $"{Origem} {Destino} {Distancia:00000} {Tempo:0000}";
      }
}