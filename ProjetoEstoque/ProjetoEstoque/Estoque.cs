using System;
using System.Collections.Generic;
using System.Globalization; 

namespace ProjetoEstoque
{
    internal class Estoque
    {
        public String Nome { get; private set; }
        public double Preco { get; private set; }
        public int Codigo { get; private set; }
        public int Quantidade { get; set; }
        

        public Estoque(String nome, double preco,int codigo, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Codigo = codigo;
            AdicionarQuantidade(quantidade);
        }
        
        
        public double ValorEstoque()
        {
            return Preco * Quantidade;
        }
        public void AdicionarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
        public void RemoverProdutos(int remover)
        {
            Quantidade-= remover;
        }

        public override string ToString()
        {
            return "Produto: " + Nome
                + "\nPreço: " + Preco.ToString("F2", CultureInfo.InvariantCulture)
                +"\nCodigo: " + Codigo
                +"\nQuantidade: " + Quantidade
                +"\nValor Total: " + ValorEstoque();
        }

    }
}
