# Stack Gestão de Hospital

[![.NET Version](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat-square)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](https://opensource.org/licenses/MIT)

Um sistema desktop para gerenciamento de operações hospitalares, desenvolvido em C# com WPF e Entity Framework Core.

> ⚠️ **AVISO IMPORTANTE**  
> Este é um **projeto educacional** desenvolvido para fins de estudo de **WPF, Arquitetura MVC e Entity Framework Core**.

## 📋 Sobre o Projeto

O **StackGestaoDeHospital** é uma aplicação de gerenciamento hospitalar que permite controlar departamentos, médicos, enfermeiros, pacientes e atendimentos. O sistema foi desenvolvido com uma arquitetura em camadas, separando Models, Data Access (Database), Controllers e Views (Apresentação).

Este projeto serve como estudo prático dos seguintes conceitos:

- **WPF** - Windows Presentation Foundation para interfaces desktop
- **Arquitetura em Camadas** - Separação de responsabilidades
- **Entity Framework Core** - ORM para acesso a dados
- **Repository Pattern** - Abstração do acesso a dados
- **MVC/MVVM** - Padrões de projeto

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

```
StackGestaoDeHospital
├── StackGestaoDeHospital.Model          # Entidades do domínio
├── StackGestaoDeHospital.DataBase       # Acesso a dados (EF Core, Repositories)
├── StackGestaoDeHospital.Controller     # Lógica de negócio
└── StackGestaoDeHospital.View           # Interface WPF
```

### Estrutura Detalhada

- **Model**: Contém as classes de entidades
  - `Pessoa.cs` - Classe base para pessoas
  - `Paciente.cs` - Dados de pacientes
  - `Medico.cs` - Dados de médicos
  - `Enfermeiro.cs` - Dados de enfermeiros
  - `Funcionario.cs` - Dados de funcionários
  - `Departamento.cs` - Departamentos do hospital
  - `Especialidade.cs` - Especialidades médicas
  - `Atendimento.cs` - Registros de atendimento

- **DataBase**: Acesso a dados com Entity Framework Core
  - `HospitalDbContext.cs` - DbContext principal
  - `Configurations/` - Fluent API configurations
  - `Repositories/` - Repository pattern para acesso a dados

- **Controller**: Controladores com lógica de negócio
  - `DepartamentosController.cs` - Lógica de departamentos

- **View**: Interface WPF
  - `MainWindow.xaml` - Tela principal
  - `appsettings.json` - Configurações da aplicação

## 🚀 Tecnologias

- **.NET 10.0**
- **WPF** - Windows Presentation Foundation
- **Entity Framework Core 10.0.8**
- **SQL Server**
- **C#**

## 📋 Pré-requisitos

- **.NET 10.0 SDK** ou superior instalado
- **SQL Server** (Express, Standard ou Enterprise)
- **Visual Studio 2022** ou **Visual Studio Code** com C# Dev Kit
- **Git**

## 💾 Banco de Dados

O projeto utiliza **SQL Server** como banco de dados. Você precisará:

1. Ter SQL Server instalado e rodando
2. Configurar a connection string no arquivo `appsettings.json`

### Exemplo de appsettings.json:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HospitalDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  }
}
```

## ⚙️ Instalação

### 1. Clone o repositório

```bash
git clone https://github.com/V1ctorMachado/StackGestaoDeHospital.git
cd StackGestaoDeHospital
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Configure a connection string

Edite o arquivo `StackGestaoDeHospital.View/appsettings.json` com as suas credenciais do SQL Server.

### 4. Crie e aplique as migrations

#### Criar uma migration

```bash
dotnet ef migrations add <NomeMigration> --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View --output-dir Migrations
```

**Exemplo:**

```bash
dotnet ef migrations add InitialCreate --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View --output-dir Migrations
```

#### Aplicar a migration ao banco de dados

```bash
dotnet ef database update --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

### 5. Execute a aplicação

```bash
dotnet run --project StackGestaoDeHospital.View
```

## 🔧 Comandos Úteis do Entity Framework

### Remover a última migration (ainda não aplicada)

```bash
dotnet ef migrations remove --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

### Reverter para uma migration específica

```bash
dotnet ef database update <NomeMigration> --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

**Exemplo - Reverter para InitialCreate:**

```bash
dotnet ef database update InitialCreate --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

### Listar todas as migrations

```bash
dotnet ef migrations list --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

## 🎯 Funcionalidades

- ✅ Gerenciamento de pacientes
- ✅ Registro de atendimentos
- ✅ Controle de especialidades médicas
- ✅ Interface WPF intuitiva

## 📁 Estrutura de Diretórios

```
StackGestaoDeHospital/
├── StackGestaoDeHospital.Model/
│   ├── Pessoa.cs
│   ├── Paciente.cs
│   ├── Medico.cs
│   ├── Enfermeiro.cs
│   ├── Funcionario.cs
│   ├── Departamento.cs
│   ├── Especialidade.cs
│   ├── Atendimento.cs
│   └── StackGestaoDeHospital.Model.csproj
├── StackGestaoDeHospital.DataBase/
│   ├── HospitalDbContext.cs
│   ├── Configurations/
│   │   └── DepartamentoConfiguration.cs
│   ├── Repositories/
│   │   ├── DepartamentosRepository.cs
│   │   └── RepositoryBase.cs
│   └── StackGestaoDeHospital.DataBase.csproj
├── StackGestaoDeHospital.Controller/
│   ├── DepartamentosController.cs
│   └── StackGestaoDeHospital.Controller.csproj
├── StackGestaoDeHospital.View/
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── appsettings.json
│   ├── Screens/
│   │   ├── MainWindow.xaml
│   │   └── MainWindow.xaml.cs
│   └── StackGestaoDeHospital.View.csproj
├── StackGestaoDeHospital.slnx
└── README.md
```

## 🤝 Contribuição

Contribuições são bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

## ✉️ Contato

**Desenvolvedores:** Bernardo Abaurre e Victor Machado  
**GitHub:** [@BernardoAbaurre](https://github.com/BernardoAbaurre) [@V1ctorMachado](https://github.com/V1ctorMachado)

---

**Desenvolvido como parte da disciplina de Programação Orientada a Objetos II (POOII) - UVV**
