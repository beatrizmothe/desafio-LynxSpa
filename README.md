# Desafio Lynx SPA – Avaliação Técnica

Mini aplicação de **Gestão de Pedidos**.  
O projeto tem como objetivo permitir o gerenciamento de produtos, pedidos, itens de pedido e pagamentos, aplicando regras de negócio.

---

## Tecnologias Utilizadas

### Backend
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite

### Frontend
- HTML5
- CSS3
- JavaScript

---

## Estrutura do Projeto

```text
desafio-LynxSpa/
├── backend/    # API REST
└── frontend/   # Aplicação Web
```

---

## Funcionalidades

### Backend
- Listagem de produtos com filtros opcionais
- Listagem de pedidos resumidos
- Detalhamento de pedidos por ID
- Criação de pedidos com validações
- Registro de pagamentos
- Cálculo automático do total do pedido
- Atualização do status do pedido para **PAID**
- Tratamento de erros com mensagens claras

### Frontend
- Listagem de produtos com busca
- Filtro por categoria
- Opção para exibir somente produtos ativos
- Carrinho de compras em JavaScript
- Cálculo de subtotal e total
- Criação de pedidos via API
- Listagem e detalhamento de pedidos
- Validações básicas de formulário
- Interface simples e responsiva

---

## Como Rodar o Projeto Localmente

### Pré-requisitos
- .NET SDK 6 ou superior
- Git
- Navegador web

---

### Clonar o Repositório

```bash
git clone https://github.com/beatrizmothe/desafio-LynxSpa.git
cd desafio-LynxSpa
```

---

### Executar o Backend (API)

```bash
cd backend
dotnet run
```

A API será iniciada em:

```text
http://localhost:5047
```

Swagger disponível em:

```text
http://localhost:5047/swagger
```

O banco de dados **SQLite** é criado automaticamente na primeira execução.

---

### Executar o Frontend

1. Acesse a pasta `frontend`
2. Abra o arquivo `index.html` no navegador  

ou  

3. Utilize a extensão **Live Server** no VS Code

O frontend consome a API em:

```text
http://localhost:5047
```
⚠️ **Importante:** o backend deve estar em execução para o frontend funcionar corretamente.
```
