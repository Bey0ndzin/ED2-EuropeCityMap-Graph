using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

public class Cidade : IComparable<Cidade>, IRegistro<Cidade>
  {
    const int tamNome = 15,
              tamX = 6,
              tamY = 6;

    string nome;
    double x, y;

    const int tamanhoRegistro = tamNome + sizeof(double) * 2;
    public string Nome   { get => nome; set => nome = value.PadRight(tamNome, ' ').Substring(0, tamNome); }
    public double X         { get => x; set => x = value; }
    public double Y         { get => y; set => y = value; }

    public int TamanhoRegistro { get => tamanhoRegistro; }

    public Cidade(string nome, double x, double y)
    {
        Nome = nome;
        X = x;
        Y = y;
    }
    public Cidade() { }

    public int CompareTo(Cidade outro)
    {
        return nome.ToUpperInvariant().CompareTo(outro.nome.ToUpperInvariant());
    }

    public Cidade LerRegistro(BinaryReader arquivo, long qlRegistro)
    {
      if (arquivo != null && qlRegistro != 0)
      {
            try
            {
                long qtosBytes = qlRegistro * tamanhoRegistro;
                arquivo.BaseStream.Seek(qtosBytes, SeekOrigin.Begin);
                char[] umNome = arquivo.ReadChars(tamNome);
                string nomeLido = "";
                for(int i = 0; i<tamNome; i++)
                    nomeLido += umNome[i];
                Nome = nomeLido;
                X = arquivo.ReadDouble();
                Y = arquivo.ReadDouble();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        return this;
      }
      return default(Cidade);
    }

    public void GravarRegistro(BinaryWriter arq)
    {
        if(arq != null)
        {
            char[] umNome = new char[tamNome];
            for (int i = 0; i < tamNome; i++)
                umNome[i] = nome[i];
            arq.Write(umNome);
            arq.Write(X);
            arq.Write(Y);
        }
    }
    public override string ToString()
    {
        return Nome + X.ToString().PadLeft(tamX, ' ') + Y.ToString().PadLeft(tamY, ' ');
    }
}
