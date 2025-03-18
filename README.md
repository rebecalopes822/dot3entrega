# OdontoPrev API

API desenvolvida em **ASP.NET Core Web API** para gerenciamento de pacientes, tratamentos e sinistros odontológicos.

## Integrantes do Grupo

- **Giovanna Lima** - RM: RM553369
- **Lorenzo Vaz** - RM: RM553941
- **Rebeca Lopes** - RM: RM553764

## Arquitetura do Projeto

Optamos por uma **arquitetura monolítica**, onde toda a lógica da aplicação está concentrada em uma única API. Essa abordagem foi escolhida por ser mais simples de desenvolver, testar e manter dentro do escopo do projeto.

Caso o sistema cresça no futuro, há a possibilidade de migração para uma arquitetura baseada em **microservices**, separando os módulos de pacientes, tratamentos e sinistros em serviços independentes.

## Design Patterns Utilizados

- **Singleton** → Implementado na classe `ConfigManager`, responsável por garantir uma única instância da configuração do banco de dados.
- **Repository Pattern** → Criamos repositórios (`PacienteRepository`, `TratamentoRepository`, `SinistroRepository`) para centralizar a lógica de acesso ao banco de dados, garantindo um código mais organizado e reutilizável.

## Como Rodar a API

### Clonar e Rodar a API no Visual Studio 2022

1. **Clonar o Repositório do GitHub**

   - Abrir o Visual Studio 2022.
   - Clicar em "Clonar um repositório".
   - Colar a URL do GitHub e escolher um local para salvar.
   - Clicar em "Clonar" e aguardar o download.

2. **Abrir e Configurar o Projeto**

   - Abrir o arquivo `.sln` do projeto (se não abrir automaticamente).
   - No Gerenciador de Soluções (`Ctrl + Alt + L`), clicar com o botão direito no projeto API e selecionar "Definir como Projeto de Inicialização".

3. **Restaurar Dependências**

   - No Visual Studio, abrir "Gerenciador de Pacotes NuGet".
   - Executar o comando:
     ```sh
     dotnet restore
     ```

4. **Configurar o Banco de Dados (se necessário)**

   - Verificar se o banco de dados está rodando.
   - Ajustar a string de conexão no `appsettings.json`.

5. **Executar a API**

   - **Opção 1: Pelo Visual Studio**
     - Pressionar `F5` para rodar.
   - **Opção 2: Pelo Terminal**
     - No terminal, navegar até a pasta do projeto e rodar:
       ```sh
       dotnet run
       ```

6. **Testar a API**

   - Acessar no navegador:
     ```
     http://localhost:5000/swagger
     ```
   - Testar via Postman, se necessário.

## Exemplos de Testes

### Criando um Paciente (POST)

```json
{
  "nome": "Felipe Almeida",
  "email": "felipe.almeida@email.com",
  "dataNascimento": "1990-03-15T00:00:00",
  "telefone": "11999887766",
  "generoId": 1,
  "enderecoId": 8
}
```

### Criando um Tratamento (POST)

```json
{
  "id": 3,
  "descricao": "Canal Dentário",
  "tipo": "Urgência",
  "custo": 1200
}
```

### Criando um Sinistro (POST)

```json
{
  "pacienteId": 18,
  "tratamentoId": 5,
  "dataOcorrencia": "2025-03-18T02:55:38.901Z",
  "status": "Pendente"
}
```

### Atualizando um Paciente (PUT)

```json
{
  "id": 18,
  "nome": "Ricardo Mendes",
  "email": "ricardo.mendes@email.com",
  "dataNascimento": "1988-07-22T00:00:00",
  "telefone": "(11) 91234-5678",
  "generoId": 1,
  "enderecoId": 8
}
```

### Atualizando um Tratamento (PUT)

```json
{
  "id": 2,
  "descricao": "Extração de dente",
  "tipo": "Cirúrgico",
  "custo": 250.00
}
```

### Atualizando um Sinistro (PUT)

```json
{
  "id": 10,
  "pacienteId": 12,
  "tratamentoId": 2,
  "dataOcorrencia": "2024-04-05T00:00:00",
  "status": "Em andamento"
}
```

## Tecnologias Utilizadas

- **.NET 8.0**
- **Entity Framework Core**
- **Oracle Database**
- **Swagger / OpenAPI**
- **Postman para testes**