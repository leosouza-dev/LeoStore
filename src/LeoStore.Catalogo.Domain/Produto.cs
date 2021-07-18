using System;
using System.Collections.Generic;
using System.Text;
using LeoStore.Core.DomainObjects;

namespace LeoStore.Catalogo.Domain
{
    // categoria atende a produto, logo produto é uma raiz de agregação
    public class Produto : Entity, IAggreagteRoot
    {

    }

    // categoria é uma entidade
    public class Categoria : Entity
    {
    }
}
