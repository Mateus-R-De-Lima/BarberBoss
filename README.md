# 💈 BarberBoss

> 🚀 Projeto de estudo e portfólio — API para gerenciamento de barbearias, desenvolvida em **.NET**, com foco em **boas práticas, arquitetura limpa e testes automatizados**.

---

## 🧩 Sobre o projeto

O **BarberBoss** é uma aplicação desenvolvida com o objetivo de **aprimorar conceitos de backend, arquitetura limpa e testes unitários em .NET**.  
O sistema simula o gerenciamento de uma barbearia, permitindo o controle de faturamento, clientes, agendamentos e serviços, além de servir como base de aprendizado para aplicações corporativas escaláveis.

Este projeto **não é comercial**, sendo voltado para fins **educacionais e de portfólio**.

---

## 🏗️ Arquitetura e camadas

O projeto segue os princípios da **Clean Architecture**, garantindo **baixo acoplamento, alta coesão** e **testabilidade**.  
Cada camada tem uma responsabilidade clara e depende apenas das camadas internas.

```
BarberBoss
│
├── BarberBoss.Api             → Camada de apresentação (Controllers, Middlewares, Swagger)
├── BarberBoss.Application     → Casos de uso, validações e orquestração das regras de negócio
├── BarberBoss.Domain          → Entidades, enums, interfaces e regras de domínio puras
├── BarberBoss.Infrastructure  → Persistência, repositórios, banco de dados e contexto EF
├── BarberBoss.Communication   → DTOs, contratos e mapeamentos entre camadas
├── BarberBoss.Exception       → Tratamento centralizado de erros e exceções customizadas
├── BarberBoss.Tests           → Testes unitários com xUnit e FluentAssertions
└── BarberBoss.sln             → Solução principal que referencia todos os projetos
```

---

## ⚙️ Tecnologias utilizadas

| Categoria | Tecnologia | Descrição |
|------------|-------------|------------|
| Linguagem | **C# (.NET 8)** | Plataforma principal do projeto |
| Framework Web | **ASP.NET Core Web API** | Criação de endpoints RESTful |
| ORM / Banco | **Entity Framework Core** | Acesso e mapeamento relacional |
| Injeção de Dependência | **.NET Dependency Injection** | Gerenciamento de dependências |
| Validação | **FluentValidation** | Validação de entidades e DTOs |
| Mapeamento | **AutoMapper** | Conversão entre modelos e entidades |
| Testes | **xUnit**, **FluentAssertions**, **Moq** | Testes unitários e mocks |
| Documentação | **Swagger / Swashbuckle** | Documentação automática da API |
| Logs | **Serilog** *(opcional)* | Log estruturado e rastreável |
| Contêineres | **Docker / docker-compose** | Ambiente de desenvolvimento isolado |

---

## 🧪 Testes unitários

O projeto conta com uma suíte de **testes automatizados**, garantindo a qualidade e o comportamento esperado das regras de negócio.

### Frameworks utilizados:
- **xUnit** → estrutura principal de testes
- **Moq** → simulação de dependências (repositórios, serviços, etc.)

```

### Executando os testes
Para rodar os testes localmente:
```bash
dotnet test
```

O comando exibirá no terminal os testes executados, tempo total e resultados de sucesso/falha.

---

## 🚀 Como executar o projeto

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/Mateus-R-De-Lima/BarberBoss.git
cd BarberBoss
```

### 2️⃣ Restaurar dependências
```bash
dotnet restore
```

### 3️⃣ (Opcional) Executar via Docker
```bash
docker-compose up -d
```

### 4️⃣ Rodar a aplicação
```bash
cd BarberBoss.Api
dotnet run
```

### 5️⃣ Acessar a documentação
Abra o navegador e acesse:  
👉 **https://localhost:5001/swagger**

---

## 📊 Funcionalidades principais

✅ Cadastro e gestão de faturamentos  
✅ Filtragem e paginação de registros  
✅ Exportação de relatórios (Excel)  
✅ Tratamento centralizado de erros  
✅ Testes unitários cobrindo regras de negócio  
✅ Arquitetura modular e escalável  

---

## 🧱 Decisões arquiteturais

- Clean Architecture com separação de responsabilidades  
- Inversão de dependência e uso de interfaces  
- Regras de domínio independentes da infraestrutura  
- Injeção de dependências nativa do .NET  
- DTOs e Mappers para isolar camadas  
- Middleware global para tratamento de exceções  
- Testes unitários para garantir a integridade do domínio  

---

## 💡 Próximas melhorias

- Autenticação e autorização com **JWT**  
- Testes de integração com banco real  
- Cache em memória (Redis)  
- Logs estruturados com Serilog  
- Integração com frontend em React  
- CI/CD com GitHub Actions  

---

## 👨‍💻 Autor

**Mateus R. de Lima**  
💼 Desenvolvedor Back-End | C# | .NET | Arquitetura Limpa  
📍 Projeto de estudo e portfólio pessoal  



---

## 📄 Licença

Distribuído sob a licença **MIT**.  
Veja o arquivo `LICENSE` para mais informações.
