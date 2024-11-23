# **GlobalSolution - Plataforma Integrada de Gestão de Informações**

## **Descrição do Projeto**
O GlobalSolution é uma aplicação desenvolvida para gerenciamento eficiente de conteúdos, interações, feedbacks e gamificação por meio de quizzes. A plataforma proporciona um ambiente organizado e estruturado para lidar com informações de usuários e conteúdos educativos.

## **Funcionalidades Principais**

- **Gerenciamento de Usuários**: Cadastro e manutenção de informações de usuários.
- **Conteúdos Educativos**: Criação, leitura, atualização e exclusão de conteúdos.
- **Interações**: Registro de interações de usuários com conteúdos.
- **Feedbacks**: Coleta de feedbacks dos usuários sobre os conteúdos.
- **Quizzes**: Sistema de pontuação baseado em quizzes para engajamento.
- **Dicas de Economia**: Cadastro e visualização de dicas práticas.

## **Links Relevantes**

- **Código do Projeto**: [Repositório no GitHub](#)
- **Documentação da API Swagger**: [Swagger UI](http://localhost:7055/api-docs)

## **Integrantes do Grupo**
- **Igor Akira | RM 554227 | Turma: 2TDSPS**: Desenvolvedor do código-fonte.
- **Nicola Monte | RM 553991 | Turma: 2TDSPR**: Desenvolvedor do código-fonte.    
- **Willyam Santos | RM 554244 | Turma: 2TDSZ**: Responsável pela documentação do projeto.

## **Problema**
Organizações frequentemente enfrentam dificuldades em gerenciar informações de forma eficiente, seja por falta de sistemas estruturados ou pela dificuldade de engajar usuários em atividades como quizzes e feedbacks. O GlobalSolution foi projetado para resolver essas questões com uma interface robusta e intuitiva.

## **Solução**
A plataforma GlobalSolution integra diferentes funcionalidades, oferecendo uma solução centralizada para gerenciamento de informações. Com recursos como feedbacks, interações e pontuações de quizzes, o sistema promove engajamento e coleta de dados relevantes.

## **Público-Alvo**

- Organizações que precisam gerenciar conteúdos educativos.
- Usuários que desejam interagir com plataformas educativas de forma prática.
- Instituições interessadas em gamificação para engajamento.

## **Tecnologias Utilizadas**

- **Backend**: ASP.NET Core 8.0
- **Banco de Dados**: Oracle Database
- **Documentação**: Swagger
- **Gerenciamento de Dependências**: NuGet
- **Linguagem**: C#

## **Como Configurar e Rodar o Projeto**

### **Pré-requisitos**

- .NET 8.0 SDK instalado.
- Banco de dados Oracle configurado.
- Ferramenta de gerenciamento de banco de dados (como SQL Developer).

### **Passos para Execução**

1. Clone o repositório:
   ```bash
   git clone <url-do-repositorio>
   ```
2. Acesse a pasta do projeto:
   ```bash
   cd GlobalSolution
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Execute o projeto:
   ```bash
   dotnet run
   ```
5. Acesse a aplicação:
   - **URL Padrão**: [http://localhost:7055](http://localhost:7055)
   - **Documentação Swagger**: [http://localhost:7055/api-docs](http://localhost:7055/api-docs)

## **Listagem de Endpoints**

### **Usuários (`/Usuario`)**

- **GET** `/Usuario/listar`: Lista todos os usuários.
- **GET** `/Usuario/detalhes/{id}`: Detalha um usuário específico.
- **POST** `/Usuario/criar`: Cria um novo usuário.
- **POST** `/Usuario/editar/{id}`: Atualiza um usuário existente.
- **POST** `/Usuario/excluir/{id}`: Remove um usuário.

### **Conteúdos (`/Conteudo`)**

- **GET** `/Conteudo/listar`: Lista todos os conteúdos.
- **GET** `/Conteudo/detalhes/{id}`: Detalha um conteúdo específico.
- **POST** `/Conteudo/criar`: Cria um novo conteúdo.
- **POST** `/Conteudo/editar/{id}`: Atualiza um conteúdo existente.
- **POST** `/Conteudo/excluir/{id}`: Remove um conteúdo.

### **Dicas de Economia (`/DicaEconomia`)**

- **GET** `/DicaEconomia/listar`: Lista todas as dicas.
- **GET** `/DicaEconomia/detalhes/{id}`: Detalha uma dica específica.
- **POST** `/DicaEconomia/criar`: Cria uma nova dica.
- **POST** `/DicaEconomia/editar/{id}`: Atualiza uma dica existente.
- **POST** `/DicaEconomia/excluir/{id}`: Remove uma dica.

### **Feedbacks (`/FeedbackUsuario`)**

- **GET** `/FeedbackUsuario/listar`: Lista todos os feedbacks.
- **GET** `/FeedbackUsuario/detalhes/{id}`: Detalha um feedback específico.
- **POST** `/FeedbackUsuario/criar`: Cria um novo feedback.
- **POST** `/FeedbackUsuario/editar/{id}`: Atualiza um feedback existente.
- **POST** `/FeedbackUsuario/excluir/{id}`: Remove um feedback.

### **Interações (`/Interacao`)**

- **GET** `/Interacao/listar`: Lista todas as interações.
- **GET** `/Interacao/detalhes/{id}`: Detalha uma interação específica.
- **POST** `/Interacao/criar`: Cria uma nova interação.
- **POST** `/Interacao/editar/{id}`: Atualiza uma interação existente.
- **POST** `/Interacao/excluir/{id}`: Remove uma interação.

### **Pontuações de Quiz (`/PontuacaoQuiz`)**

- **GET** `/PontuacaoQuiz/listar`: Lista todas as pontuações.
- **GET** `/PontuacaoQuiz/detalhes/{id}`: Detalha uma pontuação específica.
- **POST** `/PontuacaoQuiz/criar`: Cria uma nova pontuação.
- **POST** `/PontuacaoQuiz/editar/{id}`: Atualiza uma pontuação existente.
- **POST** `/PontuacaoQuiz/excluir/{id}`: Remove uma pontuação.

## **Swagger UI**

A aplicação está documentada utilizando o **Swagger**, permitindo fácil visualização e teste dos endpoints.

- **Acesso ao Swagger UI**: [http://localhost:7055/api-docs](http://localhost:7055/api-docs)
- **Principais Recursos**:
  - Visualização interativa dos endpoints.
  - Teste direto dos endpoints pela interface.
  - Documentação auto gerada.
