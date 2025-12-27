Desafio Lynx SPA – Avaliação Técnica

Este projeto tem como objetivo atender aos requisitos da Avaliação Técnica da Lynx SPA, por meio do desenvolvimento de uma mini aplicação de Gestão de Pedidos com backend em API REST e frontend

A aplicação é composta por:

Backend: API REST para gerenciamento de produtos, pedidos e pagamentos

Frontend: SPA simples para listagem de produtos, carrinho e visualização de pedidos

Tecnologias Utilizadas

Backend

C#

ASP.NET Core Web API

Entity Framework Core

SQLite

Frontend

HTML

CSS

JavaScript (Vanilla)

Estrutura do Projeto
desafio-LynxSpa/
├── backend/
└── frontend/

Funcionalidades Principais

Listagem de produtos com busca e filtros

Filtro por categoria e produtos ativos

Carrinho de compras em JavaScript

Criação de pedidos

Listagem e detalhamento de pedidos

Integração com API REST

Como Executar o Projeto
Pré-requisitos

Antes de iniciar, é necessário ter instalado na máquina:

.NET SDK 6 ou superior

Git

Navegador web (Chrome, Edge, Firefox, etc.)

1️⃣ Clonar o repositório
git clone https://github.com/beatrizmothe/desafio-LynxSpa.git
cd desafio-LynxSpa

2️⃣ Executar o Backend (API)

Acesse a pasta do backend:

cd backend


Execute a aplicação:

dotnet run


A API será iniciada em:

http://localhost:5047


Swagger disponível em:

http://localhost:5047/swagger


O banco de dados SQLite é criado automaticamente na primeira execução.

3️⃣ Executar o Frontend

Acesse a pasta frontend

Abra o arquivo index.html diretamente no navegador
(ou utilize a extensão Live Server no VS Code)

⚠️ O backend deve estar em execução para que o frontend funcione corretamente.
