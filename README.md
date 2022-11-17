# Projeto Back-end LABTRANS UFSC
 Projeto desenvolvido para o desafio LABTRANS da UFSC para vaga desenvolvedor full-stack.
 
## APIs Banana Ltda

### Objetivo do Documento

Este documento tem como objetivo demonstrar todos os requisitos funcionais e design dos objetos de banco de dados e assim como campos de tela e funcionalidades.

### Objetivo do Software

APIs Mensagens tem como objetivo disponibilizar a primeira parte das APIs como teste simples como bônus.

APIs Reservas tem como objetivo disponibilizar a funcionalidade principal do desafio que é realizar reservas de salas para a empresa Banana Ltda.

### Detalhes do Software – APIs de CRUD do sistema

Este projeto será comtemplado com APis básicas de cadastro e listagens.
* API de Cadastro de usuários (Utilizaremos o Identity Microsoft).
* APIs de Cadastro, edição, exclusão, listagem de Mensagens.
* APIs de Cadastro, edição, exclusão, listagem de Reservas de salas

### Detalhes do Software – Regras APis Notificações

Esta API será comtemplada com 1 regras de validação.
*	Validação de título não pode ser vazio.

### Detalhes do Software – Regras APis Reservas

Esta API será comtemplada com 6 regras de validação.
*	Validação de local da reserva que não pode ser vazio, sendo notificado através de nosso sistema de notificações.
*	Validação de sala da reserva que não pode ser vazio, sendo notificado através de nosso sistema de notificações.
*	Validação de data inicial da reserva que não pode ser vazio e não pode ser menor que data atual, sendo notificado através de nosso sistema de notificações.
*	Validação de data final da reserva que não pode ser vazio e não pode ser menor que data inicial, sendo notificado através de nosso sistema de notificações.
*	Validação de responsável da reserva que não pode ser vazio, sendo notificado através de nosso sistema de notificações.
*	Validação de choque de horários da reserva em que uma sala não pode ser reservada na mesma data, local e horario de outra reserva, sendo notificado através de nosso sistema de notificações.

### Detalhes da arquitetura

O DDD (Domain Driven Design) é uma modelagem de software cujo objetivo é facilitar a implementação de regras e processos complexos, visando a divisão de responsabilidades por camadas e é independente da tecnologia utilizada. Ou seja, o DDD é uma filosofia voltada para o domínio do negócio.
Resumindo, nossa regra de negócio se encontrará toda no domínio da aplicação.

### Detalhes técnicos

* Identity Microsoft: Gerenciamento de usuários
* Framework: .NET 7
* Linguagem de programação: C#
* Banco de dados: SQL Server
* Front-End: APIs Swagger UI

### Detalhes técnicos do design da tela

Não teremos telas neste projeto back-end, apenas a documentação da API utilizando o Swagger. 
As telas do sistema estarão contempladas em outro projeto de front-end.

## Modelo de banco de dados (Tabelas utilizadas no projeto)

*	AspNetUsers (Tabela criada pelo gerenciamento de usuários Microsoft Identity)
Tabela de armazenagem dos usuários do portal (Customizada com campos)

*	TB_MESSAGE(Tabela criada para cadastro dos MESSAGE)
Tabela de armazenagem de notícias.

*	TB_BOOKING(Tabela criada para cadastro dos BOOKING)
Tabela de armazenagem de reservas.

### Tabela AspNetUsers

| Nome Coluna	| Tipo	       | Tamanho	| Obrigatório	| Padrão 	| Observação            |
|-------------|-------------|---------|-------------|---------|-----------------------|
| USR_CPF     |	VARCHAR(20) |	20	     | SIM	        |         |                       |
| USR_TIPO    |	INT	        |	        | SIM         |	Comum	  | Administrador / Comum	|

### Tabela TB_MESSAGE

| Nome Coluna	       | Tipo	        | Tamanho	| Obrigatório	| Padrão 	| Observação   |
|--------------------|--------------|---------|-------------|---------|--------------|
| MSN_TITULO         |	VARCHAR(255)	| 255    	| SIM	       	|         |              |
| MSN_ATIVO          |	BOOL		       |         | SIM	        | Ativo   | True / False |	
| MSN_DATA_CADASTRO  |	DATETIME	    |         |	SIM		       |         | Automático   |
| MSN_DATA_ALTERACAO | DATETIME	    |	        | SIM		       |         | Automático   |

### Tabela TB_BOOKING

| Nome Coluna	         | Tipo	        | Tamanho	| Obrigatório	| Padrão 	| Observação   |
|----------------------|--------------|---------|-------------|---------|--------------|
| BOK_LOCAL            |	INT         	|        	| SIM	       	|         | Lista        |
| BOK_SALA             |	INT          |         | SIM	        |         | Lista        |	
| BOK_DATA_HORA_INICIO |	DATETIME	    |         |	SIM		       |         |              |
| BOK_DATA_HORA_FIM    | DATETIME	    |	        | SIM		       |         |              |
| BOK_RESPONSAVEL      |	VARCHAR(255)	| 255    	| SIM	       	|         |              |
| BOK_CAFE             |	BOOL		       |         | NÃO	        |         |              |	
| BOK_QTD_PESSOAS_CAFE |	INT     	    |         |	NÃO		       |         |              |
| BOK_DESCRICAO        | VARCHAR(255)	|	255     | NÃO		       |         |              |

## Execução do projeto

Para a execução do projeto deve-se utilizar o Visual Studio 2022 atualizado com a verão do DotNet 7.

* Primeiro abra o arquivo Back-end.sln
* Depois defina o projeto WebAPI como projeto de inicialização.
* Mude a string de conexão para apontar para o seu banco de dados SQL Server 2019.
* Abra o "Console do Gerenciador de Pacotes" ou "Tools > NuGet Package Manager > Package Manager Console" no visual studio.
* Defina o projeto inicial no gerenciador de pacotes como "3 - Infra\Infrastructure" 
* Execute os comando para gerar as migrations e o banco de dados abaixo.
* Por fim, execute o projeto para testar a aplicação.

Comandos para instalar as ferramentas do EntityFrameworkCore: (Caso você não os tenha instalado)
```
Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.Design
```
Comandos para Gerar o banco de dados:
```
Add-Migration BancoInicial -Context ContextBase

Update-Database -Context ContextBase
```

### Envolvidos 

**Nome:**	Luiz Fernando da Silva - **Data:**	16/11/2022	- **Status:** Enviado



