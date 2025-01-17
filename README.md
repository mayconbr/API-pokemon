Pokedex MVC

Este é um projeto de uma Pokedex desenvolvido com a arquitetura MVC (Model-View-Controller). A Pokedex permite que usuários se registrem, façam login, explorem uma lista de Pokémon e capturem seus Pokémon favoritos.

Funcionalidades

Autenticação de Usuários:

Registro de novos usuários.

Login e logout de usuários.

Exploração de Pokémon:

Visualização de uma lista de Pokémon.

Detalhes individuais de cada Pokémon.

Captura de Pokémon:

Usuários podem capturar Pokémon e adicioná-los à sua coleção pessoal.

Lista de Pokémon capturados por usuário.

Perfil do Usuário:

Visualização e gerenciamento da coleção de Pokémon capturados.

Tecnologias Utilizadas

Back-end:

Linguagem: C#

Framework: ASP.NET Core MVC

Banco de Dados: SQL Server

Front-end:

HTML5, CSS3, JavaScript

Biblioteca de estilo: Bootstrap

Outros:

Sistema de controle de versão: Git

Integração com API externa para dados de Pokémon (ex.: PokéAPI).

Estrutura do Projeto

Models: Classes que representam os dados do sistema, como Usuário, Pokémon e Captura.

Views: Interfaces de usuário (HTML + Razor).

Controllers: Gerenciamento das requisições HTTP e lógica de negócio.

Como Executar o Projeto

Clonar o Repositório:

git clone https://github.com/seu-usuario/pokedex-mvc.git
cd pokedex-mvc

Configurar o Banco de Dados:

Configure a string de conexão no arquivo appsettings.json.

Execute as migrações para criar o banco de dados:

dotnet ef database update

Executar o Projeto:

dotnet run

O projeto será iniciado no endereço http://localhost:5000.

Contribuição

Contribuições são bem-vindas! Para contribuir:

Fork o repositório.

Crie uma nova branch para sua funcionalidade ou correção:

git checkout -b minha-funcionalidade

Commit suas alterações:

git commit -m "Adiciona nova funcionalidade"

Envie suas alterações:

git push origin minha-funcionalidade

Abra um Pull Request.

Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo LICENSE para mais detalhes.
