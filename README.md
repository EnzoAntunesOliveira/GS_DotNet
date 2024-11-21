# Gs_DotNet Project

Este é um projeto em .NET para a gestão de dispositivos eletrônicos, incluindo funcionalidades para criação, leitura, atualização e exclusão (CRUD) de eletrodomésticos, com integração ao banco de dados Oracle.

## Sumário

- [Instalação](#instalação)
- [Configuração](#configuração)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Funcionalidades](#funcionalidades)
- [APIs Disponíveis](#apis-disponíveis)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Contribuição](#contribuição)
- [Integrantes](#integrantes)

## Instalação

1. Clone este repositório:
   ```bash
   git clone https://github.com/EnzoAntunesOliveira/GS_DotNet.git
2. Navegue até o diretório do projeto:
    ```bash
   cd Gs_DotNet
4. Restaure os pacotes do projeto:
     ```bash
   dotnet restore

## Configurações

### Banco de Dados:

Este projeto usa o Oracle Database como sistema de gerenciamento de banco de dados.

1. Configuração da Conexão: No arquivo `appsettings.json`, configure a string de conexão com o banco de dados Oracle:
```bash
"ConnectionStrings": {
  "FiapOracleConnection": "Data Source=//oracle.fiap.com.br:1521/orcl;User Id=<SeuUserId>;Password=<SuaSenha>;"
}
 ```
2. Configurações de Desenvolvimento: Em ambiente de desenvolvimento, você pode ajustar os níveis de log no arquivo `appsettings.Development.json`.

### Inicialização da Aplicação
Para inicializar a aplicação, execute o comando:
 ```bash
dotnet run
 ```
## Estrutura do Projeto
```bash
├── Controllers            # Controladores para os endpoints de cada eletrodoméstico
├── Data                   # Contexto do banco de dados e migrações
├── Domain                 # Entidades de domínio
├── Dtos                   # Objetos de Transferência de Dados (DTOs)
├── Migrations             # Arquivos de migração para o Entity Framework
└── Program.cs             # Arquivo principal para configuração do pipeline da aplicação
```
## Funcionalidades

O projeto gerencia vários tipos de eletrodomésticos, incluindo:
- Cafeteiras
- Geladeiras
- Máquinas de Lavar
- Micro-ondas
- Ventiladores

Cada tipo de eletrodoméstico possui um repositório, DTO e controlador correspondentes, permitindo operações CRUD. A relação com o objeto `Eletrodomestico` é realizada por meio de uma associação única, onde cada eletrodoméstico contém os detalhes básicos (voltagem, marca, modelo, etc.).

## APIs Disponíveis
As APIs são implementadas usando controladores separados para cada tipo de eletrodoméstico:

### Endpoints Comuns
- `GET /api/<Eletrodomestico>` - Retorna todos os registros.
- `GET /api/<Eletrodomestico>/{id}` - Retorna um registro específico por ID.
- `POST /api/<Eletrodomestico>` - Adiciona um novo registro.
- `PUT /api/<Eletrodomestico>/{id}` - Atualiza um registro existente.
- `DELETE /api/<Eletrodomestico>/{id}` - Exclui um registro.

### Exemplo de Endpoint para Geladeira
Criar uma nova Geladeira

POST /api/Geladeira
Content-Type: application/json
  ```bash
{
  "CapacidadeFreezerLitros": 300,
  "ConsumoKwh": 0.8,
  "QuantidadePortas": 2,
  "TipoDisplay": "LED",
  "TemPortaLatas": "Sim",
  "Eletrodomestico": {
    "Voltagem": "220V",
    "Marca": "Marca Exemplo",
    "Modelo": "Modelo Exemplo",
    "EficienciaEnergetica": "A",
    "Cor": "Branco",
    "Peso": 70.5,
    "LinkCompra": "https://linkdecompra.com"
  }
}
```
Buscar uma Geladeira por ID
  ```bash
GET /api/Geladeira/{id}
 ```
## Tecnologias Utilizadas
- ASP.NET Core - Para construção da API Web.
- Entity Framework Core - Para manipulação de dados e mapeamento objeto-relacional.
- Oracle Database - Banco de dados utilizado para persistência dos dados.
- Swagger - Documentação automática das APIs.
- DTOs - Objetos de Transferência de Dados para simplificação de dados na camada de API.

### Configuração de Logs
O projeto está configurado para registrar logs em diferentes níveis, conforme definidos em `appsettings.json`:
  ```bash
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.AspNetCore": "Warning"
  }
}
 ```
## Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Faça um fork do projeto.
2. Crie uma nova branch para sua funcionalidade `(git checkout -b feature/sua-funcionalidade)`.
3. Commit suas mudanças `(git commit -m 'Adiciona nova funcionalidade')`.
4. Envie para a branch `(git push origin feature/sua-funcionalidade)`.
5. Abra um Pull Request.

## Integrantes
### RM552752 Arthur Fenili
### RM553185 Enzo Antunes Oliveira
### RM553813 Vinicio Raphael Santana




