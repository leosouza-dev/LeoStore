using System;
using System.Collections.Generic;
using System.Text;
using LeoStore.Core.DomainObjects;

namespace LeoStore.Catalogo.Domain
{
    // categoria atende a produto, logo produto é uma raiz de agregação
    public class Produto : Entity, IAggregateRoot
    {
        public Produto(string nome, 
                       string descricao, 
                       bool ativo, 
                       decimal valor, 
                       Guid categoriaId,
                       DateTime dataCadastro, 
                       string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            CategoriaId = categoriaId;
            DataCadastro = dataCadastro;
            Imagem = imagem;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        // Produto possui uma Categoria - Para o relacionamento no EF Core
        public Guid CategoriaId { get; private set; } // prop. que vai para o BD
        public Categoria Categoria { get; private set; } // prop. de navegação

        // AdHoc
        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            // alguma validação
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            // podemos validar se o numero é negativo e fazer o modulo se for..
            if (quantidade < 0) quantidade *= -1;

            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            // ainda vamos validar
        }
    }

    // categoria é uma entidade
    public class Categoria : Entity
    {
        public Categoria(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public string Nome { get; private set; }
        public string Codigo { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

    }
}
