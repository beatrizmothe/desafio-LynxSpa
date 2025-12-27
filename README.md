# Desafio Lynx SPA – Avaliação Técnica

Mini aplicação de **Gestão de Pedidos**, desenvolvida como parte da **Avaliação Técnica da Lynx SPA** para a vaga de **Estágio**.  
O projeto tem como objetivo demonstrar conhecimentos em **backend com API REST** e **frontend web**, atendendo aos requisitos funcionais propostos no desafio.

A aplicação permite o gerenciamento de produtos, pedidos, itens de pedido e pagamentos, com regras de negócio aplicadas conforme especificação.

---

## Tecnologias Utilizadas

### Backend
- **C#**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**

### Frontend
- **HTML5**
- **CSS3**
- **JavaScript (Vanilla)**

---

## Estrutura do Projeto

desafio-LynxSpa/
├── backend/ # API REST
└── frontend/ # Aplicação Web


---

## Funcionalidades

### Backend
- Listagem de produtos com filtros opcionais
- Listagem de pedidos resumidos
- Detalhamento de pedidos por ID
- Criação de pedidos com validações
- Registro de pagamentos
- Cálculo automático do total do pedido
- Atualização do status do pedido para **PAID** quando aplicável
- Tratamento de erros com mensagens claras

### Frontend
- Listagem de produtos com busca
- Filtro por categoria
- Opção para exibir somente produtos ativos
- Carrinho de compras local em JavaScript
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

### Clone o repositório
```bash
git clone https://github.com/beatrizmothe/desafio-LynxSpa.git
cd desafio-LynxSpa

Executar o Backend (API)

Acesse a pasta do backend:

cd backend


Execute a aplicação:

dotnet run


A API será iniciada em:

http://localhost:5047


Swagger disponível em:

http://localhost:5047/swagger


O banco de dados SQLite é criado automaticamente na primeira execução.

Executar o Frontend

Acesse a pasta frontend

Abra o arquivo index.html diretamente no navegador
ou utilize a extensão Live Server no VS Code

O frontend consome a API rodando localmente em:

http://localhost:5047


⚠️ O backend deve estar em execução para o frontend funcionar corretamente.

