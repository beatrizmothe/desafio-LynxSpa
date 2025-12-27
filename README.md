# Desafio Lynx SPA – Mini Aplicação de Gestão de Pedidos

Este projeto foi desenvolvido como parte de um desafio técnico para a vaga de Estágio na Lynx SPA.
Consiste em uma mini aplicação de gestão de pedidos, com backend em ASP.NET Core,
frontend em HTML/CSS/JavaScript e banco de dados SQLite.

---

## Tecnologias Utilizadas

### Backend
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite

### Frontend
- HTML
- CSS
- JavaScript (Fetch API)

### Outros
- Git e GitHub

## Funcionalidades

### Produtos
- Listagem de produtos com filtros opcionais
- Criação, edição e remoção de produtos
- Ativação e desativação de produtos

### Pedidos
- Criação de pedidos com validações
- Listagem de pedidos com cálculo automático do total
- Detalhamento de pedido por ID
- Validação de itens e produtos ativos

### Pagamentos
- Registro de pagamentos
- Cálculo do total pago
- Atualização automática do status do pedido para PAID

---

## Como Executar o Projeto

### Backend
1. Acesse a pasta do backend
2. Execute o comando:
   dotnet run
3. A API estará disponível em:
   http://localhost:5000

> Obs: A porta pode variar conforme a configuração do ambiente.

### Frontend
1. Abra o arquivo index.html no navegador
2. Certifique-se de que a API esteja rodando

## Decisões Técnicas

- O backend foi desenvolvido em ASP.NET Core por ser uma tecnologia amplamente utilizada no mercado.
- O SQLite foi escolhido por simplicidade e por atender bem ao escopo do desafio.
- O frontend foi feito sem frameworks para manter a solução simples e alinhada ao desafio proposto.

## Como Clonar o Repositório

```bash
git clone https://github.com/beatrizmothe/desafio-LynxSpa.git
```

Acesse a pasta do projeto:
```bash
cd desafio-LynxSpa
```

